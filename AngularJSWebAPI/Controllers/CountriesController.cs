using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AngularJSWebAPI.Controllers
{
    [RoutePrefix("api/Countries")]
    public class CountriesController : ApiController
    {
        private Contexts.SqlDbContext db;

        public CountriesController()
        {
            db = new Contexts.SqlDbContext();
        }
        [AllowAnonymous]
        public IHttpActionResult Get() 
        {
            var result = db.Countries;
            return Ok(result);
        }

    }
}
