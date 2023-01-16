using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Interfaces.Repositories
{
    public interface IUnidadeRepository
    {
        IList<Unidade> Get();
        Unidade GetById(int id);
        void Post(Unidade unidade);
        void Put(Unidade unidade);
        void Delete(Unidade unidade);
    }
}
