using DataAccess.Concrete.Mapping;
using Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Contexts
{
    public class BilgiSayarDbContext : IdentityDbContext<IdentityUser>
    {
        public BilgiSayarDbContext(DbContextOptions<BilgiSayarDbContext> options)
     : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // modelBuilder.Configurations.Add(new ProductMap());//Mapping işlemi için ekleme



            modelBuilder.Entity<Entry>().HasKey(x => x.ContentId);

            modelBuilder.Entity<Writer>().HasKey(x => x.WriterId);
            modelBuilder.Entity<Category>().HasKey(x => x.CategoryId);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<Writer> Writers { get; set; }

    }
}
