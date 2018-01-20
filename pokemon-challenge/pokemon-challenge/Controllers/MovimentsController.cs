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
    public class MovimentsController : ApiController
    {
        private pokemon_challengeContext db = new pokemon_challengeContext();

        // GET: api/Moviments
        public IQueryable<Moviments> GetMoviments()
        {
            return db.Moviments;
        }

        // GET: api/Moviments/5
        [ResponseType(typeof(Moviments))]
        public IHttpActionResult GetMoviments(int id)
        {
            Moviments moviments = db.Moviments.Find(id);
            if (moviments == null)
            {
                return NotFound();
            }

            return Ok(moviments);
        }

        // PUT: api/Moviments/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMoviments(int id, Moviments moviments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != moviments.Id)
            {
                return BadRequest();
            }

            db.Entry(moviments).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MovimentsExists(id))
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

        // POST: api/Moviments
        [ResponseType(typeof(Moviments))]
        public IHttpActionResult PostMoviments(Moviments moviments)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Moviments.Add(moviments);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = moviments.Id }, moviments);
        }

        // DELETE: api/Moviments/5
        [ResponseType(typeof(Moviments))]
        public IHttpActionResult DeleteMoviments(int id)
        {
            Moviments moviments = db.Moviments.Find(id);
            if (moviments == null)
            {
                return NotFound();
            }

            db.Moviments.Remove(moviments);
            db.SaveChanges();

            return Ok(moviments);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MovimentsExists(int id)
        {
            return db.Moviments.Count(e => e.Id == id) > 0;
        }
    }
}