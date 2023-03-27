using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Region
{
    public class GuardarRegionViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You should set the region name")]
        public string Name { get; set; }
    }
}
