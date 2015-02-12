using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;

using AngularJSWebAPI.Models;
using AngularJSWebAPI.Contexts;
using System.Web.OData;
using AngularJSWebAPI.Entities;

namespace AngularJSWebAPI.ODataControllers
{
    /*
    To add a route for this controller, merge these statements into the Register method of the WebApiConfig class. Note that OData URLs are case sensitive.

    using System.Web.Http.OData.Builder;
    using AngularJSWebAPI.Models;
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    builder.EntitySet<Country>("Countries");
    builder.EntitySet<Continent>("Continents"); 
    config.Routes.MapODataRoute("odata", "odata", builder.GetEdmModel());
    */
    public class CountriesODController : ODataController
    {
        private SqlDbContext db = new SqlDbContext();

        // GET odata/Countries
        [EnableQuery]
        public IQueryable<Country> GetCountries()
        {
            return db.Countries;
        }

        // GET odata/Countries(5)
        [EnableQuery]
        public SingleResult<Country> GetCountry([FromODataUri] int key)
        {
            return SingleResult.Create(db.Countries.Where(country => country.Id == key));
        }

        // PUT odata/Countries(5)
        public IHttpActionResult Put([FromODataUri] int key, Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (key != country.Id)
            {
                return BadRequest();
            }

            db.Entry(country).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(country);
        }

        // POST odata/Countries
        public IHttpActionResult Post(Country country)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Countries.Add(country);
            db.SaveChanges();

            return Created(country);
        }

        // PATCH odata/Countries(5)
        [AcceptVerbs("PATCH", "MERGE")]
        public IHttpActionResult Patch([FromODataUri] int key, Delta<Country> patch)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Country country = db.Countries.Find(key);
            if (country == null)
            {
                return NotFound();
            }

            patch.Patch(country);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryExists(key))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Updated(country);
        }

        // DELETE odata/Countries(5)
        public IHttpActionResult Delete([FromODataUri] int key)
        {
            Country country = db.Countries.Find(key);
            if (country == null)
            {
                return NotFound();
            }

            db.Countries.Remove(country);
            db.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }

        // GET odata/Countries(5)/Continent
        [EnableQuery]
        public SingleResult<Continent> GetContinent([FromODataUri] int key)
        {
            return SingleResult.Create(db.Countries.Where(m => m.Id == key).Select(m => m.Continent));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CountryExists(int key)
        {
            return db.Countries.Count(e => e.Id == key) > 0;
        }
    }
}
