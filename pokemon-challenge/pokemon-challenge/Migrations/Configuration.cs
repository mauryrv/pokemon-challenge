namespace pokemon_challenge.Migrations
{
    using pokemon_challenge.Models;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<pokemon_challenge.Models.pokemon_challengeContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(pokemon_challenge.Models.pokemon_challengeContext context)
        {

            context.Moviments.AddOrUpdate(
                  new Moviments { moviment = "Pound", description= "Pound" },
                  new Moviments { moviment = "Fire Punch", description = "Fire Punch" },
                  new Moviments { moviment = "Ice Punch", description = "Ice Punch" },
                  new Moviments { moviment = "Scratch", description = "Scratch" },
                  new Moviments { moviment = "Guillotine", description = "Guillotine" },
                  new Moviments { moviment = "Cut", description = "Cut" }


                );


            context.Abilities.AddOrUpdate(
                  new Abilities { abilitie = "Adaptability", description = "Adaptability" },
                  new Abilities { abilitie = "Air Lock", description = "Air Lock" },
                  new Abilities { abilitie = "Analytic", description = "Analytic" },
                  new Abilities { abilitie = "Anger Point", description = "Anger Point" },
                  new Abilities { abilitie = "Anticipation", description = "Anticipation" },
                  new Abilities { abilitie = "Bad Dreams", description = "Bad Dreams" }

                );
        }
    }
}
