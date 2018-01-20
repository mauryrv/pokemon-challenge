using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class Moviments
    {

        public Moviments()
        {
            this.PokemonInfo = new HashSet<PokemonInfo>();
        }
        [Key]
        public int Id { get; set; }

        public string moviment { get; set; }
        public string description { get; set; }
        public virtual ICollection<PokemonInfo> PokemonInfo { get; set; }
    }
}