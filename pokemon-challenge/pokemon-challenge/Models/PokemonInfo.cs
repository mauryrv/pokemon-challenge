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

        public string name { get; set; }
        public decimal weight { get; set; }
        public decimal baseExperience { get; set; }
        public decimal speed { get; set; }
        public decimal defense { get; set; }
        public decimal attack { get; set; }
        public byte[] Image { get; set; }

        public virtual ICollection<Abilities> Abilities { get; set; }
        public virtual ICollection<Moviments> Moviments { get; set; }
    }
}