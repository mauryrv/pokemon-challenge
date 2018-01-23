using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    
    public class PokemonInfo
    {
        public PokemonInfo()
        {
            this.Abilities = new HashSet<Abilities>();
            this.Moviments = new HashSet<Moviments>();

        }

        [Key]
        [JsonProperty(Order = 1)]
        public int Id { get; set; }
        [Required]
        [JsonProperty(Order = 2)]
        public string name { get; set; }
        [Required]
        [Range(1.0, 2000.0, ErrorMessage = "The Weight must be between 1.0 and 10.0")]
        [JsonProperty(Order = 3)]
        public decimal weight { get; set; }
        [Required]
        [Range(20, 255, ErrorMessage = "The Base Experience must be between 20 and 255")]
        [JsonProperty(Order = 4)]
        public decimal baseExperience { get; set; }
        [Required]
        [Range(1.0, 10.0, ErrorMessage = "The Speed must be between 1.0 and 10.0")]
        [JsonProperty(Order = 5)]
        public decimal speed { get; set; }
        [Required]
        [Range(1.0, 10.0, ErrorMessage = "The Defense must be between 1.0 and 10.0")]
        [JsonProperty(Order = 6)]
        public decimal defense { get; set; }
        [Required]
        [Range(1.0, 10.0, ErrorMessage = "The Attack must be between 1.0 and 10.0")]
        [JsonProperty(Order = 7)]
        public decimal attack { get; set; }
        [JsonProperty(Order = 8)]
        public byte[] Image { get; set; }


        [JsonProperty(Order = 9)]
        public virtual ICollection<Abilities> Abilities { get; set; }
        [JsonProperty(Order = 10)]
        public virtual ICollection<Moviments> Moviments { get; set; }
    }
}