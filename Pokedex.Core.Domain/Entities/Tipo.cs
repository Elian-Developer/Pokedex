using Pokedex.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Tipo : AuditableBaseEntity
    {
        public string Name { get; set; }

        //Navigation Property
        public ICollection<Pokemones> Pokemones { get; set; }
    }
}
