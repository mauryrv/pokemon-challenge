using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class Habilities
    {
        public Habilities()
        {
            this.PokemonHabilities = new HashSet<PokemonHabilities>();
        }
        public int Id { get; set; }
        public string habilities { get; set; }
        public decimal descriptions { get; set; }
        public virtual ICollection<PokemonHabilities> PokemonHabilities { get; set;  }
 
    }
}