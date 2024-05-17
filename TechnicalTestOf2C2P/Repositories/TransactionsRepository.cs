using System.Globalization;
using TechnicalTestOf2C2P.Contexts;
using TechnicalTestOf2C2P.Extensions;
using TechnicalTestOf2C2P.Models.Entities;
using TechnicalTestOf2C2P.Models.Transactions;
using TechnicalTestOf2C2P.Repositories.IRepositories;

namespace TechnicalTestOf2C2P.Repositories
{
    public class TransactionsRepository : ITransactionsRepository
    {
        private readonly DbContextApplication _context;

        public TransactionsRepository(DbContextApplication context)
        {
            _context = context;
        }

        public bool InsertTransaction(List<Transactions> transactions) 
        {
            try
            {
                _context.Transactions.AddRange(transactions);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                LogMessage.Add(ex.InnerException.ToString());
                return false;
            }
        }

        public List<ResponseGetAllTransactionsModel> GetAllTransactions(string currency, string dateFrom, string dateTo, string status)
        {
            var result = _context.Transactions
                .Join(
                    _context.StatusMaster,
                    a => a.Status,
                    b => b.Type,
                    (transactions, status) => new { transactions, status }
                )
                .Where(x => 
                    (!string.IsNullOrEmpty(currency) ? x.transactions.Currency == currency : true) &&
                    (!string.IsNullOrEmpty(dateFrom) ? x.transactions.TransactionDate.Value.Date >= DateTime.ParseExact(dateFrom, "dd/MM/yyyy", new CultureInfo("en-US")) : true) &&
                    (!string.IsNullOrEmpty(dateTo) ? x.transactions.TransactionDate.Value.Date <= DateTime.ParseExact(dateTo, "dd/MM/yyyy", new CultureInfo("en-US")) : true) &&
                    (!string.IsNullOrEmpty(status) ? x.transactions.Status == status : true) 
                )
                .Select(s => new ResponseGetAllTransactionsModel()
                {
                    Id = s.transactions.Id,
                    Payment = s.transactions.Amount + " " + s.transactions.Currency,
                    Status = s.status.Output
                });
            return result.ToList();
        }
    }
}
