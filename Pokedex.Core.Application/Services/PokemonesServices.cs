using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Pokemones;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class PokemonesServices : IPokemonService
    {
        private readonly IPokemonRepository _pokemonRepository;

        public PokemonesServices(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public async Task Add(GuardarPokemonesViewModels vm)
        {
            Pokemones pokemones = new();
            pokemones.Id = vm.Id;
            pokemones.Name = vm.Name;
            pokemones.ImageUrl = vm.ImageUrl;
            pokemones.TipoPrimarioId = vm.TipoPrimarioId;
            pokemones.TipoSecundarioId = vm.TipoSecundarioId;
            pokemones.RegionId = vm.RegionId;
            await _pokemonRepository.AddAsync(pokemones);
        }

        public async Task Edit(GuardarPokemonesViewModels vm)
        {
            Pokemones pokemones = new();
            pokemones.Id = vm.Id;
            pokemones.Name = vm.Name;
            pokemones.ImageUrl = vm.ImageUrl;
            pokemones.TipoPrimarioId = vm.TipoPrimarioId;
            pokemones.TipoSecundarioId = vm.TipoSecundarioId;
            pokemones.RegionId = vm.RegionId;
            await _pokemonRepository.EditAsync(pokemones);
        }

        public async Task Delete(int id)
        {
            var pokemon = await _pokemonRepository.GetByIdAsync(id);
            await _pokemonRepository.DeleteAsync(pokemon);
        }

        public async Task<List<PokemonesViewModels>> GetAllViewModel()
        {
            var PokemonesList = await _pokemonRepository.GetAllWithIncludeAsync(new List<string> {"Tipo", "Region"});
            return PokemonesList.Select(pokemones => new PokemonesViewModels
            {
                Name = pokemones.Name,
                ImageUrl = pokemones.ImageUrl,
                Id = pokemones.Id,
                RegionId = pokemones.RegionId,
                TipoPrimarioId = pokemones.TipoPrimarioId,
                TipoSecundarioId = pokemones.TipoSecundarioId,
                Tipo = pokemones.Tipo.Name,
                Region = pokemones.Region.Name

            }).ToList();
        }

        public async Task<List<PokemonesViewModels>> GetAllViewModelWithFilters(FilterPokemonsViewModel filters)
        {
            var PokemonesList = await _pokemonRepository.GetAllWithIncludeAsync(new List<string> { "Tipo", "Region" });

            var ListViewModels = PokemonesList.Select(pokemones => new PokemonesViewModels
            {
                Name = pokemones.Name,
                ImageUrl = pokemones.ImageUrl,
                Id = pokemones.Id,
                RegionId = pokemones.RegionId,
                TipoPrimarioId = pokemones.TipoPrimarioId,
                TipoSecundarioId = pokemones.TipoSecundarioId,
                Tipo = pokemones.Tipo.Name,
                Region = pokemones.Region.Name

            }).ToList();

            if(filters.RegionId != null)
            {
                ListViewModels = ListViewModels.Where(pokemon => pokemon.RegionId == filters.RegionId.Value).ToList();
            } 
            else if (filters.PokemonName != null)
            {
                ListViewModels = ListViewModels.Where(pokemon => pokemon.Name == filters.PokemonName).ToList();
            }

            return ListViewModels;
        }

        public async Task<GuardarPokemonesViewModels> GetByIdSaveViewModels(int id)
        {
            var Pokemones = await _pokemonRepository.GetByIdAsync(id);

            GuardarPokemonesViewModels vm = new();

            vm.Id = Pokemones.Id;
            vm.Name = Pokemones.Name;
            vm.ImageUrl = Pokemones.ImageUrl;
            vm.TipoPrimarioId = Pokemones.TipoPrimarioId;
            vm.TipoSecundarioId = Pokemones.TipoSecundarioId;
            vm.RegionId = Pokemones.RegionId;

            return vm;
        }

    }
}
