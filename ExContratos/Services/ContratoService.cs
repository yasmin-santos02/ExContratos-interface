using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExContratos.Entities;
using Microsoft.Win32.SafeHandles;

namespace ExContratos.Services
{
    internal class ContratoService
    {
        private IPagamentoService _pagamentoService;

        public ContratoService(IPagamentoService pagamentoService)
        {
            _pagamentoService = pagamentoService;
        }

        public void ProcessamentoContrato(Contrato contrato, int parcelas) {
            double conta = contrato.valorTotal / parcelas;

            for (int i = 1; i <= parcelas; i++)
            {
                DateTime data = contrato.data.AddMonths(i);
                double updateQuota = conta + _pagamentoService.Interest(conta, i);
                double fullQuota = updateQuota + _pagamentoService.PagamentoTotal(updateQuota);
                contrato.AddPrestacoes(new Prestacoes(data, fullQuota));
            }
        }
    }
}
