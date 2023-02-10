using Apfinances.Models;

namespace Apfinances.Repositories
{
    public interface ITransactionRepository
    {
        Task<IEnumerable<Transaction>> FindTransactionsAsync();
        Task<Transaction?> FindTransactionByIdAsync(int? id);
        Task<int> CreateTransactionAsync(Transaction transaction);
        Task<int> UpdateTransactionAsync(Transaction transaction);
        Task<int> DeleteTransactionAsync(Transaction transaction);
    }
}
