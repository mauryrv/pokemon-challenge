using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class Moviments
    {
        public Moviments()
        {
            this.PokemonMoviments = new HashSet<PokemonMoviments>();
        }
        public int Id { get; set; }
        public string moviment { get; set; }
        public decimal description { get; set; }
        public virtual ICollection<PokemonMoviments> PokemonMoviments { get; set; }
    }
}