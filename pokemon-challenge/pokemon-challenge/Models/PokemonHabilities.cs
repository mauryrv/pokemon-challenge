using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class PokemonHabilities
    {
        public int Id { get; set; }
        // Foreign Key
        public int PokemonInfoId { get; set; }
        // Navigation property
        public virtual PokemonInfo Pokemon { get; set; }
        public int HabilitiesId { get; set; }

    }
}