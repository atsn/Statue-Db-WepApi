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
    public class PlacementsController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/Placements
        public IQueryable<Placement> GetPlacement()
        {
            return db.Placement;
        }

        // GET: api/Placements/5
        [ResponseType(typeof(Placement))]
        public IHttpActionResult GetPlacement(int id)
        {
            Placement placement = db.Placement.Find(id);
            if (placement == null)
            {
                return NotFound();
            }

            return Ok(placement);
        }

        // PUT: api/Placements/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlacement(int id, Placement placement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != placement.Id)
            {
                return BadRequest();
            }

            db.Entry(placement).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacementExists(id))
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

        // POST: api/Placements
        [ResponseType(typeof(Placement))]
        public IHttpActionResult PostPlacement(Placement placement)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Placement.Add(placement);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = placement.Id }, placement);
        }

        // DELETE: api/Placements/5
        [ResponseType(typeof(Placement))]
        public IHttpActionResult DeletePlacement(int id)
        {
            Placement placement = db.Placement.Find(id);
            if (placement == null)
            {
                return NotFound();
            }

            db.Placement.Remove(placement);
            db.SaveChanges();

            return Ok(placement);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlacementExists(int id)
        {
            return db.Placement.Count(e => e.Id == id) > 0;
        }
    }
}