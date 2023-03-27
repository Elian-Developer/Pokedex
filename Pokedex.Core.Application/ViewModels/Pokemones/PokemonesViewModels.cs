using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Pokemones
{
    public class PokemonesViewModels
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int TipoPrimarioId { get; set; }
        public int TipoSecundarioId { get; set; }
        public int RegionId { get; set; }
        public string Region { get; set; }
        public string Tipo { get; set; }
     
    }
}
