using System;

namespace CrawlerANACCTAXI
{
    public class CTAXICnpj
    {
        public void GetByCnpj(string key)
        {
            Filter newFilter = new Filter();
            CnpjModel newModel = new CnpjModel();
            FormUtils newForm = new FormUtils();
            Navgator newNavgator = new Navgator();
            
            var html = string.Empty;

            newForm.formData.Add("Cnpj", key);

            html = newNavgator.NavPrincipal();
            html = newNavgator.NavCnpj(newForm.FormBuilder());

            newModel = newFilter.SyphonCnpj(html);

            var count = 0;
            Console.Clear();

            Console.WriteLine("Data da Consulta: " + newModel.DataConsulta);
            Console.WriteLine("Razão Social: " + newModel.RazaoSocial);
            Console.WriteLine("Situação: " + newModel.Situacao);
            Console.WriteLine("CNPJ: " + newModel.Cnpj);

            Console.WriteLine(string.Empty);

            foreach(var fly in newModel.Anv)
            {
                count++;

                Console.WriteLine("<<<< Aeronave " + count + " >>>>");
                Console.WriteLine("Matrícula: " + fly.Matricula);
                Console.WriteLine("Número Máximo de Passageiros: " + fly.NumeroMaximoPassageiros);

                Console.Write("Possuí Credênciamento Aerodinâmico? ");
                if (fly.CredenciadaAeromedico == true)
                {
                    Console.Write("Sim");
                }
                else
                {
                    Console.Write("Não");
                }

                Console.Write("\nPossuí Situação Aerodinâmica? ");
                if (fly.ServicoPassageiro == true)
                {
                    Console.WriteLine("Sim");
                }
                else
                {
                    Console.WriteLine("Não");
                }

                Console.Write("Habilitado para Transporte de Passageiros? ");
                if (fly.ServicoPassageiro == true)
                {
                    Console.Write("Sim");
                }
                else
                {
                    Console.Write("Não");
                }

                Console.Write("\nHabilitado para Transporte de Carga? ");
                if (fly.ServicoCarga == true)
                {
                    Console.Write("Sim");
                }
                else
                {
                    Console.Write("Não");
                }

                Console.WriteLine("\nServiço Autorizado: " + fly.PassageiroCargaSituacao + "\n");
            }

            Console.WriteLine(string.Empty);

            Console.WriteLine("Código do Certificado de Operador Aéreo: " + newModel.Cert135.Coa_num);
            Console.WriteLine("Data de Publicação do COA: " + newModel.Cert135.Coa_data_publi);
            Console.WriteLine("Data de Emissão do COA: " + newModel.Cert135.Coa_data_emi);
            Console.WriteLine("Tipo de Serviço: " + newModel.Cert135.Serv_transp);
            Console.WriteLine("Situação do Serviço: " + newModel.Cert135.Situacao);

            Console.Write("Operação Sob Demanda? ");
            if (newModel.Cert135.Op_dem == true)
            {
                Console.Write("Sim");
            }
            else
            {
                Console.Write("Não");
            }

            Console.Write("\nOperação Complementar? ");
            if (newModel.Cert135.Op_comp == true)
            {
                Console.Write("Sim");
            }
            else
            {
                Console.Write("Não");
            }

            Console.WriteLine("\nARP: " + newModel.Cert135.Arp);
        }
    }
}
