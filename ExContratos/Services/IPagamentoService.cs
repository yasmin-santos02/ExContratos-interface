using System;

namespace ExContratos.Services
{
    interface IPagamentoService
    {
        double PagamentoTotal(double amount);
        double Interest(double amount, int months);
    }
}
