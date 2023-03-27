using Pokedex.Core.Application.ViewModels.Pokemones;
using Pokedex.Core.Application.ViewModels.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel,ViewModel> 
        where SaveViewModel : class
        where ViewModel : class
    {
        Task Add(SaveViewModel vm);
        Task Edit(SaveViewModel vm);
        Task Delete(int id);
        Task<List<ViewModel>> GetAllViewModel();
        Task<SaveViewModel> GetByIdSaveViewModels(int id);
    }
}
