using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Vidly.Controllers;
using Vidly.Models;

namespace Vidly.Data
{
    public class VidlyContext : DbContext
    {
        //public VidlyContext()
        //{
        //}

        public VidlyContext (DbContextOptions<VidlyContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>().HasOne(m => m.MembershipType);
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movie> Movies { get; set; }
    }
}
