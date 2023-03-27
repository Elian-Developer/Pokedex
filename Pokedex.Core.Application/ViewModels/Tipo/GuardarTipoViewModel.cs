using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Tipo
{
    public class GuardarTipoViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "You should set the name type")]
        public string Name { get; set; }
    }
}
