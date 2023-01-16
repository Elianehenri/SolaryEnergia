using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Interfaces.Services
{
    public interface IUnidadeService
    {
        IList<UnidadeDto> Get();
        UnidadeDto GetById(int id);
        void Post(UnidadeDto unidade);
        void Put(UnidadeDto unidade);
        void Delete(int id);
    }
}
