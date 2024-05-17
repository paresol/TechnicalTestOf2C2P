using TechnicalTestOf2C2P.Models.Entities;

namespace TechnicalTestOf2C2P.Repositories.IRepositories
{
    public interface ITransactionsRepository
    {
        bool InsertTransaction(List<Transactions> transactions);
    }
}
