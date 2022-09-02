using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Data.Context
{
    public class IdentityAppContext : IdentityDbContext
    {
        public IdentityAppContext(DbContextOptions<IdentityAppContext> Options):
            base(Options)
        {

        }

    }
}
