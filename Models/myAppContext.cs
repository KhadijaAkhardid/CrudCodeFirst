using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudCodeFirst.Models;


namespace CrudCodeFirst.Models
{
    public class myAppContext :DbContext
    {
       // public AppContext() { }
        public myAppContext(DbContextOptions<myAppContext> options) :base(options) { }
        public DbSet<Category> Categories { get; set; }
        

    }

   
  
}
