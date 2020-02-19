using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace ClashCS
{
    public partial class MainForm : Form
    {
        public static int runningFlag = 0;
        //static string baseDIR = Environment.CurrentDirectory.ToString();
        static string baseDIR = @"C:\ProgramMy\Clash\Clash";
        string DIR = baseDIR;
        string mmdbURL = "https://geolite.clash.dev/Country.mmdb";
        private SynchronizationContext context;
        private FolderBrowserDialog folderBrowserDialog1;

        public MainForm()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            ThreadStart ts1 = new ThreadStart(CheckProcess);
            Thread checkProcess = new Thread(ts1);
            checkProcess.IsBackground = true;
            checkProcess.Start();
        }
        private void LoadConf()
        {
            Thread.Sleep(10);
            if (runningFlag == 1)
            {
                HttpUtils http = new HttpUtils();
                var c = http.RestGetConfigs();
                http_port_textBox.Text = c[0];
                socks_port_textBox.Text = c[1];
                redir_port_textBox.Text = c[2];
                allow_lan_checkBox.Checked = Convert.ToBoolean(c[3]);
                switch (c[4])
                {
                    case "Direct":
                        direct_radioButton.Checked = true;
                        break;
                    case "Global":
                        global_radioButton.Checked = true;
                        break;
                    default:
                        rule_radioButton.Checked = true;
                        break;
                }
                Process[] ps = Process.GetProcessesByName("clash-windows-amd64");
                if (ps != null && ps.Length > 0)
                {
                    string _d = ps[0].MainModule.FileName;
                    local_config_path_textBox.Text = _d.Substring(0, _d.Length - 24);
                }
            }
            else return;
        }
        private bool GetConfig()
        {
            if (local_radioButton1.Checked && local_config_path_textBox.Text != "")
            {
                FileInfo yaml = new FileInfo(local_config_path_textBox.Text + "\\config.yaml");
                FileInfo mmdb = new FileInfo(local_config_path_textBox.Text + "\\Country.mmdb");
                if (yaml.Exists)
                {
                    if (!mmdb.Exists)
                    {
                        DialogResult dr = MessageBox.Show("Country.mmdb not exist, donwload it?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (dr == DialogResult.OK)
                        {
                            string result = HttpUtils.Start(mmdbURL, local_config_path_textBox.Text + "\\Country.mmdb");
                            MessageBox.Show(result);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        DIR = local_config_path_textBox.Text;
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("config.yaml not exist! Check your path again and re-start!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
            else if (sub_radioButton2.Checked) 
            {
                FileInfo yaml = new FileInfo(DIR + "\\download\\config.yaml");
                FileInfo mmdb = new FileInfo(DIR + "\\download\\Country.mmdb");
                if (yaml.Exists)
                {
                    if (!mmdb.Exists)
                    {
                        FileInfo mmdb1 = new FileInfo(DIR + @"\Country.mmdb");
                        mmdb1.CopyTo(DIR + "\\download\\Country.mmdb");
                    }
                    DIR += @"\download";
                    return true;
                }
                else
                {
                    MessageBox.Show("test.config.yaml not exist! Download again or check!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }               
            }
            else 
            {
                FileInfo yaml = new FileInfo(DIR + "\\config.yaml");
                FileInfo mmdb = new FileInfo(DIR + "\\Country.mmdb");
                if (yaml.Exists)
                {
                    if (!mmdb.Exists)
                    {
                        DialogResult dr = MessageBox.Show("Country.mmdb not exist, donwload it?", "WARNING", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
                        if (dr == DialogResult.OK)
                        {
                            string result = HttpUtils.Start(mmdbURL, local_config_path_textBox.Text + "\\Country.mmdb");
                            MessageBox.Show(result, "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                    else
                    {
                        return true;
                    }
                }
                else
                {
                    MessageBox.Show("config.yaml not exist! Check again and re-start!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return false;
                }
            }
        }
        private void CheckProcess()
        {           
            while (true)
            {
                runningFlag = 0;
                Process[] ps = Process.GetProcessesByName("clash-windows-amd64");
                if (ps != null && ps.Length > 0)
                {
                    runningFlag = 1;                                     
                }
                context.Send(ChangeStatus, runningFlag);
                Thread.Sleep(1000);
            }
        }
        private void ChangeStatus(object flag)
        {
            if (flag.ToString() == "1")
            {
                status.Text = "Running";
                status.ForeColor = Color.Green;
            }
            else
            {
                status.Text = "Stopped";
                status.ForeColor = Color.Red;
            }
        }
        private void log_button1_Click(object sender, EventArgs e)
        {
            if (runningFlag == 1)
            {
                LogsForm logForm = new LogsForm();
                LogsForm.FormFlag = logForm;
                logForm.Show();
            }
            else
            {
                MessageBox.Show("Clash is not running!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void share_button_Click(object sender, EventArgs e)
        {
            ShareQRCodeForm qrcode = new ShareQRCodeForm();
            qrcode.Show();
        }
        private void browse_button_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1 = new FolderBrowserDialog();
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                local_config_path_textBox.Text = folderBrowserDialog1.SelectedPath;
            }
            else
            {
                MessageBox.Show("Selected Nothing!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void download_button_Click(object sender, EventArgs e)
        {
            if (sub_textBox.Text == "")
            {
                MessageBox.Show("URL is Empty!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            else
            {
                bool flag = Directory.Exists(DIR + @"\download");
                if (!flag)
                {
                    Directory.CreateDirectory(DIR + "\\download");
                }
                flag = File.Exists(DIR + @"\download\config.yaml");
                if (flag)
                {
                    File.Move(DIR + @"\download\config.yaml", DIR + @"\download\config.yaml" + DateTime.Now.ToString(" yyyy-MM-ss HH_MM_ss") + ".bak");
                }
                string result = HttpUtils.Start(sub_textBox.Text, DIR + "\\download\\config.yaml");
                MessageBox.Show(result);
            }
        }
        private void stop_button_Click(object sender, EventArgs e)
        {
            if (runningFlag == 1)
            {
                Process[] procs = Process.GetProcessesByName("clash-windows-amd64");
                if (LogsForm.FormFlag != null)
                {
                    LogsForm.FormFlag.Close();
                }
                foreach (Process p in procs) 
                {
                    p.Kill();
                }
                MessageBox.Show("Kill proc Success!", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Clash is not running!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void start_button_Click(object sender, EventArgs e)
        {
            if (!GetConfig())
            {
                return;
            }
            Process p = new Process();
            p.StartInfo.FileName = baseDIR + "\\clash-windows-amd64.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.Arguments = " -d " + "\"" + DIR + "\"";
            if (runningFlag == 0)
            {
                p.Start();
                MessageBox.Show("Start Success! \n CMD: \n" + p.StartInfo.FileName + p.StartInfo.Arguments, "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Already Started!", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            LoadConf();
            DIR = baseDIR;
        }
        private void apply_button_Click(object sender, EventArgs e)
        {
            //int mode = 2;
            if (rule_radioButton.Checked)
            {
            }
            else if (global_radioButton.Checked)
            {
            }
            //apply mode here...

            restart_button_Click(sender, e);
        }
        private void restart_button_Click(object sender, EventArgs e)
        {
            stop_button_Click(sender, e);
            start_button_Click(sender, e);
        }
        private void ClashCSMainForm_Load(object sender, EventArgs e)
        {
            LoadConf();
        }
        private void sub_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            sub_radioButton2.Checked = true;
        }
        private void local_radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (local_radioButton1.Checked)
            {
                download_button.Enabled = false;
                sub_textBox.Enabled = false;
                browse_button.Enabled = true;
                local_config_path_textBox.Enabled = true;
            }
            else
            {
                browse_button.Enabled = false;
                local_config_path_textBox.Enabled = false;
                download_button.Enabled = true;
                sub_textBox.Enabled = true;
            }
        }

    }
}
