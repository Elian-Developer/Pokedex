using Pokedex.Core.Application.Interfaces.Repositories;
using Pokedex.Core.Application.Interfaces.Services;
using Pokedex.Core.Application.ViewModels.Pokemones;
using Pokedex.Core.Application.ViewModels.Region;
using Pokedex.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Services
{
    public class RegionServices : IRegionService
    {
        private readonly IRegionRepository _regionRepository;

        public RegionServices(IRegionRepository regionRepository)
        {
            _regionRepository = regionRepository;
        }

        public async Task Add(GuardarRegionViewModel vm)
        {
            Region region = new();
            region.Name = vm.Name;

            await _regionRepository.AddAsync(region);
        }
        public async Task Edit(GuardarRegionViewModel vm)
        {
            Region region = new();
            region.Id = vm.Id;
            region.Name = vm.Name;

            await _regionRepository.EditAsync(region);
        }

        public async Task Delete(int id)
        {
            var region = await _regionRepository.GetByIdAsync(id);
            await _regionRepository.DeleteAsync(region);
        }

        public async Task<GuardarRegionViewModel> GetByIdSaveViewModels(int id)
        {
            var Region = await _regionRepository.GetByIdAsync(id);

            GuardarRegionViewModel vm = new();

            vm.Id = Region.Id;
            vm.Name = Region.Name;

            return vm;
        }

        public async Task<List<RegionViewModel>> GetAllViewModel()
        {
            var RegionList = await _regionRepository.GetAllAsync();

            return RegionList.Select(Region => new RegionViewModel
            {
                Id = Region.Id,
                Name = Region.Name

            }).ToList();
        }
    }
}
