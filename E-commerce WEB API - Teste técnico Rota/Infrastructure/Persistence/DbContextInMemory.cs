using E_commerce_WEB_API___Teste_técnico_Rota.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Persistence
{
    public class DbContextInMemory : DbContext
    {
        public DbContextInMemory(DbContextOptions<DbContextInMemory> options) : base(options)
        {
        }

        public DbSet<ProductEntity> Product { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<TransactionEntity> Transaction { get; set; }
        public DbSet<TransactionProductEntity> TransactionProduct { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Product
            modelBuilder.Entity<ProductEntity>(x =>
            {
                x.HasKey(p => p.Id);

                x.HasMany(p => p.TransactionProductsList)
                 .WithOne(tp => tp.Product)
                 .HasForeignKey(tp => tp.ProductId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // User
            modelBuilder.Entity<UserEntity>(x =>
            {
                x.HasKey(u => u.Id);

                x.HasMany(u => u.TransactionsList)
                 .WithOne(t => t.User)
                 .HasForeignKey(t => t.UserId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            // Transaction
            modelBuilder.Entity<TransactionEntity>(x =>
            {
                x.HasKey(t => t.Id);

                x.HasOne(t => t.User)
                 .WithMany(u => u.TransactionsList)
                 .HasForeignKey(t => t.UserId)
                 .OnDelete(DeleteBehavior.Restrict);

                x.HasMany(t => t.TransactionProductsList)
                 .WithOne(tp => tp.Transaction)
                 .HasForeignKey(tp => tp.TransactionId)
                 .OnDelete(DeleteBehavior.Restrict);
            });

            //N:N
            modelBuilder.Entity<TransactionProductEntity>(x =>
            {
                x.HasKey(tp => new { tp.TransactionId, tp.ProductId });

                x.HasOne(tp => tp.Product)
                 .WithMany(p => p.TransactionProductsList)
                 .HasForeignKey(tp => tp.ProductId)
                 .OnDelete(DeleteBehavior.Restrict);

                x.HasOne(tp => tp.Transaction)
                 .WithMany(t => t.TransactionProductsList)
                 .HasForeignKey(tp => tp.TransactionId)
                 .OnDelete(DeleteBehavior.Restrict);

                x.Property(tp => tp.Quantity)
                 .IsRequired();
            });
        }

    }
}

