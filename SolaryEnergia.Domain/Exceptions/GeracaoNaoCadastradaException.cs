using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Exceptions
{
    public class GeracaoNaoCadastradaException : Exception
    {
        public GeracaoNaoCadastradaException(string erro) : base(erro)
        {
        }
    }
}
