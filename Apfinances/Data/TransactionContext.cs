using Apfinances.Models;
using Microsoft.EntityFrameworkCore;

namespace Apfinances.Data
{
    public class TransactionContext : DbContext
    {
        public TransactionContext(DbContextOptions<TransactionContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transaction { get; set; } = null!;
    }
}
