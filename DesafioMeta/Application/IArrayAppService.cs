using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioMeta.Application
{
    public interface IArrayAppService
    {
        List<int> ObterIndiceDoArray(int numeroAlvo)

        string Brackets(string brackets);

        string CompraVendaAcoes(string codigoUsuario, int dia);

        int CalcularAguaRetida(int?[] numeros);
    }
}
