using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {
            #region Services
            services.AddTransient<IPokemonService, PokemonesServices>();
            services.AddTransient<IRegionService, RegionServices>();
            services.AddTransient<ITipoService, TipoServices>();
            #endregion
        }
    }
}
