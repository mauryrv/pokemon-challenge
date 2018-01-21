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

        // GET: api/PokemonInfoes
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
            //return db.PokemonInfoes;
        }

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


        // GET: api/PokemonInfoes/getPokemonMaxValues
        [ResponseType(typeof(PokemonMaxValues))]
        [HttpGet]
        [Route("getPokemonMaxValues")]
        public IHttpActionResult GetPokemonMaxValues()
        {
            PokemonMaxValues pokemons = new PokemonMaxValues();
            pokemons.pokemonsInfos = (List<PokemonInfo>)db.PokemonInfoes.OrderByDescending(p => p.attack).Take(6).ToList();

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

        // PUT: api/PokemonInfoes/5
        [ResponseType(typeof(void))]
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

            db.Entry(pokemonInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // PATCH: api/PokemonInfoes/5
        [ResponseType(typeof(void))]
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

            db.Entry(pokemonInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PokemonInfoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }


        // POST: api/PokemonInfoes
        [ResponseType(typeof(PokemonInfo))]
        public IHttpActionResult PostPokemonInfo(PokemonInfo pokemonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            foreach (Abilities abilitie in pokemonInfo.Abilities)
            {
                if(db.Abilities.Find(abilitie.abilitie)==null)
                {
                    return BadRequest("There is no Abilitie "+abilitie.abilitie+"!");

                }

            }

            foreach (Moviments moviment in pokemonInfo.Moviments)
            {
                if (db.Moviments.Find(moviment.moviment) == null)
                {
                    return BadRequest("There is no move " + moviment.moviment + "!");

                }

            }

            db.PokemonInfoes.Add(pokemonInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = pokemonInfo.Id }, pokemonInfo);
        }

        // DELETE: api/PokemonInfoes/5
        [ResponseType(typeof(PokemonInfo))]
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
    }
}