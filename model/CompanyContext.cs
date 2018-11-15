using System;
using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Relational;

namespace model{
    public class CompanyContext : DbContext{
        public CompanyContext (DbContextOptions options) 
        : base (options){}

        protected override void OnModelCreating(ModelBuilder modelBuilder){
            modelBuilder.HasDefaultSchema("labo6");
        }
        public DbSet<Customer> Customers { get; set; } 
    }
}