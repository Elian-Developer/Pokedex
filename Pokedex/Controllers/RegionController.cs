using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Region;

namespace WebApp.Pokedex.Controllers
{
    public class RegionController : Controller
    {
        private readonly IRegionService _regionService;
        
        public RegionController(IRegionService regionService)
        {
            _regionService = regionService;
        }
        public async Task <IActionResult> Index()
        {
            return View( await _regionService.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("GuardarRegion", new GuardarRegionViewModel());
        }

        [HttpPost]

        public async Task<IActionResult> Create(GuardarRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("GuardarRegion", vm);
            }

            await _regionService.Add(vm);
            return RedirectToRoute(new { Controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("GuardarRegion", await _regionService.GetByIdSaveViewModels(id));
        }

        [HttpPost]

        public async Task<IActionResult> Edit(GuardarRegionViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("GuardarRegion", vm);
            }

            await _regionService.Edit(vm);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View( await _regionService.GetByIdSaveViewModels(id));
        }

        [HttpPost]

        public async Task<IActionResult> DeletePost(int id)
        {
            await _regionService.Delete(id);
            return RedirectToRoute(new { controller = "Region", action = "Index" });
        }
    }
}
