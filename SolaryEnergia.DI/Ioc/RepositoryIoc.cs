using Microsoft.Extensions.DependencyInjection;
using SolaryEnergia.Domain.Interfaces.Repositories;
using SolaryEnergia.Infra.DataBase;
using SolaryEnergia.Infra.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.DI.Ioc
{
    public static class RepositoryIoc
    {
        public static IServiceCollection RegistreReposotories( this IServiceCollection builder) 
        {
            return builder
                .AddScoped<SolaryDbContext>()
                .AddScoped<IGeracaoRepository, GeracaoRepository>()
                .AddScoped<IUnidadeRepository, UnidadeRepository>();
        }
    }
}

