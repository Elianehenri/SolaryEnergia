using SolaryEnergia.Domain.Interfaces.Repositories;
using SolaryEnergia.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.Infra.DataBase.Repositories
{
    public class GeracaoRepository : BaseRepository<Geracao, int>, IGeracaoRepository
    {
        public GeracaoRepository(SolaryDbContext context) : base(context) 
        { 
        }
    }
}
