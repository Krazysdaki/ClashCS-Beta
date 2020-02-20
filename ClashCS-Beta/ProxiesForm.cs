using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashCS
{
    public partial class ProxiesForm : Form
    {
        List<List<ListViewItem>> ItemsG = new List<List<ListViewItem>>();
        List<ListViewGroup> pGroups = new List<ListViewGroup>();

        public ProxiesForm()
        {         
            InitializeComponent();
            SetProxies();
        }

        public class Proxies
        {
            public Proxies(object history, string name, string type, string[] all, string now)
            {
                this.history = history;
                this.name = name;
                this.type = type;
                this.all = all;
                this.now = now;
            }
            public object history;
            public string name;
            public string type;
            public string[] all;
            public string now;
        }

        private void SetProxies()
        {
            if (MainForm.runningFlag == 0)
            {
                return;
            }
            HttpUtils http = new HttpUtils();
            List<Proxies> plist = http.RestGet(HttpUtils.proxiesURL);
            int iflag = 0;
            for (int i = 0; i < plist.Count; i++)
            {
                if (plist[i].all != null)
                {
                    pGroups.Add(new ListViewGroup(plist[i].name + "(" + plist[i].type + ")"));
                    listView1.Groups.Add(pGroups[iflag]);
                    if (plist[i].type == "Selector")
                    {
                        comboBox1.Items.Add(plist[i].name);
                    }
                    for (int j = 0; j < plist[i].all.Length; j++)
                    {
                        ItemsG.Add(new List<ListViewItem>());
                        ItemsG[iflag].Add(new ListViewItem(plist[i].all[j]));
                        ItemsG[iflag][j].Group = pGroups[iflag];
                        foreach (var p in plist)
                        {
                            if (plist[i].all[j] == p.name)
                            {
                                ItemsG[iflag][j].SubItems.Add(p.type);
                            }
                        }
                        if (plist[i].now == ItemsG[iflag][j].Text)
                        {
                            ItemsG[iflag][j].SubItems.Add("Using");
                        }
                        listView1.Items.Add(ItemsG[iflag][j]);
                    }
                    iflag++;
                }
            }
            comboBox1.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBox1.AutoCompleteMode = AutoCompleteMode.SuggestAppend;           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox2.Items.Clear();
            foreach (var i in ItemsG)
            {
                foreach (var j in i)
                {
                    var s = j.Group.Header.Split('(');
                    if (s[0] == comboBox1.Text)
                    {
                        comboBox2.Items.Add(j.Text);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            HttpUtils http = new HttpUtils();
            http.RestPut(new string[] { comboBox1.Text, comboBox2.Text });
            MessageBox.Show("Succcess!\nReopen Proxies panel to see changes.", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

    }
}
