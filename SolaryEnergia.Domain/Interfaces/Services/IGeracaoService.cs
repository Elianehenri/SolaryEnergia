using SolaryEnergia.Domain.DTOs;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Domain.Interfaces.Services
{
    public interface IGeracaoService
    {
        IList<GeracaoDto> Get();
        GeracaoDto GetById(int id);
        void Post(GeracaoDto geracao);
        void Put(GeracaoDto geracao);
        void Delete(int id);
    }
}
