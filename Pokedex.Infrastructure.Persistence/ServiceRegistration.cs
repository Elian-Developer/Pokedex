using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Infrastructure.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence
{

    //Extensions methods
    public static class ServiceRegistration
    {
        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region Context
            if (configuration.GetValue<bool>("UseInMemoryDatabase"))
            {
                services.AddDbContext<AplicationContext>(options => options.UseInMemoryDatabase("AplicationDb"));
            }
            else
            {
                services.AddDbContext<AplicationContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), 
                m => m.MigrationsAssembly(typeof(AplicationContext).Assembly.FullName)));

            }
            #endregion

            #region Repositories
            services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddTransient<IPokemonRepository, PokemonesRepository>();
            services.AddTransient<IRegionRepository, RegionRepository>();
            services.AddTransient<ITipoRepository, TipoRepository>();
            #endregion

        }
    }
}
