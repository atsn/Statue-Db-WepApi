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
    public class PlacementListsController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/PlacementLists
        public IQueryable<PlacementList> GetPlacementList()
        {
            return db.PlacementList;
        }

        // GET: api/PlacementLists/5
        [ResponseType(typeof(PlacementList))]
        public IHttpActionResult GetPlacementList(int id)
        {
            PlacementList placementList = db.PlacementList.Find(id);
            if (placementList == null)
            {
                return NotFound();
            }

            return Ok(placementList);
        }

        // PUT: api/PlacementLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutPlacementList(int id, PlacementList placementList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != placementList.Id)
            {
                return BadRequest();
            }

            db.Entry(placementList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PlacementListExists(id))
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

        // POST: api/PlacementLists
        [ResponseType(typeof(PlacementList))]
        public IHttpActionResult PostPlacementList(PlacementList placementList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.PlacementList.Add(placementList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = placementList.Id }, placementList);
        }

        // DELETE: api/PlacementLists/5
        [ResponseType(typeof(PlacementList))]
        public IHttpActionResult DeletePlacementList(int id)
        {
            PlacementList placementList = db.PlacementList.Find(id);
            if (placementList == null)
            {
                return NotFound();
            }

            db.PlacementList.Remove(placementList);
            db.SaveChanges();

            return Ok(placementList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool PlacementListExists(int id)
        {
            return db.PlacementList.Count(e => e.Id == id) > 0;
        }
    }
}