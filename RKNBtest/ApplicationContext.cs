using Microsoft.EntityFrameworkCore;
using RKNBtest.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RKNBtest
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Person> Persons { get; set; }
        public DbSet<Currency> Currencies { get; set; }
        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>().HasData(
            new Person[]
            {
                new Person { Login="admin@gmail.com", Password="12345", Role="admin" , Id="0"},
                new Person { Login="qwerty@gmail.com", Password="55555", Role="user", Id="1"}
            });
    }
    }
}
