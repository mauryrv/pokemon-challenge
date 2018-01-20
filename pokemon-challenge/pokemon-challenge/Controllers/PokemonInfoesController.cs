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

namespace pokemon_challenge.Controllers
{
    public class PokemonInfoesController : ApiController
    {
        private pokemon_challengeContext db = new pokemon_challengeContext();

        // GET: api/PokemonInfoes
        public IQueryable<PokemonInfo> GetPokemonInfoes()
        {
            return db.PokemonInfoes;
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

        // POST: api/PokemonInfoes
        [ResponseType(typeof(PokemonInfo))]
        public IHttpActionResult PostPokemonInfo(PokemonInfo pokemonInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
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