using TechnicalTestOf2C2P.Models.Entities;
using TechnicalTestOf2C2P.Models.Transactions;

namespace TechnicalTestOf2C2P.Repositories.IRepositories
{
    public interface ITransactionsRepository
    {
        bool InsertTransaction(List<Transactions> transactions);
        List<ResponseGetAllTransactionsModel> GetAllTransactions(string currency, string dateFrom, string dateTo, string status);
    }
}
