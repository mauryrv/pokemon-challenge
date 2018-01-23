using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using pokemon_challenge.Models;
using pokemon_challenge.PokeHelper;

namespace pokemon_challenge.Controllers
{
    [RoutePrefix("api/PokemonInfoes")]
    public class PokemonInfoesController : ApiController
    {
        private pokemon_challengeContext db = new pokemon_challengeContext();

        /// <summary>
        /// Get all pokemons.
        /// </summary>
        /// <returns></returns>
        // GET: api/PokemonInfoes
        [ResponseType(typeof(List<PokemonInfo>))]
        public IHttpActionResult GetPokemonInfoes()
        {
            List<PokemonInfo> pokemonInfo = new List<PokemonInfo>();
            pokemonInfo = db.PokemonInfoes.ToList();

            if (pokemonInfo.Count > 0)
            {
                return Ok(pokemonInfo);
            }
            else
            {
                return NotFound();

            }
        }

        /// <summary>
        /// Get a pokemon by id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/PokemonInfoes/5
        [ResponseType(typeof(PokemonInfo))]
        public IHttpActionResult GetPokemonInfo(int id)
        {
            PokemonInfo pokemonInfo = db.PokemonInfoes.Find(id);
            if (pokemonInfo == null)
            {
                return NotFound();
            }

            return Ok(pokemonInfo);
        }

        /// <summary>
        /// Get the 6 pokemons with max attack and the sum of their weight, base experience, speed, attack and defense.
        /// </summary>
        /// <returns></returns>
        // GET: api/PokemonInfoes/getPokemonMaxValues
        [ResponseType(typeof(PokemonMaxValues))]
        [HttpGet]
        [Route("getPokemonMaxValues")]
        public IHttpActionResult GetPokemonMaxValues()
        {
            PokemonMaxValues pokemons = new PokemonMaxValues();
            pokemons.pokemonsInfos = db.PokemonInfoes.OrderByDescending(p => p.attack).Take(6).ToList();

            if (pokemons.pokemonsInfos.Count == 0)
            {
                return NotFound();
            }

            pokemons.sumAttack = 0;
            pokemons.sumBaseExperience = 0;
            pokemons.sumDefense = 0;
            pokemons.sumSpeed = 0;
            pokemons.sumWeight = 0;

            foreach(PokemonInfo pokemonInfo in pokemons.pokemonsInfos)
            {
                pokemons.sumAttack += pokemonInfo.attack;
                pokemons.sumBaseExperience += pokemonInfo.baseExperience;
                pokemons.sumDefense += pokemonInfo.defense;
                pokemons.sumSpeed += pokemonInfo.speed;
                pokemons.sumWeight += pokemonInfo.weight;

            }

            return Ok(pokemons);
        }
        /// <summary>
        /// Get contest types. Contest types are categories judges used to weigh a Pokémon's condition in Pokémon contests
        /// </summary>
        /// <param name="idOrName"></param>
        /// <returns></returns>
        // GET: api/PokemonInfoes/getContestType/name or id
        [ResponseType(typeof(ContestType))]
        [HttpGet]
        [Route("getContestType/{idOrName}")]
        public IHttpActionResult GetContextTypes(string idOrName)
        {

            PokeApiClient pokeApiClient = new PokeApiClient();
            ContestType contestType = pokeApiClient.GetContestTypeByNameOrId(idOrName);
            if (contestType == null)
            {
                return NotFound();
            }
            return Ok(contestType);
        }
        /// <summary>
        /// Update data of a pokemon using PUT.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pokemonInfo"></param>
        /// <returns></returns>
        // PUT: api/PokemonInfoes/5
        [ResponseType(typeof(PokemonInfo))]
        public IHttpActionResult PutPokemonInfo(int id, PokemonInfo pokemonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pokemonInfo.Id)
            {
                return BadRequest();
            }

            if (!PokemonInfoExists(id))
            {
                return NotFound();
            }

            PokemonInfo newPokemonInfo = UpdatePokemonInfo(pokemonInfo);

            return Ok(newPokemonInfo);
        }
        /// <summary>
        /// Update data of a pokemon using PATCH.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="pokemonInfo"></param>
        /// <returns></returns>
        // PATCH: api/PokemonInfoes/5
        [ResponseType(typeof(PokemonInfo))]
        [HttpPatch]
        public IHttpActionResult PatchPokemonInfo(int id, PokemonInfo pokemonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != pokemonInfo.Id)
            {
                return BadRequest();
            }

            if (!PokemonInfoExists(id))
            {
                return NotFound();
            }

            PokemonInfo newPokemonInfo = UpdatePokemonInfo(pokemonInfo);

            return Ok(newPokemonInfo);
        }
        /// <summary>
        /// Insert Pokemon info.
        /// </summary>
        /// <param name="pokemonInfo"></param>
        /// <returns></returns>
        // POST: api/PokemonInfoes
        [ResponseType(typeof(PokemonInfo))]
        public IHttpActionResult PostPokemonInfo(PokemonInfo pokemonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            List<Abilities> abilitiesList = pokemonInfo.Abilities.ToList();
            pokemonInfo.Abilities = new List<Abilities>();

             foreach (Abilities abilitie in abilitiesList)
             {
                 if (db.Abilities.Find(abilitie.Id) == null)
                 {
                     return BadRequest("There is no Abilitie " + abilitie.abilitie + "!");

                 }
                else
                {
                    pokemonInfo.Abilities.Add(db.Abilities.Find(abilitie.Id));
                   
                }


             }

            List<Moviments> movimentsList = pokemonInfo.Moviments.ToList();
            pokemonInfo.Moviments = new List<Moviments>();
            foreach (Moviments moviment in movimentsList)
             {
                 if (db.Moviments.Find(moviment.Id) == null)
                 {
                     return BadRequest("There is no move " + moviment.moviment + "!");

                 }
                 else
                {
                    pokemonInfo.Moviments.Add(db.Moviments.Find(moviment.Id));
                }
                 
             }


            db.PokemonInfoes.Add(pokemonInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pokemonInfo.Id }, pokemonInfo);
        }

        /// <summary>
        /// Delete pokemon info.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [ResponseType(typeof(PokemonInfo))]
        // DELETE: api/PokemonInfoes/5
        public IHttpActionResult DeletePokemonInfo(int id)
        {
            PokemonInfo pokemonInfo = db.PokemonInfoes.Find(id);
            if (pokemonInfo == null)
            {
                return NotFound();
            }

            db.PokemonInfoes.Remove(pokemonInfo);
            db.SaveChanges();

            return Ok(pokemonInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PokemonInfoExists(int id)
        {
            return db.PokemonInfoes.Count(e => e.Id == id) > 0;
        }

        private PokemonInfo UpdatePokemonInfo(PokemonInfo pokemonInfo)
        {


            List<int> abilitiesId = new List<int>();
            foreach (Abilities ab in pokemonInfo.Abilities)
            {
                abilitiesId.Add(ab.Id);

            }

            List<int> movimentsId = new List<int>();
            foreach (Moviments mov in pokemonInfo.Moviments)
            {
                movimentsId.Add(mov.Id);

            }

            var oldPokemonInfo = db.PokemonInfoes.Include("Abilities").Include("Moviments").Single(u => u.Id == pokemonInfo.Id);

            var newAbilities = db.Abilities
                .Where(r => abilitiesId.Contains(r.Id))
                .ToList();

            oldPokemonInfo.Abilities.Clear();
            foreach (var abilitie in newAbilities)
            {
                oldPokemonInfo.Abilities.Add(abilitie);
            }

            var newMoviments = db.Moviments
               .Where(r => movimentsId.Contains(r.Id))
               .ToList();

            oldPokemonInfo.Moviments.Clear();
            foreach (var moviment in newMoviments)
            {
                oldPokemonInfo.Moviments.Add(moviment);
            }

            oldPokemonInfo.Image = pokemonInfo.Image;
            oldPokemonInfo.name = pokemonInfo.name;
            oldPokemonInfo.speed = pokemonInfo.speed;
            oldPokemonInfo.weight = pokemonInfo.weight;
            oldPokemonInfo.defense = pokemonInfo.defense;
            oldPokemonInfo.baseExperience = pokemonInfo.baseExperience;
            oldPokemonInfo.attack = pokemonInfo.attack;

            db.Entry(oldPokemonInfo).State = EntityState.Modified;

            db.SaveChanges();

            return oldPokemonInfo;

        }
    }
}