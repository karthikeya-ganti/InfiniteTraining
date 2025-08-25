using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Code_Challenge_9.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("name = moviesdb") { }
        public DbSet<Movie> Contacts { get; set; }
    }
}