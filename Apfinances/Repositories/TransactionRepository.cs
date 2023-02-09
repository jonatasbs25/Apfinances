using Apfinances.Data;
using Apfinances.Models;

namespace Apfinances.Repositories
{
    public class TransactionRepository : ITransactionRepository, IDisposable
    {
        private readonly TransactionContext _context;

        public TransactionRepository(TransactionContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Transaction>> GetTransactions() =>
            await _context.Transaction.ToList();

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
