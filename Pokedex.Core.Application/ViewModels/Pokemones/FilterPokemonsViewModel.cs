﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokedex.Core.Application.ViewModels.Pokemones
{
    public class FilterPokemonsViewModel
    {
        public string? PokemonName { get; set; }
        public int? RegionId { get; set; }
    }
}
