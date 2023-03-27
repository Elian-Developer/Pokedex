using Microsoft.EntityFrameworkCore;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Domain.Entities;
using Pokedex.Infrastructure.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Infrastructure.Persistence.Repositories
{
    public class PokemonesRepository : GenericRepository<Pokemones>, IPokemonRepository
    {
        private readonly AplicationContext _dbContext;

        public PokemonesRepository(AplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

    }
}
