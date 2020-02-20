using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

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
            var logs = DeJson(_json.ToString());
            string _time = DateTime.Now.ToLongTimeString();
            ListViewItem item = new ListViewItem();
            item.Text = logs[1];
            item.SubItems.Add(_time);
            item.SubItems.Add(logs[3]);
            listView1.Items.Add(item);
        }

        static string[] DeJson(string json)
        {
            var list = json.ToList();
            Console.WriteLine(list.ToArray());
            list.Remove('{');
            list.Remove('}');
            int i = 8;
            while (i != 0)
            {
                list.Remove('\"');
                i--;
            }
            json = string.Join("", list.ToArray());
            var jsonData = json.Split(':', ',');
            return jsonData;
        }

    }
}
