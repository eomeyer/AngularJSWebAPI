using AngularJSWebAPI.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJSWebAPI.Contexts
{
    public class SqlDbContext : DbContext
    {
        
        public SqlDbContext():base("name=SqlDbContext")
        {
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Continent> Continents { get; set; }

        
    }
}