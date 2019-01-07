using CloudFlareUtilities;
using HtmlAgilityPack;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProxyScraper
{
    public partial class Form1 : Form
    {
        const string url = "https://hidemyna.me/en/proxy-list/?country=FRDENL&type=s#list";
        List<string> ipList = new List<string>();
        bool isFirstLogin = true;
        bool isProxyChanged = false;
        BackgroundWorker bgw = new BackgroundWorker();


        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            bgw.DoWork += Bgw_DoWork;
        }

        private void Bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                if (isFirstLogin)
                {
                    var target = new Uri(url);
                    var handler = new ClearanceHandler();
                    handler.MaxRetries = 20;
                    var client = new HttpClient(handler);
                    var rawHtml = client.GetStringAsync(target).Result;
                    HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
                    document.LoadHtml(rawHtml);
                    var table = document.DocumentNode.SelectNodes("//table[@class='proxy__t']//tbody/tr");
                    foreach (HtmlNode item in table)
                    {
                        HtmlNode ipTd = item.ChildNodes.FirstOrDefault(x => x.HasClass("tdl"));
                        string port = ipTd.NextSibling.InnerText;

                        if (ipTd != null)
                        {
                            ipList.Add(ipTd.InnerText + ":" + port);
                        }
                    }
                    isFirstLogin = false;
                }
                ChangeProxy();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (bgw.IsBusy)
            {
                MessageBox.Show("Proxy Changer zaten çalışıyor.");
                return;
            }
            bgw.RunWorkerAsync();
        }

        //private bool ProxyChecker()
        //{
        //    ServicePointManager.SecurityProtocol = SecurityProtocolType.Ssl3 | SecurityProtocolType.Tls | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls12;

        //    bool isAvailable = false;
        //    try
        //    {
        //        foreach (string item in ipList)
        //        {
        //            string rawHtml = string.Empty;
        //            WebProxy proxy = new WebProxy("62.210.177.105:3128");
        //            proxy.BypassProxyOnLocal = false;
        //            proxy.UseDefaultCredentials = false;
        //            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://www.wikipedia.org");
        //            proxy.Credentials = req.Credentials;
        //            req.MaximumAutomaticRedirections = 999;
        //            req.Proxy = proxy;
        //            req.CookieContainer = new CookieContainer();
        //            req.Method = "GET";
        //            req.UserAgent = "Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/70.0.3538.102 Safari/537.36 OPR/57.0.3098.106";
        //            using (WebResponse response = req.GetResponse())
        //            {
        //                using (Stream stream = response.GetResponseStream())
        //                {
        //                    StreamReader reader = new StreamReader(stream);
        //                    rawHtml = reader.ReadToEnd();
        //                }
        //            }
        //            if (rawHtml != "")
        //            {
        //                isAvailable = true;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return isAvailable;
        //    }
        //    return isAvailable;
        //}

        private void ChangeProxy()
        {
            try
            {
                if (isProxyChanged == false)
                {
                    Random rnd = new Random();
                    string key = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
                    string proxy = ipList[rnd.Next(0, ipList.Count)];
                    RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(key, true);
                    RegKey.SetValue("ProxyServer", proxy);
                    RegKey.SetValue("ProxyEnable", 1);
                    MessageBox.Show("Proxy ayarlarınız başarı ile değiştirildi.");
                    isProxyChanged = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proxy değiştirme esnasında bir hata oluştu.");
            }
        }

        private void btnSetDefaultProxySettings_Click(object sender, EventArgs e)
        {
            try
            {
                if (bgw.IsBusy)
                {
                    MessageBox.Show("Proxy Changer çalışmasını bitirmeden ayarları sıfırlayamazsınız.");
                    return;
                }
                if (isProxyChanged == true)
                {
                    Random rnd = new Random();
                    string key = "Software\\Microsoft\\Windows\\CurrentVersion\\Internet Settings";
                    string proxy = "";
                    RegistryKey RegKey = Registry.CurrentUser.OpenSubKey(key, true);
                    RegKey.SetValue("ProxyServer", proxy);
                    RegKey.SetValue("ProxyEnable", 0);
                    MessageBox.Show("Proxy başarı ile sıfırlandı.");
                    isProxyChanged = true;
                }
                else
                {
                    MessageBox.Show("Proxy ayarlarınız zaten varsayılan değerlere sahip.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proxy değiştirme esnasında bir hata oluştu.");
            }
        }
    }
}
