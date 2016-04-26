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
    public class CulturalValueListsController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/CulturalValueLists
        public IQueryable<CulturalValueList> GetCulturalValueList()
        {
            return db.CulturalValueList;
        }

        // GET: api/CulturalValueLists/5
        [ResponseType(typeof(CulturalValueList))]
        public IHttpActionResult GetCulturalValueList(int id)
        {
            CulturalValueList culturalValueList = db.CulturalValueList.Find(id);
            if (culturalValueList == null)
            {
                return NotFound();
            }

            return Ok(culturalValueList);
        }

        // PUT: api/CulturalValueLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCulturalValueList(int id, CulturalValueList culturalValueList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != culturalValueList.Id)
            {
                return BadRequest();
            }

            db.Entry(culturalValueList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CulturalValueListExists(id))
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

        // POST: api/CulturalValueLists
        [ResponseType(typeof(CulturalValueList))]
        public IHttpActionResult PostCulturalValueList(CulturalValueList culturalValueList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CulturalValueList.Add(culturalValueList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = culturalValueList.Id }, culturalValueList);
        }

        // DELETE: api/CulturalValueLists/5
        [ResponseType(typeof(CulturalValueList))]
        public IHttpActionResult DeleteCulturalValueList(int id)
        {
            CulturalValueList culturalValueList = db.CulturalValueList.Find(id);
            if (culturalValueList == null)
            {
                return NotFound();
            }

            db.CulturalValueList.Remove(culturalValueList);
            db.SaveChanges();

            return Ok(culturalValueList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CulturalValueListExists(int id)
        {
            return db.CulturalValueList.Count(e => e.Id == id) > 0;
        }
    }
}