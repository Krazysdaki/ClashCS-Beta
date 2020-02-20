using System;
using System.IO;
using System.Drawing;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading.Tasks;
using static ClashCS.HttpUtils;

namespace ClashCS
{
    public partial class MainForm : Form
    {
        public static int runningFlag = 0;
        public static string mode = "Rule";
        static string baseDIR = Environment.CurrentDirectory.ToString();
        //static string baseDIR = @"C:\ProgramMy\Clash\Clash";
        string DIR = baseDIR;
        string mmdbURL = "https://geolite.clash.dev/Country.mmdb";

        public static SynchronizationContext context;
        public static SynchronizationContext cntx;
        private FolderBrowserDialog folderBrowserDialog1;

        static StatusStrip statusStrip1;
        static ToolStripStatusLabel updownLabel;
        static ToolStripStatusLabel toolStripStatusLabel1;
        static ToolStripStatusLabel toolStripStatusLabel2;

        HttpUtils http = new HttpUtils();

        public struct Configs
        {
            public string port;
            public string sport;
            public string rport;
            public string lan;
            public string mode;
        }
        Configs configs;

        public MainForm()
        {
            InitializeComponent();
            context = SynchronizationContext.Current;
            cntx = SynchronizationContext.Current;
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
                var c = http.RestGetConf(configsURL);
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
                Task getUpDown = new Task(() => {
                    http.RestGetStream(trafficURL);
                });
                getUpDown.Start();
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

        private void LoadStatusStrip()
        {
            statusStrip1 = new System.Windows.Forms.StatusStrip();
            updownLabel = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            statusStrip1.SuspendLayout();
            // statusStrip1
            // 
            statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            updownLabel,
            toolStripStatusLabel1,
            toolStripStatusLabel2});
            statusStrip1.Location = new System.Drawing.Point(0, 571);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new System.Drawing.Size(471, 25);
            statusStrip1.TabIndex = 44;
            statusStrip1.Text = "statusStrip1";
            // 
            // updownLabel
            // 
            updownLabel.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            updownLabel.ForeColor = System.Drawing.Color.Gray;
            updownLabel.Name = "updownLabel";
            updownLabel.Size = new System.Drawing.Size(173, 20);
            updownLabel.Text = "▲0KB/s ▼0KB/s";
            // 
            // toolStripStatusLabel1
            // 
            toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            toolStripStatusLabel1.Size = new System.Drawing.Size(51, 20);
            toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabel2
            // 
            toolStripStatusLabel2.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            toolStripStatusLabel2.ForeColor = System.Drawing.Color.Gray;
            toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            toolStripStatusLabel2.Size = new System.Drawing.Size(193, 20);
            toolStripStatusLabel2.Text = "©Copyright 2020 Krazys. ";
            Controls.Add(statusStrip1);
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
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

        public static void SetUpDown(object _s)
        {
            var _str = _s.ToString();
            var _d = _str.Split(',');
            updownLabel.Text = "▲" + _d[0] + "KB/s " + "▼" + _d[1] + "KB/s";
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
            Share qrcode = new Share();
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
            p.StartInfo.FileName = DIR + "\\clash-windows-amd64.exe";
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.UseShellExecute = false;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.Arguments = " -d " + "\"" + DIR + "\"";
            if (runningFlag == 0)
            {
                try { p.Start(); }
                catch { MessageBox.Show("Couldn't find clash-windows-amd64.exe!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning); }
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
            if (restPort_textBox.Text != null)
            {
                PORT = restPort_textBox.Text;
                configsURL = configsURL = IP + ":" + PORT + "/configs";
                MessageBox.Show(configsURL);
                configs.port = http_port_textBox.Text;
                configs.sport = socks_port_textBox.Text;
                configs.rport = redir_port_textBox.Text;
                configs.lan = (allow_lan_checkBox.Checked.ToString()).ToLower();
                configs.mode = mode;
                if (string.IsNullOrEmpty(configs.port) || string.IsNullOrEmpty(configs.sport) || string.IsNullOrEmpty(configs.rport))
                {
                    MessageBox.Show("Don't leave it empty!", "WARNING", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }                  
                http.RestPatch(configs);
            }
            //restart_button_Click(sender, e);
        }

        private void restart_button_Click(object sender, EventArgs e)
        {
            stop_button_Click(sender, e);
            start_button_Click(sender, e);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadStatusStrip();
            LoadConf();
        }

        private void apply_button_MouseHover(object sender, EventArgs e)
        {
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 200;
            toolTip1.ReshowDelay = 200;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(apply_button, "Only apply to current process");
        }

        private void sub_textBox_MouseClick(object sender, MouseEventArgs e)
        {
            sub_radioButton2.Checked = true;
        }

        private void rule_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = "Rule";
            if (direct_radioButton.Checked) { mode = "Direct"; }
            else if (global_radioButton.Checked) { mode = "Global"; }
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

        private void global_radioButton_CheckedChanged(object sender, EventArgs e)
        {
            mode = "Rule";
            if (direct_radioButton.Checked) { mode = "Direct"; }
            else if (global_radioButton.Checked) { mode = "Global"; }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                DialogResult dr = MessageBox.Show("Hide to system tray? \n(Click No to exit)", "Tips", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                if (dr == DialogResult.No) { Process.GetCurrentProcess().Kill(); }
                else if (dr == DialogResult.Yes)
                {
                    this.WindowState = FormWindowState.Minimized;
                    ShowInTaskbar = false;
                    this.notifyIcon1.Visible = true;
                }
            }
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                trayRightClickContextMenu.Show();
            }
            else
            {
                this.ShowInTaskbar = true;
                this.Show();
                this.WindowState = FormWindowState.Normal;
            }
        }

        private void 打开窗口ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowInTaskbar = true;
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.GetCurrentProcess().Kill();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProxiesForm pForm = new ProxiesForm();
            pForm.Show();
        }
    }
}
