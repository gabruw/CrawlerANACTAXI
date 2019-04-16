using System;
using System.Collections.Generic;

namespace CrawlerANACCTAXI
{
    public class Anv
    {
        public string Matricula { get; set; }
        public int NumeroMaximoPassageiros { get; set; }
        public object ServicoAutorizado { get; set; }
        public bool CredenciadaAeromedico { get; set; }
        public string AeromedicoSituacao { get; set; }
        public bool Cert135 { get; set; }
        public bool ServicoPassageiro { get; set; }
        public bool ServicoCarga { get; set; }
        public string PassageiroCargaSituacao { get; set; }
    }

    public class Cert135
    {
        public int Empresa_id { get; set; }
        public object Las { get; set; }
        public string Arp { get; set; }
        public string Situacao { get; set; }
        public string Coa_num { get; set; }
        public DateTime Coa_data_publi { get; set; }
        public DateTime Coa_data_emi { get; set; }
        public string Coa_link { get; set; }
        public bool Op_dem { get; set; }
        public bool Op_comp { get; set; }
        public string Serv_transp { get; set; }
    }

    public class CnpjModel
    {
        public DateTime DataConsulta { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Situacao { get; set; }
        public IList<Anv> Anv { get; set; }
        public Cert135 Cert135 { get; set; }
    }
}