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
    public class GPSLocationsController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/GPSLocations
        public IQueryable<GPSLocation> GetGPSLocation()
        {
            return db.GPSLocation;
        }

        // GET: api/GPSLocations/5
        [ResponseType(typeof(GPSLocation))]
        public IHttpActionResult GetGPSLocation(int id)
        {
            GPSLocation gPSLocation = db.GPSLocation.Find(id);
            if (gPSLocation == null)
            {
                return NotFound();
            }

            return Ok(gPSLocation);
        }

        // PUT: api/GPSLocations/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutGPSLocation(int id, GPSLocation gPSLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != gPSLocation.Id)
            {
                return BadRequest();
            }

            db.Entry(gPSLocation).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!GPSLocationExists(id))
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

        // POST: api/GPSLocations
        [ResponseType(typeof(GPSLocation))]
        public IHttpActionResult PostGPSLocation(GPSLocation gPSLocation)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.GPSLocation.Add(gPSLocation);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = gPSLocation.Id }, gPSLocation);
        }

        // DELETE: api/GPSLocations/5
        [ResponseType(typeof(GPSLocation))]
        public IHttpActionResult DeleteGPSLocation(int id)
        {
            GPSLocation gPSLocation = db.GPSLocation.Find(id);
            if (gPSLocation == null)
            {
                return NotFound();
            }

            db.GPSLocation.Remove(gPSLocation);
            db.SaveChanges();

            return Ok(gPSLocation);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool GPSLocationExists(int id)
        {
            return db.GPSLocation.Count(e => e.Id == id) > 0;
        }
    }
}