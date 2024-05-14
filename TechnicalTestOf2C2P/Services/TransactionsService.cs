using TechnicalTestOf2C2P.Models.Common;
using TechnicalTestOf2C2P.Models.Transactions;
using TechnicalTestOf2C2P.Services.Interfaces;

namespace TechnicalTestOf2C2P.Services
{
    public class TransactionsService : ITransactionsService
    {
        public ResponseModel<ResponseImportTransactionModel> ImportTransactions(RequestImportTransactionModel request)
        {
			try
			{
				if (request?.File == null)
				{
					throw new Exception("File not found");
				}
				else
				{
                    string fileExt = Path.GetExtension(request.File.FileName);
					if (fileExt.ToLower() == ".csv")
					{

					}
					else if (fileExt.ToLower() == ".xml")
                    {

                    }
                    else
					{
                        throw new Exception("Unknown format");
                    }
                }
			}
			catch (Exception ex)
			{
				throw ex;
			}

			return new ResponseModel<ResponseImportTransactionModel>();
        }
    }
}
