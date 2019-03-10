using Lookup.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lookup.API.Repository
{
    public class LookupDbContext : DbContext
    {
        public DbSet<State> States { get; set; }

        public LookupDbContext(DbContextOptions<LookupDbContext> options) : base(options) { }
    }
}
