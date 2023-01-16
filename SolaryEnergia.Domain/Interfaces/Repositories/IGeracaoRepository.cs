using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Interfaces.Repositories
{
    public interface IGeracaoRepository
    {
        IList<Geracao> Get();
        Geracao GetById(int id);
        void Post(Geracao geracao);
        void Delete(Geracao geracao);
        void Put(Geracao geracao);
       //void Update(Geracao geracao);
    }
}
