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

            modelBuilder.Entity<ProductEntity>(x =>
            {
                x.HasKey(x => x.Id);
            });

            modelBuilder.Entity<UserEntity>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasMany(x=>x.Transactions)
                .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
            modelBuilder.Entity<TransactionEntity>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.User)
                  .WithMany(t => t.Transactions)
                .HasForeignKey(x => x.UserId)
                  .OnDelete(DeleteBehavior.Restrict);    
            });

            modelBuilder.Entity<TransactionProductEntity>(x =>
            {
                x.HasKey(x => x.Id);
                x.HasOne(x => x.Product)
                .WithMany(x => x.TransactionProduct)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);



                x.HasOne(x => x.Transaction)
                    .WithMany(x => x.ShoppingList)
                    .HasForeignKey(x => x.ProductId)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
