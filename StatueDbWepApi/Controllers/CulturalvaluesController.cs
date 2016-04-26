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
    public class CulturalvaluesController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/Culturalvalues
        public IQueryable<Culturalvalue> GetCulturalvalue()
        {
            return db.Culturalvalue;
        }

        // GET: api/Culturalvalues/5
        [ResponseType(typeof(Culturalvalue))]
        public IHttpActionResult GetCulturalvalue(int id)
        {
            Culturalvalue culturalvalue = db.Culturalvalue.Find(id);
            if (culturalvalue == null)
            {
                return NotFound();
            }

            return Ok(culturalvalue);
        }

        // PUT: api/Culturalvalues/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCulturalvalue(int id, Culturalvalue culturalvalue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != culturalvalue.Id)
            {
                return BadRequest();
            }

            db.Entry(culturalvalue).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CulturalvalueExists(id))
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

        // POST: api/Culturalvalues
        [ResponseType(typeof(Culturalvalue))]
        public IHttpActionResult PostCulturalvalue(Culturalvalue culturalvalue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Culturalvalue.Add(culturalvalue);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = culturalvalue.Id }, culturalvalue);
        }

        // DELETE: api/Culturalvalues/5
        [ResponseType(typeof(Culturalvalue))]
        public IHttpActionResult DeleteCulturalvalue(int id)
        {
            Culturalvalue culturalvalue = db.Culturalvalue.Find(id);
            if (culturalvalue == null)
            {
                return NotFound();
            }

            db.Culturalvalue.Remove(culturalvalue);
            db.SaveChanges();

            return Ok(culturalvalue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CulturalvalueExists(int id)
        {
            return db.Culturalvalue.Count(e => e.Id == id) > 0;
        }
    }
}