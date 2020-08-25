using Microsoft.EntityFrameworkCore;
using PiData.DataAccess.Concrete.EntityFramework;
using PiData.Entities;
using PiData.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PiData.DataAccess.Concrete.EntityFramework
{
    public partial class PiDataContext : DbContext
    {
        
        public PiDataContext(DbContextOptions<PiDataContext> options) : base(options)
        { }
        public PiDataContext()
        {

        }
        public DbSet<CurrencyList> CurrencyList { get; set; }
        public DbSet<CurrencyInfo> CurrencyInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-7A1RLJDN\\CODERFUNDA;Database=PiData;user id=sa;password=dNA18_?;Trusted_Connection=True;MultipleActiveResultSets=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CurrencyList>().ToTable("CurrencyList");
            modelBuilder.Entity<CurrencyInfo>().ToTable("CurrencyInfo");
        }
    }
}

