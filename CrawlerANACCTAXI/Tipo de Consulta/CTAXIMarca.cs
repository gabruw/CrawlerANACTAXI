using CrawlerANACCTAXI.Model;
using System;

namespace CrawlerANACCTAXI.Tipo_de_Consulta
{
    public class CTAXIMarca
    {
        public void GetByMarca(string key)
        {
            Filter newFilter = new Filter();
            FormUtils newForm = new FormUtils();
            Navgator newNavgator = new Navgator();
            MarcaModel newModel = new MarcaModel();

            var html = string.Empty;

            newForm.formData.Add("Marca", key);

            html = newNavgator.NavPrincipal();
            html = newNavgator.NavMarca(newForm.FormBuilder());

            newModel = newFilter.SyphonMarca(html);

            var count = 0;
            Console.Clear();

            if (newModel.Empresas != null)
            {
                Console.WriteLine("Data da Consulta: " + newModel.DataConsulta);
                Console.WriteLine("Matrícula: " + newModel.Matricula);
                Console.WriteLine("Situação: " + newModel.Situacao);
                Console.WriteLine("Número Maximo de Passageiros: " + newModel.NumeroMaximoPassageiros);

                Console.Write("Possuí Credênciamento Aerodinâmico? ");
                if (newModel.CredenciadaAeromedico == true)
                {
                    Console.Write("Sim");
                }
                else
                {
                    Console.Write("Não");
                }

                Console.WriteLine("\nSituação do Credênciamento Aerodinâmico: " + newModel.AeromedicoSituacao);

                Console.WriteLine(string.Empty);


                if (newModel.Empresas.Count > 1)
                {
                    foreach (var emp in newModel.Empresas)
                    {
                        Console.WriteLine("Razão Social: " + emp.RazaoSocial);
                        Console.WriteLine("Nome Fantasia: " + emp.NomeFantasia);
                        Console.WriteLine("Trigrama: " + emp.Trigrama);
                        Console.WriteLine("CNPJ: " + emp.Cnpj);
                        Console.WriteLine("Situação: " + emp.Situacao);
                    }
                }
                else
                {
                    Console.WriteLine("Razão Social: " + newModel.Empresa.RazaoSocial);
                    Console.WriteLine("Nome Fantasia: " + newModel.Empresa.NomeFantasia);
                    Console.WriteLine("Trigrama: " + newModel.Empresa.Trigrama);
                    Console.WriteLine("CNPJ: " + newModel.Empresa.Cnpj);
                    Console.WriteLine("Situação: " + newModel.Empresa.Situacao);
                }

                Console.WriteLine(string.Empty);

                Console.WriteLine("Código do Certificado de Operador Aéreo: " + newModel.Empresa.Cert135.Coa_num);
                Console.WriteLine("Data de Publicação do COA: " + newModel.Empresa.Cert135.Coa_data_publi);
                Console.WriteLine("Data de Emissão do COA: " + newModel.Empresa.Cert135.Coa_data_emi);
                Console.WriteLine("Tipo de Serviço: " + newModel.Empresa.Cert135.Serv_transp);
                Console.WriteLine("Situação do Serviço: " + newModel.Empresa.Cert135.Situacao);

                Console.Write("Operação Sob Demanda? ");
                if (newModel.Empresa.Cert135.Op_dem == true)
                {
                    Console.Write("Sim");
                }
                else
                {
                    Console.Write("Não");
                }

                Console.Write("\nOperação Complementar? ");
                if (newModel.Empresa.Cert135.Op_comp == true)
                {
                    Console.Write("Sim");
                }
                else
                {
                    Console.Write("Não");
                }

                Console.WriteLine("\nARP: " + newModel.Empresa.Cert135.Arp);
            }
            else
            {
                Console.WriteLine("A Chave não existe...");
            }
        }
    }
}