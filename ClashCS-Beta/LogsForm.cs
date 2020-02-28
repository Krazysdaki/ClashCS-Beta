using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace ClashCS
{
    public partial class LogsForm : Form
    {
        public static Form FormFlag;
        public static SynchronizationContext context;

        public LogsForm()
        {
            DrawLogsForm();
            context = SynchronizationContext.Current;
            HttpUtils http = new HttpUtils();
            Thread addLog = new Thread(new ThreadStart(http.RestGetStream));
            addLog.IsBackground = true;
            addLog.Start();
        }

        public static void AddLog(object _json)
        {
            JObject j = JObject.Parse(_json.ToString());
            string _time = DateTime.Now.ToLongTimeString();
            ListViewItem item = new ListViewItem();
            item.Text = j["type"].ToString();
            item.SubItems.Add(_time);
            item.SubItems.Add(j["payload"].ToString());
            listView1.Items.Add(item);
        }

    }
}
