using TechnicalTestOf2C2P.Contexts;
using TechnicalTestOf2C2P.Extensions;
using TechnicalTestOf2C2P.Models.Entities;
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
    }
}
