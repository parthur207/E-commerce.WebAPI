using Microsoft.EntityFrameworkCore;

namespace E_commerce_WEB_API___Teste_técnico_Rota.Persistence
{
    public class DbContextInMemory : DbContext
    {
        public DbContextInMemory(DbContextOptions<DbContextInMemory> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
