using System;
using System.IO;
using System.Net;

namespace CrawlerANACCTAXI
{
    public class Navgator
    {
        public CookieContainer Cookie = new CookieContainer();

        public string NavPrincipal()
        {
            Connect newConnect = new Connect();
            Uri url = new Uri("https://sistemas.anac.gov.br/voeseguro?AspxAutoDetectCookieSupport=0");

            newConnect.CheckStatus(url);

            var webRequest = (HttpWebRequest)WebRequest.Create(url);

            Cookie = new CookieContainer();
            webRequest.CookieContainer = Cookie;

            var webResponse = (HttpWebResponse)webRequest.GetResponse();
            var html = new StreamReader(webResponse.GetResponseStream()).ReadToEnd();

            return html;
        }

        public string NavCnpj(byte[] form)
        {
            Connect newConnect = new Connect();
            Uri url = new Uri("https://sistemas.anac.gov.br/VOESEGURO/Consulta/PesquisarCnpj");

            var html = string.Empty;

            html = newConnect.RequestPOSTCookie(url, form, Cookie);

            return html;   
        }

        public string NavMarca(byte[] form)
        {
            Connect newConnect = new Connect();
            Uri url = new Uri("https://sistemas.anac.gov.br/VOESEGURO/Consulta/PesquisarMarca");

            var html = string.Empty;

            html = newConnect.RequestPOSTCookie(url, form, Cookie);

            return html;
        }
    }
}