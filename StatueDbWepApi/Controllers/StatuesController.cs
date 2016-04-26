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
using StatueDbWepApi;

namespace StatueDbWepApi.Controllers
{
    public class StatuesController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/Statues
        public IQueryable<Statue> GetStatue()
        {
            return db.Statue;
        }

        // GET: api/Statues/5
        [ResponseType(typeof(Statue))]
        public IHttpActionResult GetStatue(int id)
        {
            Statue statue = db.Statue.Find(id);
            if (statue == null)
            {
                return NotFound();
            }

            return Ok(statue);
        }

        // PUT: api/Statues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatue(int id, Statue statue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statue.Id)
            {
                return BadRequest();
            }

            db.Entry(statue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueExists(id))
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

        // POST: api/Statues
        [ResponseType(typeof(Statue))]
        public IHttpActionResult PostStatue(Statue statue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Statue.Add(statue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statue.Id }, statue);
        }

        // DELETE: api/Statues/5
        [ResponseType(typeof(Statue))]
        public IHttpActionResult DeleteStatue(int id)
        {
            Statue statue = db.Statue.Find(id);
            if (statue == null)
            {
                return NotFound();
            }

            db.Statue.Remove(statue);
            db.SaveChanges();

            return Ok(statue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueExists(int id)
        {
            return db.Statue.Count(e => e.Id == id) > 0;
        }
    }
}