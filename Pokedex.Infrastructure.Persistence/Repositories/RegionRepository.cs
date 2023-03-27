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
    public class RegionRepository : GenericRepository<Region>, IRegionRepository 
    {
        private readonly AplicationContext _dbContext;

        public RegionRepository(AplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
