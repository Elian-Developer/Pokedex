using Pokedex.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Domain.Entities
{
    public class Pokemones : AuditableBaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }

        //Foreign Key

        public int TipoPrimarioId { get; set; }
        public int TipoSecundarioId { get; set; }
        public int RegionId { get; set; }

        // Navigation property

        public Tipo Tipo { get; set; }
        public Region Region { get; set; }

    }
}
