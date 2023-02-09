using Apfinances.Models;

namespace Apfinances.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> GetTransactions();
    }
}
