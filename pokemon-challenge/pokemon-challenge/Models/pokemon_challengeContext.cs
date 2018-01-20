using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace pokemon_challenge.Models
{
    public class pokemon_challengeContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public pokemon_challengeContext() : base("name=pokemon_challengeContext")
        {
        }

        public System.Data.Entity.DbSet<pokemon_challenge.Models.PokemonInfo> PokemonInfoes { get; set; }

        public System.Data.Entity.DbSet<pokemon_challenge.Models.Moviments> Moviments { get; set; }

        public System.Data.Entity.DbSet<pokemon_challenge.Models.Habilities> Habilities { get; set; }
    }
}
