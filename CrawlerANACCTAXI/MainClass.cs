using CrawlerANACCTAXI.Tipo_de_Consulta;
using System;

namespace CrawlerANACCTAXI
{
    public class MainClass
    {
        public static void Main(string[] args)
        {
            CTAXICnpj newCnpj = new CTAXICnpj();
            CTAXIMarca newMarca = new CTAXIMarca();

            var op = 0;
            var key = string.Empty;
            Console.WriteLine("Selecione um tipo de pesquisa:");
            Console.WriteLine("1- Por Cnpj");
            Console.WriteLine("2- Por Marca");
            Console.Write("->> ");
            op = Convert.ToInt16(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Informe a informação de consulta:");
            Console.Write("->> ");
            key = Console.ReadLine();

            if (op == 1)
            {
                newCnpj.GetByCnpj(key);
            }
            else
            {
                newMarca.GetByMarca(key);
            }

            Console.ReadKey();
        }
    }
}
