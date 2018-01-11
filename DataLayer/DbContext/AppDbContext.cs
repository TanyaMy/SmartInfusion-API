using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Common.Constants;
using Common.Entities;
using Common.Entities.Identity;
using Common.Entities.OrganRequests;

namespace DataLayer.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<PatientRequest> PatientRequests { get; set; }
        public DbSet<Clinic> Clinics { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConfigurationConstants.DbConnection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            RemoveCascadeDeletingGlobally(modelBuilder);


            modelBuilder.Entity<AppUser>()
                .HasOne(p => p.UserInfo)
                .WithOne(i => i.AppUser)
                .HasForeignKey<UserInfo>(b => b.AppUserId);

            modelBuilder.Entity<PatientRequest>()
                .HasOne(ot => ot.PatientInfo)
                .WithMany()
                .HasForeignKey(ot => ot.PatientInfoId);            
        }

        private void RemoveCascadeDeletingGlobally(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
    }
}
