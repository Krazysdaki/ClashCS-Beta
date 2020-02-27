using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using static ClashCS.ProxiesForm;

namespace ClashCS
{
    public class HttpUtils
    {
        public static string IP = "http://127.0.0.1";
        public static string PORT = "9090";
        public static string logURL = IP + ":" + PORT + "/logs";
        public static string configsURL = IP + ":" + PORT + "/configs";
        public static string proxiesURL = IP + ":" + PORT + "/proxies";
        public static string trafficURL = IP + ":" + PORT + "/traffic";

        public static string Start(string url, string path)
        {
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            Stream responseStream = response.GetResponseStream();
            Stream stream = new FileStream(path, FileMode.Create);
            byte[] bArr = new byte[1024];
            int size = responseStream.Read(bArr, 0, (int)bArr.Length);
            while (size > 0)
            {
                stream.Write(bArr, 0, size);
                size = responseStream.Read(bArr, 0, (int)bArr.Length);
            }
            stream.Close();
            responseStream.Close();
            FileInfo mmdb = new FileInfo(path);
            if (mmdb.Exists)
            {
            return "Download Success!";
            }
            else
            {
                return "Download Error!\nPlease manually download it.";
            }
        }

        public void RestGetStream()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(logURL);
                request.Method = "Get";
                request.ContentLength = 0;
                request.ContentType = "application/json";
                var response = (HttpWebResponse)request.GetResponse();
                var responseStream = response.GetResponseStream();
                var sr = new StreamReader(responseStream);
                while (responseStream != null)
                {
                    object _json = sr.ReadLine();
                    LogsForm.context.Send(LogsForm.AddLog, _json);
                }
                object noLog = "Stream is empty!";
                LogsForm.context.Send(LogsForm.AddLog, noLog);
            }
            catch
            {
                return;
            }
        }

        public void RestGetStream(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            var sr = new StreamReader(responseStream);
            while (responseStream != null)
            {
                try
                {
                    var _json = sr.ReadLine();
                    var _list = _json.ToList();
                    _list.Remove('{');
                    _list.Remove('}');
                    _json = string.Join("", _list.ToArray());
                    var _d = _json.Split(',', ':');
                    object s = ((double)(int.Parse(_d[1]) / 1000)).ToString() + ',' + ((double)(int.Parse(_d[3]) / 1000)).ToString();

                    MainForm.cntx.Send(MainForm.SetUpDown, s);
                }
                catch { return; }
            }
            try { MainForm.cntx.Send(MainForm.SetUpDown, "0,0"); }
            catch { return; }
        }

        public string[] RestGetConf(string url)
        {
            if (MainForm.runningFlag == 0)
            {
                return new string[] { "", "", "", "", ""};
            }
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            var sr = new StreamReader(responseStream);
            var _json = sr.ReadToEnd();
            var list = _json.ToList();
            list.Remove('{');
            list.Remove('}');
            int i = 22;
            while (i != 0)
            {
                list.Remove('\"');
                i--;
            }
            _json = string.Join("", list.ToArray());
            var _d = _json.Split(':', ',');
            return new string[] { _d[1], _d[3], _d[5], _d[9], _d[13] }; //port sport rport allowlan mode            
        }

        public void RestPatch(MainForm.Configs _c)
        {
            string postData = "{\"port\":" + _c.port + ", \"socks-port\":" + _c.sport + ", \"redir-port\":" + _c.rport + ", \"allow-lan\":" + _c.lan + ", \"mode\":" + "\"" + _c.mode + "\"}";
            //MessageBox.Show(postData);
            var encoding = new UTF8Encoding();
            var bytes = Encoding.GetEncoding("utf-8").GetBytes(postData);
            var request = (HttpWebRequest)WebRequest.Create(configsURL);
            request.Method = "PATCH";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/json";
            try
            {
                var writeStream = request.GetRequestStream();
                writeStream.Write(bytes, 0, bytes.Length);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.ToString());
            }
            
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                var responseValue = string.Empty;

                if (response.StatusCode != HttpStatusCode.NoContent)
                {
                    var message = string.Format("Request failed. Received HTTP {0}", response.StatusCode);
                    MessageBox.Show(message);
                    throw new ApplicationException(message);
                }
                else MessageBox.Show("Apply complete!", "Tips", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        public List<Proxies> RestGet(string url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "Get";
            request.ContentLength = 0;
            request.ContentType = "application/json";
            var response = (HttpWebResponse)request.GetResponse();
            var responseStream = response.GetResponseStream();
            var sr = new StreamReader(responseStream);
            var _json =  sr.ReadToEnd();
            var occ = (JObject.Parse(_json).SelectToken("proxies").Children()).Children();
            List<Proxies> list = new List<Proxies>();
            foreach (var p in occ)
            {
                var proxies = JsonConvert.DeserializeObject<Proxies>(p.ToString());
                list.Add(proxies);
            }
            return list;
        }

        public void RestPut(string[] _p)
        {
            string postData = "{\"name\":" + "\"" + _p[1] + "\"}";
            //MessageBox.Show(postData);
            var encoding = new UTF8Encoding();
            var bytes = Encoding.GetEncoding("utf-8").GetBytes(postData);
            var request = (HttpWebRequest)WebRequest.Create(proxiesURL + "/" + _p[0]);
            //MessageBox.Show(configsURL + "/" + _p[0]);
            request.ProtocolVersion = new Version("1.0");
            request.Method = "PUT";
            request.ContentLength = bytes.Length;
            request.ContentType = "application/json";
            var writeStream = request.GetRequestStream();
            writeStream.Write(bytes, 0, bytes.Length);
            writeStream.Flush();
            try
            {
              var response = (HttpWebResponse)request.GetResponse();
              //MessageBox.Show(response.StatusCode.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }            
            request.Abort();
        }
    }
}