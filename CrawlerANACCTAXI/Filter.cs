using CrawlerANACCTAXI.Model;
using Newtonsoft.Json;

namespace CrawlerANACCTAXI
{
    public class Filter
    {
        public CnpjModel SyphonCnpj(string html)
        {
            var json = @html;

            CnpjModel obj = JsonConvert.DeserializeObject<CnpjModel>(json);

            return obj;
        }

        public MarcaModel SyphonMarca(string html)
        {
            var json = @html;

            MarcaModel obj = JsonConvert.DeserializeObject<MarcaModel>(json);

            return obj;
        }
    }
}