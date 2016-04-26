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
    public class MaterialListsController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/MaterialLists
        public IQueryable<MaterialList> GetMaterialList()
        {
            return db.MaterialList;
        }

        // GET: api/MaterialLists/5
        [ResponseType(typeof(MaterialList))]
        public IHttpActionResult GetMaterialList(int id)
        {
            MaterialList materialList = db.MaterialList.Find(id);
            if (materialList == null)
            {
                return NotFound();
            }

            return Ok(materialList);
        }

        // PUT: api/MaterialLists/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMaterialList(int id, MaterialList materialList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != materialList.Id)
            {
                return BadRequest();
            }

            db.Entry(materialList).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MaterialListExists(id))
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

        // POST: api/MaterialLists
        [ResponseType(typeof(MaterialList))]
        public IHttpActionResult PostMaterialList(MaterialList materialList)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MaterialList.Add(materialList);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = materialList.Id }, materialList);
        }

        // DELETE: api/MaterialLists/5
        [ResponseType(typeof(MaterialList))]
        public IHttpActionResult DeleteMaterialList(int id)
        {
            MaterialList materialList = db.MaterialList.Find(id);
            if (materialList == null)
            {
                return NotFound();
            }

            db.MaterialList.Remove(materialList);
            db.SaveChanges();

            return Ok(materialList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MaterialListExists(int id)
        {
            return db.MaterialList.Count(e => e.Id == id) > 0;
        }
    }
}