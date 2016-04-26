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
    public class StatueTypeListsController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/StatueTypeLists
        public IQueryable<StatueTypeList> GetStatueTypeList()
        {
            return db.StatueTypeList;
        }

        // GET: api/StatueTypeLists/5
        [ResponseType(typeof(StatueTypeList))]
        public IHttpActionResult GetStatueTypeList(int id)
        {
            StatueTypeList statueTypeList = db.StatueTypeList.Find(id);
            if (statueTypeList == null)
            {
                return NotFound();
            }

            return Ok(statueTypeList);
        }

        // PUT: api/StatueTypeLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStatueTypeList(int id, StatueTypeList statueTypeList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != statueTypeList.Id)
            {
                return BadRequest();
            }

            db.Entry(statueTypeList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StatueTypeListExists(id))
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

        // POST: api/StatueTypeLists
        [ResponseType(typeof(StatueTypeList))]
        public IHttpActionResult PostStatueTypeList(StatueTypeList statueTypeList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.StatueTypeList.Add(statueTypeList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = statueTypeList.Id }, statueTypeList);
        }

        // DELETE: api/StatueTypeLists/5
        [ResponseType(typeof(StatueTypeList))]
        public IHttpActionResult DeleteStatueTypeList(int id)
        {
            StatueTypeList statueTypeList = db.StatueTypeList.Find(id);
            if (statueTypeList == null)
            {
                return NotFound();
            }

            db.StatueTypeList.Remove(statueTypeList);
            db.SaveChanges();

            return Ok(statueTypeList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StatueTypeListExists(int id)
        {
            return db.StatueTypeList.Count(e => e.Id == id) > 0;
        }
    }
}