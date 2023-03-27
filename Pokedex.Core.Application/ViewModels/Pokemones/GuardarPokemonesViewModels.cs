using Pokedex.Core.Application.ViewModels.Region;
using Pokedex.Core.Application.ViewModels.Tipo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Pokemones
{
    public class GuardarPokemonesViewModels
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should set the Pokemon name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "You should set the URL Image")]
        public string? ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You must set the pokemon type.")]
        public int TipoPrimarioId { get; set; }
     
        [Range(1, int.MaxValue, ErrorMessage = "You should set the pokemon type")]
        public int TipoSecundarioId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "You should set the pokemon region")]
        public int RegionId { get; set; }
        public List<RegionViewModel>? Regions { get; set; }

        public List<TipoViewModel>? Types { get; set; }
    }
}
