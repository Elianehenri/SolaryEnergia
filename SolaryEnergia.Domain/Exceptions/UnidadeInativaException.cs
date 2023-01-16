using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Exceptions
{
    public class UnidadeInativaException : Exception
    {
        public UnidadeInativaException(string erro) : base(erro)
        {

        }

    }
}
