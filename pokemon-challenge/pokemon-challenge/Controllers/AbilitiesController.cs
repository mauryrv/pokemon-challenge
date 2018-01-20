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

    [ApiExplorerSettings(IgnoreApi = true)]
    public class AbilitiesController : ApiController
    {
        private pokemon_challengeContext db = new pokemon_challengeContext();

        // GET: api/Abilities
        public IQueryable<Abilities> GetAbilities()
        {
            return db.Abilities;
        }

        // GET: api/Abilities/5
        [ResponseType(typeof(Abilities))]
        public IHttpActionResult GetAbilities(int id)
        {
            Abilities abilities = db.Abilities.Find(id);
            if (abilities == null)
            {
                return NotFound();
            }

            return Ok(abilities);
        }

        // PUT: api/Abilities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAbilities(int id, Abilities abilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != abilities.Id)
            {
                return BadRequest();
            }

            db.Entry(abilities).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AbilitiesExists(id))
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

        // POST: api/Abilities
        [ResponseType(typeof(Abilities))]
        public IHttpActionResult PostAbilities(Abilities abilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Abilities.Add(abilities);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = abilities.Id }, abilities);
        }

        // DELETE: api/Abilities/5
        [ResponseType(typeof(Abilities))]
        public IHttpActionResult DeleteAbilities(int id)
        {
            Abilities abilities = db.Abilities.Find(id);
            if (abilities == null)
            {
                return NotFound();
            }

            db.Abilities.Remove(abilities);
            db.SaveChanges();

            return Ok(abilities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AbilitiesExists(int id)
        {
            return db.Abilities.Count(e => e.Id == id) > 0;
        }
    }
}