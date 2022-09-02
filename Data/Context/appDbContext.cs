using Business.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Context
{
    public class appDbContext:DbContext
    {
        public appDbContext(DbContextOptions options):
            base(options)
        {

        }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<InputRelations> InputRelations { get; set; }

    }
  
}
