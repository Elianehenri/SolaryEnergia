using Microsoft.Extensions.DependencyInjection;
using SolaryEnergia.Domain.Interfaces.Repositories;
using SolaryEnergia.Domain.Interfaces.Services;
using SolaryEnergia.Domain.Services;
using SolaryEnergia.Infra.DataBase.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolaryEnergia.DI.Ioc
{
    public static class ServiceIoc
    {
        public static IServiceCollection RegistreServices(this IServiceCollection builder)
        {
            return builder
               .AddScoped<IGeracaoService, GeracaoService>()
               .AddScoped<IUnidadeService, UnidadeService>()
               .AddScoped<IUserService, UserService>();

        }
    }
}
