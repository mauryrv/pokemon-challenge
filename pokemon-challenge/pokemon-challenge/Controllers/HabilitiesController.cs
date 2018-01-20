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
    public class HabilitiesController : ApiController
    {
        private pokemon_challengeContext db = new pokemon_challengeContext();

        // GET: api/Habilities
        public IQueryable<Habilities> GetHabilities()
        {
            return db.Habilities;
        }

        // GET: api/Habilities/5
        [ResponseType(typeof(Habilities))]
        public IHttpActionResult GetHabilities(int id)
        {
            Habilities habilities = db.Habilities.Find(id);
            if (habilities == null)
            {
                return NotFound();
            }

            return Ok(habilities);
        }

        // PUT: api/Habilities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutHabilities(int id, Habilities habilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != habilities.Id)
            {
                return BadRequest();
            }

            db.Entry(habilities).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabilitiesExists(id))
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

        // POST: api/Habilities
        [ResponseType(typeof(Habilities))]
        public IHttpActionResult PostHabilities(Habilities habilities)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Habilities.Add(habilities);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = habilities.Id }, habilities);
        }

        // DELETE: api/Habilities/5
        [ResponseType(typeof(Habilities))]
        public IHttpActionResult DeleteHabilities(int id)
        {
            Habilities habilities = db.Habilities.Find(id);
            if (habilities == null)
            {
                return NotFound();
            }

            db.Habilities.Remove(habilities);
            db.SaveChanges();

            return Ok(habilities);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool HabilitiesExists(int id)
        {
            return db.Habilities.Count(e => e.Id == id) > 0;
        }
    }
}