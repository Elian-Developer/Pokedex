using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Pokemones;
using Pokedex.Infrastructure.Persistence.Contexts;
using Pokedex.Models;
using System.Diagnostics;

namespace Pokedex.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPokemonService _pokemonservices;
        private readonly IRegionService _regionservices;

        public HomeController(IPokemonService pokemonService, IRegionService regionservices)
        {
            _pokemonservices = pokemonService;
            _regionservices = regionservices;
        }

        public async Task <IActionResult> Index(FilterPokemonsViewModel vm)
        {

            ViewBag.Regions = await _regionservices.GetAllViewModel();
            return View( await _pokemonservices.GetAllViewModelWithFilters(vm));
        }


    }
}