using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CrawlerANACCTAXI
{
    public class Connect
    {
        public void CheckStatus(Uri url)
        {
            var networkStatus = System.Net.NetworkInformation.NetworkInterface.GetIsNetworkAvailable();
            if (networkStatus != true)
            {
                throw new Exception("Erro ao conectar, verifique sua rede.");
            }

            var verifyStatusRequest = (HttpWebRequest)WebRequest.Create(url);
            verifyStatusRequest.AllowAutoRedirect = false;
            verifyStatusRequest.Method = "HEAD";

            using (var response = verifyStatusRequest.GetResponse() as HttpWebResponse)
            {
                var siteStatus = response.StatusCode;
                response.Close();

                switch (siteStatus)
                {
                    case HttpStatusCode.OK:
                    case HttpStatusCode.Found:
                        break;
                    default:
                        throw new Exception();
                }
            }
        }

        public string RequestPOSTCookie(Uri url, byte[] form, CookieContainer cookie) {
            var html = string.Empty;

            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            webRequest.Method = "POST";
            webRequest.ContentType = "application/x-www-form-urlencoded";
            webRequest.CookieContainer = cookie;
            webRequest.AllowAutoRedirect = false;
            webRequest.ContentLength = form.Length;

            using (var stream = webRequest.GetRequestStream())
            {
                stream.Write(form, 0, form.Length);
            }

            var webResponse = (HttpWebResponse)webRequest.GetResponse();

            html = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

            return html;
        }
    }
}