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
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        [Required]
        [Range(1.0, 2000.0, ErrorMessage = "The Weight must be between 1.0 and 10.0")]
        public decimal weight { get; set; }
        [Required]
        [Range(20, 255, ErrorMessage = "The Base Experience must be between 20 and 255")]
        public decimal baseExperience { get; set; }
        [Required]
        [Range(1.0, 10.0, ErrorMessage = "The Speed must be between 1.0 and 10.0")]
        public decimal speed { get; set; }
        [Required]
        [Range(1.0, 10.0, ErrorMessage = "The Defense must be between 1.0 and 10.0")]
        public decimal defense { get; set; }
        [Required]
        [Range(1.0, 10.0, ErrorMessage = "The Attack must be between 1.0 and 10.0")]
        public decimal attack { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Abilities> Abilities { get; set; }
        public virtual ICollection<Moviments> Moviments { get; set; }
    }
}