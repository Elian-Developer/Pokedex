using Microsoft.AspNetCore.Mvc;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Tipo;

namespace WebApp.Pokedex.Controllers
{
    public class TipoController : Controller
    {
        private readonly ITipoService _tipoServices;

        public TipoController(ITipoService tipoServices)
        {
            _tipoServices = tipoServices;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _tipoServices.GetAllViewModel());
        }

        public IActionResult Create()
        {
            return View("GuardarTipo", new GuardarTipoViewModel());
        }

        [HttpPost]

        public async Task<IActionResult> Create(GuardarTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("GuardarTipo", vm);
            }

            await _tipoServices.Add(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> Edit(int id)
        {
            return View("GuardarTipo", await _tipoServices.GetByIdSaveViewModels(id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(GuardarTipoViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("GuardarTipo", vm);
            }

            await _tipoServices.Edit(vm);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }

        public async Task<IActionResult> Delete(int id)
        {
            return View("Delete", await _tipoServices.GetByIdSaveViewModels(id));
        }

        [HttpPost]
        public async Task<IActionResult> DeletePost(int id)
        {
            await _tipoServices.Delete(id);
            return RedirectToRoute(new { controller = "Tipo", action = "Index" });
        }
    }
}
