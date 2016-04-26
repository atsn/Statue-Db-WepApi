﻿using System;
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
    public class CitiesController : ApiController
    {
        private OpretStatueContext db = new OpretStatueContext();

        // GET: api/Cities
        public IQueryable<City> GetCity()
        {
            return db.City;
        }

        // GET: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult GetCity(string id)
        {
            City city = db.City.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            return Ok(city);
        }

        // PUT: api/Cities/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCity(string id, City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != city.Zipcode)
            {
                return BadRequest();
            }

            db.Entry(city).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityExists(id))
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

        // POST: api/Cities
        [ResponseType(typeof(City))]
        public IHttpActionResult PostCity(City city)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.City.Add(city);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CityExists(city.Zipcode))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = city.Zipcode }, city);
        }

        // DELETE: api/Cities/5
        [ResponseType(typeof(City))]
        public IHttpActionResult DeleteCity(string id)
        {
            City city = db.City.Find(id);
            if (city == null)
            {
                return NotFound();
            }

            db.City.Remove(city);
            db.SaveChanges();

            return Ok(city);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CityExists(string id)
        {
            return db.City.Count(e => e.Zipcode == id) > 0;
        }
    }
}