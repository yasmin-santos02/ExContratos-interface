using System.Diagnostics.Contracts;
using System.Globalization;
using ExContratos.Entities;
using ExContratos.Services;

namespace ExContratos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Entre com os dados do contrato: ");
            Console.Write("Número: ");
            int numC = int.Parse(Console.ReadLine());

            Console.Write("Data (dd/MM/yyyy): ");
            DateTime data = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);

            Console.Write("Valor do contrato: ");
            double valor = double.Parse(Console.ReadLine());

            Console.Write("Número de parcelas: ");
            int parcelas = int.Parse(Console.ReadLine());

            Contrato myContract = new Contrato(numC, data, valor);

            ContratoService contractService = new ContratoService(new PaypalService());
            contractService.ProcessamentoContrato(myContract, parcelas);

            Console.WriteLine("Prestações:");
            foreach (Prestacoes installment in myContract.Prestacoes)
            {
                Console.WriteLine(installment);
            }
        }
    }
}