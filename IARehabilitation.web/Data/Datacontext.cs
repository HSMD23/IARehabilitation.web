using IARehabilitation.web.Data.Entities;
using Microsoft.EntityFrameworkCore;


namespace IARehabilitation.web.Data
{
    public class DataContext : DbContext 
    {
        
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Consulte> Consultes { get; set; }
        public DbSet<InjuriesDictionary> InjuriesDictionaries { get; set; }
        public DbSet<MedicalHistory> MedicalHistories { get; set; }
        public DbSet<Profesional> Profesionals { get; set; }
        public DbSet<Sportsman> Sportsmen { get; set; }
        public DbSet<TreatmentDetail> TreatmentDetails { get; set; }
        public DbSet<TreatmentDictionary> TreatmentDictionaries { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Profesional>()
       .HasOne(p => p.User)
       .WithOne(u => u.Profesional)
       .HasForeignKey<Profesional>(p => p.UserId);

            modelBuilder.Entity<Sportsman>()
       .HasOne(s => s.User)
       .WithOne(u => u.Sportsman)
       .HasForeignKey<Sportsman>(s => s.UserId);

        }
    }
}


