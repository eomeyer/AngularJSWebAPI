using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJSWebAPI.Entities
{
    public class Country
    {

        public int Id { get; set; }
        public string Name { get; set; }

        public int ContinentId { get; set; }

        public virtual Continent Continent { get; set; }
    }
}