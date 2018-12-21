using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Web;
using System.Net;
using System.Media;
using System.Windows.Input;
using System.Windows;

namespace BasicInfo
{
    public class IdentifyMessage
    {
        private static string mobile;

        public string Mobile
        {
            get { return mobile; }

            set { mobile = this.Mobile; }
        }
        static void Main(string[] args)
        {
            //账号
            string account = "xxxxxxxxxxxxxxxxxxxxxxx";
            //密码
            string pswd = "xxxxxxxxxxxxxxxxxxxxxxx";
            //修改为您要发送的手机号
            mobile = "xxxxxxxxxxxxxxxxxxxxxxx";
            // 短信发送接口的http地址，请咨询客服
            string url = "xxxxxxxxxxxxxxxxx";

            // 发验短信调用示例
            // 发送内容
            string msg = "";
            string data = "account=" + account + "&pswd=" + pswd + "&mobile=" + mobile + "&msg=" + msg + "&needstatus=true";
            HttpPost(url, data);
        }
        public static void HttpPost(string Url, string postDataStr)
        {
            byte[] dataArray = Encoding.UTF8.GetBytes(postDataStr);
            // Console.Write(Encoding.UTF8.GetString(dataArray));
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataArray.Length;
            //request.CookieContainer = cookie;
            Stream dataStream = request.GetRequestStream();
            dataStream.Write(dataArray, 0, dataArray.Length);
            dataStream.Close();
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String res = reader.ReadToEnd();
                reader.Close();
                MessageBox.Show("\nResponse Content:\n" + res + "\n");
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message + e.ToString());
            }
        }
    }
}
