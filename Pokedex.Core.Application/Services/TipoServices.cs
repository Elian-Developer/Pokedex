using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Tipo;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class TipoServices : ITipoService
    {
        private readonly ITipoRepository _tipoRepository;

        public TipoServices(ITipoRepository tipoRepository)
        {
            _tipoRepository = tipoRepository;
        }

        public async Task Add(GuardarTipoViewModel vm)
        {
            Tipo tipo = new(); 
            tipo.Name = vm.Name;

            await _tipoRepository.AddAsync(tipo);
        }

        public async Task Edit(GuardarTipoViewModel vm)
        {
            Tipo tipo = new();
            tipo.Id = vm.Id;
            tipo.Name = vm.Name;

            await _tipoRepository.EditAsync(tipo);
        }

        public async Task Delete(int id)
        {
            var Tipo = await _tipoRepository.GetByIdAsync(id);
            await _tipoRepository.DeleteAsync(Tipo);
        }

        public async Task<GuardarTipoViewModel> GetByIdSaveViewModels(int id)
        {
            var Tipo = await _tipoRepository.GetByIdAsync(id);

            GuardarTipoViewModel vm = new();
            vm.Id = Tipo.Id; 
            vm.Name = Tipo.Name;

            return vm;
            
        }


        public async Task<List<TipoViewModel>> GetAllViewModel()
        {
            var TipoList = await _tipoRepository.GetAllAsync();

            return TipoList.Select(Tipo => new TipoViewModel
            {
                Id = Tipo.Id,
                Name = Tipo.Name,

            }).ToList();
        }
    }
}
