using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Maris_Sorana_Lab2.Models;

namespace Maris_Sorana_Lab2.Data
{
    public class LabraryContext : DbContext
    {
        public LabraryContext (DbContextOptions<LabraryContext> options)
            : base(options)
        {
        }

        public DbSet<Maris_Sorana_Lab2.Models.Customer> Customer { get; set; } = default!;
    }
}
