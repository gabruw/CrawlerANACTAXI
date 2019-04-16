using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrawlerANACCTAXI
{
    public class FormUtils
    {
        public Dictionary<string, string> formData = new Dictionary<string, string>();

        public byte[] FormBuilder()
        {
            var form = string.Empty;
            var count = 0;

            foreach (var data in formData)
            {
                if (count == 0 || formData.Count - count == 0)
                {
                    form += String.Format("{0}={1}", data.Key, data.Value);
                }else{
                    form += String.Format("{0}={1}&", data.Key, data.Value);
                }

                count++;
            }

            var formEncode = Encoding.ASCII.GetBytes(form);

            return formEncode;
        }
    }
}