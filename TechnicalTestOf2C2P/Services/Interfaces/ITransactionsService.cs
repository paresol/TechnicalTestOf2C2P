﻿using TechnicalTestOf2C2P.Models.Common;
using TechnicalTestOf2C2P.Models.Transactions;

namespace TechnicalTestOf2C2P.Services.Interfaces
{
    public interface ITransactionsService
    {
        ResponseModel<ResponseImportTransactionModel> ImportTransactions(RequestImportTransactionModel request);
        ResponseModel<List<ResponseGetAllTransactionsModel>> GetAllTransactions(string currency, string dateFrom, string dateTo, string status);
    }
}
