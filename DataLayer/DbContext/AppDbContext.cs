using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Common.Constants;
using Common.Entities;
using Common.Entities.Identity;

namespace DataLayer.DbContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<UserInfo> UserInfos { get; set; }

        public DbSet<DiseaseHistory> DiseaseHistories { get; set; }

        public DbSet<Metrics> Metrics { get; set; }

        public DbSet<Treatment> Treatments { get; set; }

        public DbSet<Medicine> Medicines { get; set; }

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

            modelBuilder.Entity<DiseaseHistory>()
              .HasOne(p => p.PatientInfo)
              .WithMany()
              .HasForeignKey(ot => ot.PatientInfoId);

            modelBuilder.Entity<Treatment>()
              .HasOne(p => p.Medicine)
              .WithMany()
              .HasForeignKey(ot => ot.MedicineId);

            modelBuilder.Entity<Medicine>();

            modelBuilder.Entity<Metrics>();
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
