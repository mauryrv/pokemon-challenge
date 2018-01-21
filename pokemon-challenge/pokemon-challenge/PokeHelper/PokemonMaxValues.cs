using pokemon_challenge.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemon_challenge.PokeHelper
{
    public class PokemonMaxValues
    {
        public List<PokemonInfo> pokemonsInfos { get; set; }
        public decimal sumWeight { get; set; }
        public decimal sumBaseExperience { get; set; }
        public decimal sumSpeed { get; set; }
        public decimal sumDefense { get; set; }
        public decimal sumAttack { get; set; }
    }
}