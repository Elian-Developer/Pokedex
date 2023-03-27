using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.Services;
using Pokedex.Core.Application.ViewModels.Pokemones;

namespace WebApp.Pokedex.Controllers
{
    public class PokemonesController : Controller
    {
        private readonly IPokemonService _pokemonService;
        private readonly IRegionService _regionService;
        private readonly ITipoService _tipoService;

        public PokemonesController(IPokemonService pokemonservice, IRegionService regionService,
            ITipoService tipoService)
        {
            _pokemonService = pokemonservice;
            _regionService = regionService;
            _tipoService = tipoService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _pokemonService.GetAllViewModel());
        }

        public async Task<IActionResult> Create()
        {
            GuardarPokemonesViewModels vm = new();
            vm.Regions = await _regionService.GetAllViewModel();
            vm.Types = await _tipoService.GetAllViewModel();
            return View("GuardarPokemon", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Create(GuardarPokemonesViewModels vm)
        {

            if (!ModelState.IsValid)
            {
                vm.Regions = await _regionService.GetAllViewModel();
                vm.Types = await _tipoService.GetAllViewModel();
                return View("GuardarPokemon", vm);
            }

            await _pokemonService.Add(vm);
            return RedirectToRoute(new { controller = "Pokemones", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            GuardarPokemonesViewModels vm = await _pokemonService.GetByIdSaveViewModels(id);
            vm.Regions = await _regionService.GetAllViewModel();
            vm.Types = await _tipoService.GetAllViewModel();
            return View("GuardarPokemon", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GuardarPokemonesViewModels vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Regions = await _regionService.GetAllViewModel();
                vm.Types = await _tipoService.GetAllViewModel();
                return View("GuardarPokemon", vm);
            }

            await _pokemonService.Edit(vm);
            return RedirectToRoute(new { controller = "Pokemones", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View(await _pokemonService.GetByIdSaveViewModels(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _pokemonService.Delete(id);
            return RedirectToRoute(new { controller = "Pokemones", action = "Index" });
        }
    }
}
