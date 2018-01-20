using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class PokemonInfo
    {

        public int Id { get; set; }
        public string name { get; set; }
        public decimal weight { get; set; }
        public decimal baseExperience { get; set; }
        public decimal speed { get; set; }
        public decimal defense { get; set; }
        public decimal attack { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<PokemonHabilities> PokemonHabilities { get; set;}
        public virtual ICollection<PokemonMoviments> PokemonMoviments { get; set; }

    }
}