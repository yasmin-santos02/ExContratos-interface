using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExContratos.Entities
{
    internal class Contrato
    {
        public int numero { get; set; }
        public DateTime data { get; set; }
        public double valorTotal { get; set; }
        public List<Prestacoes> Prestacoes { get; set; }

        public Contrato(int numero, DateTime data, double valorTotal)
        {
            this.numero = numero;
            this.data = data;
            this.valorTotal = valorTotal;
            Prestacoes = new List<Prestacoes>();
        }

        public void AddPrestacoes(Prestacoes prestacoes)
        {
            Prestacoes.Add(prestacoes);
        }
    }
}
