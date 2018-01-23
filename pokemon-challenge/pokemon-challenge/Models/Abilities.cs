using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class Abilities
    {
        public Abilities()
        {
           this.PokemonInfo = new HashSet<PokemonInfo>();
        }
        [Key]
        public int Id { get; set; }

        public string abilitie { get; set; }
        public string description { get; set; }
        [JsonIgnore]
        public virtual ICollection<PokemonInfo> PokemonInfo { get; set; }
    }
}