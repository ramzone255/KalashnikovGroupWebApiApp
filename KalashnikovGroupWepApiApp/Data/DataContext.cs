using KalashnikovGroupWepApiApp.Models;
using Microsoft.EntityFrameworkCore;



namespace KalashnikovGroupWepApiApp.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Components> Components { get; set; }
        public DbSet<Deal> Deal {get; set;}
        public DbSet<Deal_linking_Payday> Deal_Linking_Payday{get; set;}
        public DbSet<Employees> Employees {get; set;}
        public DbSet<Operations> Operations {get; set;}
        public DbSet<Payday> Payday {get; set;}
        public DbSet<OperationsTypes> OperationsTypes {get; set;}
        public DbSet<Payday_linking_Payments> Payday_linking_Payments {get; set;}
        public DbSet<Payments> Payments {get; set;}
        public DbSet<PaymentType> PaymentType {get; set;}
        public DbSet<Post> Post {get; set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Payday_linking_Payments>()
                .HasKey(pc => new { pc.id_payments, pc.id_payday });
            modelBuilder.Entity<Payday_linking_Payments>()
                .HasOne(p => p.Payments)
                .WithMany(pc => pc.Payday_linking_Payments)
                .HasForeignKey(p => p.id_payments);
            modelBuilder.Entity<Payday_linking_Payments>()
                .HasOne(p => p.Payday)
                .WithMany(pc => pc.Payday_linking_Payments)
                .HasForeignKey(c => c.id_payday);

            modelBuilder.Entity<Deal_linking_Payday>()
                .HasKey(pc => new { pc.id_deal, pc.id_payday });
            modelBuilder.Entity<Deal_linking_Payday>()
                .HasOne(p => p.Deal)
                .WithMany(pc => pc.Deal_linking_Payday)
                .HasForeignKey(p => p.id_deal);
            modelBuilder.Entity<Deal_linking_Payday>()
                .HasOne(p => p.Payday)
                .WithMany(pc => pc.Deal_linking_Payday)
                .HasForeignKey(c => c.id_payday);
        }
    }

    
}
