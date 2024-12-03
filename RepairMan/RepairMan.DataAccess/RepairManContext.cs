using Microsoft.EntityFrameworkCore;
using RepairMan.DataClasses.Advertising;
using RepairMan.DataClasses.Common;
using RepairMan.DataClasses.Motoring;
using RepairMan.DataClasses.Repairing;
using RepairMan.DataClasses.Repairing.Diagnostic;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RepairMan.DataAccess
{
    public class RepairManContext : DbContext
    {
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Diagnostic> Diagnostics { get; set; }
        public DbSet<Pronostic> Pronostics { get; set; }
        public DbSet<PronosticQuestion> PronosticQuestions { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopCategory> WorkshopCategories { get; set; }
        public DbSet<WorkshopProduct> WorkshopProducts { get; set; }
        public DbSet<WorkshopCategorization> WorkshopCategorizations { get; set; }
        public DbSet<BrandSpecialization> BrandSpecializations { get; set; }
        public DbSet<ModelSpecialization> ModelSpecializations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Model> Models { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Advertisement> Advertisements { get; set; }
        public DbSet<AdvertisementContext> AdvertisementContexts { get; set; }
        public DbSet<IdentityDocument> IdentityDocuments { get; set; }
        public DbSet<DataFile> DataFiles { get; set; }

        public RepairManContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Property(x => x.Roles).HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );

            modelBuilder.Entity<WorkshopCategory>().Property(x => x.Keywords).HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries).ToList()
            );
        }
    }
}
