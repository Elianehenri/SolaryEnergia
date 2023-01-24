using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Exceptions
{
   public class UserJaCadastradoException:Exception
    {
        public UserJaCadastradoException(string erro) : base(erro)
        {
        }
    }
}
