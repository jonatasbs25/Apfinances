using Apfinances.Data;
using Apfinances.Models;
using Microsoft.EntityFrameworkCore;

namespace Apfinances.Repositories
{
    public class TransactionRepository : ITransactionRepository, IDisposable
    {
        private readonly TransactionContext _context;

        public TransactionRepository(TransactionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> FindTransactionsAsync() => await _context
            .Transactions
            .ToListAsync();

        public async Task<Transaction?> FindTransactionByIdAsync(int? id) => await _context
            .Transactions
            .FindAsync(id);

        public async Task<int> CreateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Add(transaction);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Update(transaction);

            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteTransactionAsync(Transaction transaction)
        {
            _context.Transactions.Remove(transaction);

            return await _context.SaveChangesAsync();
        }

        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
