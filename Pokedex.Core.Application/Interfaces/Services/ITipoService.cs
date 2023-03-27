using Pokedex.Core.Application.ViewModels.Tipo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.Interfaces.Services
{
    public interface ITipoService : IGenericService<GuardarTipoViewModel, TipoViewModel>
    {
    }
}
