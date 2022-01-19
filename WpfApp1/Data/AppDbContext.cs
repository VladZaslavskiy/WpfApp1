using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WpfApp1.Data.Models;

namespace WpfApp1.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<Person> Person { get; set; }
        //protected override void OnModelCreating(ModelBuilder builder)
        //{
        //    builder.Entity<Person>().HasKey(x => x.Id);
        //}
    }
}
