using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.ViewModels.Pokemones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IPokemonService : IGenericService<GuardarPokemonesViewModels, PokemonesViewModels>
    {
        Task<List<PokemonesViewModels>> GetAllViewModelWithFilters(FilterPokemonsViewModel filters);
    }
}
