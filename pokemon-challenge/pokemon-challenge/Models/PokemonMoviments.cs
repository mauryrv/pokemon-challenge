using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class PokemonMoviments
    {
        public int Id { get; set; }
        // Foreign Key
        public int PokemonInfoId { get; set; }
        // Navigation property
        public virtual PokemonInfo Pokemon { get; set; }
        public int MovimentsId { get; set; }
    }
}