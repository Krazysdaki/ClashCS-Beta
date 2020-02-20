using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClashCS
{
    public partial class ProxiesForm : Form
    {
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
            HttpUtils http = new HttpUtils();
            List<Proxies> plist = http.RestGet(HttpUtils.proxiesURL);
            List<List<ListViewItem>> ItemsG = new List<List<ListViewItem>>();
            List<ListViewGroup> pGroups = new List<ListViewGroup>();
            int iflag = 0;
            for (int i = 0; i < plist.Count; i++)
            {
                var nflag = plist[i].name;
                var tflag = plist[i].type;
                if (plist[i].all!=null)
                    {
                        pGroups.Add(new ListViewGroup(plist[i].name + "(" + plist[i].type + ")"));
                        listView1.Groups.Add(pGroups[iflag]);
                        for (int j = 0; j < plist[i].all.Length; j++)
                        {
                            ItemsG.Add(new List<ListViewItem>());
                            ItemsG[iflag].Add(new ListViewItem(plist[i].all[j]));
                            ItemsG[iflag][j].Group = pGroups[iflag];
                        foreach (var p in plist)
                        {
                            if(plist[i].all[j] == p.name)
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
            
        }

    }
}
