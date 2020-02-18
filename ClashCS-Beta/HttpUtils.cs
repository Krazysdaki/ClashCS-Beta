using System.Net;
using System.IO;
using System;

namespace ClashCS
{
    public class HttpUtils
    {
        public static string Start(string url, string path)
        {
            // 设置参数
            HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //发送请求并获取相应回应数据
            HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //直到request.GetResponse()程序才开始向目标网页发送Post请求
            Stream responseStream = response.GetResponseStream();
            //创建本地文件写入流
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
            return "Download Success!";
        }

        public void RestGet()
        {
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(LogsForm.URL);
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
    }
}
