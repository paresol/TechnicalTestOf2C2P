using Microsoft.VisualBasic.FileIO;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text;
using System.Xml.Schema;
using System.Xml;
using System.Xml.Serialization;
using TechnicalTestOf2C2P.Models.Common;
using TechnicalTestOf2C2P.Models.Entities;
using TechnicalTestOf2C2P.Models.Transactions;
using TechnicalTestOf2C2P.Repositories.IRepositories;
using TechnicalTestOf2C2P.Services.Interfaces;
using static System.Runtime.InteropServices.JavaScript.JSType;
using TechnicalTestOf2C2P.Validations;
using System;
using TechnicalTestOf2C2P.Extensions;

namespace TechnicalTestOf2C2P.Services
{
    public class TransactionsService : ITransactionsService
    {
        private readonly ITransactionsRepository _transactionsRepository;

        public TransactionsService(ITransactionsRepository transactionsRepository)
        {
            _transactionsRepository = transactionsRepository;
        }

        public ResponseModel<ResponseImportTransactionModel> ImportTransactions(RequestImportTransactionModel request)
        {
			try
			{
                var response = new ResponseModel<ResponseImportTransactionModel>();
                if (request?.File == null)
				{
					throw new Exception("File not found");
				}
				else
				{
                    if (request.File.Length > 1048576)
					{
                        throw new Exception("File size > 1 MB");
                    }
					else
					{
                        List<Transactions> transactions = new List<Transactions>();
                        string fileExt = Path.GetExtension(request.File.FileName);
                        if (fileExt.ToLower() == ".csv")
                        {
                            ReadCSV(request.File, ref transactions);
                        }
                        else if (fileExt.ToLower() == ".xml")
                        {
                            ReadXML(request.File, ref transactions);
                        }
                        else
                        {
                            throw new Exception("Unknown format");
                        }

                        if (LogMessage.Get().Count == 0)
                        {
                            string error = string.Empty;
                            response.success = _transactionsRepository.InsertTransaction(transactions);
                            if (response.success)
                            {
                                response.Message = "Success";
                                response.Data = new ResponseImportTransactionModel()
                                {
                                    TransactionId = transactions.Select(s => s.Id).ToList(),
                                    Count = transactions.Count
                                };
                            }
                            else
                            {
                                throw new Exception("Can't insert data with something wrong");
                            }
                        }
                        else
                        {
                            throw new Exception("Data incorrect");
                        }
                    }
                }

                return response;
            }
			catch (Exception ex)
			{
				throw ex;
			}
        }

        public ResponseModel<List<ResponseGetAllTransactionsModel>> GetAllTransactions(string currency, string dateFrom, string dateTo, string status)
        {
            try
            {
                var response = new ResponseModel<List<ResponseGetAllTransactionsModel>>();
                response.Data = _transactionsRepository.GetAllTransactions(currency, dateFrom, dateTo, status);
                if (response.Data.Count == 0)
                {
                    response.Message = "Data not found";
                }
                return response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadCSV(IFormFile file, ref List<Transactions> transactions)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    string content = Encoding.UTF8.GetString(fileBytes);
                    LogRequest.Add(content);

                    using (StringReader sr = new StringReader(content))
                    {
                        string line = string.Empty;
                        for (int i = 0; (line = sr.ReadLine()) != null; i++)
                        {
                            using (TextFieldParser parser = new TextFieldParser(new StringReader(line)))
                            {
                                parser.HasFieldsEnclosedInQuotes = true;
                                parser.SetDelimiters(",");

                                string[] fields;
                                while (!parser.EndOfData)
                                {
                                    fields = parser.ReadFields();
                                    decimal? amount = null;
                                    DateTime? datetime = null;
                                    
                                    if (fields[1] != "")
                                    {
                                        amount = Convert.ToDecimal(fields[1]);
                                    }
                                    if (fields[3] != "")
                                    {
                                        datetime = DateTime.ParseExact(fields[3], "dd/MM/yyyy HH:mm:ss", new CultureInfo("en-US"));
                                    }
                                    
                                    Transactions row = new Transactions()
                                    {
                                        Id = fields[0],
                                        Amount = amount,
                                        Currency = fields[2],
                                        TransactionDate = datetime,
                                        Status = fields[4],
                                    };
                                    ValidateModel(row, ref transactions);
                                }
                                parser.Close();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ReadXML(IFormFile file, ref List<Transactions> transactions) 
        {
            try
            {
                using (MemoryStream ms = new MemoryStream())
                {
                    file.CopyTo(ms);
                    byte[] fileBytes = ms.ToArray();
                    string content = Encoding.UTF8.GetString(fileBytes);
                    LogRequest.Add(content);

                    XmlSerializer serializer = new XmlSerializer(typeof(GetXmlTransactionModel));
                    using (StringReader sr = new StringReader(content))
                    {
                        GetXmlTransactionModel _transactions = (GetXmlTransactionModel)serializer.Deserialize(sr);
                        foreach (var item in _transactions.TransactionList)
                        {
                            Transactions row = new Transactions()
                            {
                                Id = item.Id,
                                Amount = item.PaymentDetails.Amount,
                                Currency = item.PaymentDetails.CurrencyCode,
                                TransactionDate = item.TransactionDate,
                                Status = item.Status,
                            };
                            ValidateModel(row, ref transactions);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void ValidateModel(Transactions row, ref List<Transactions> transactions)
        {
            var validationResults = ModelValidator.Validate(row);
            if (validationResults.Count == 0)
            {
                transactions.Add(row);
            }
            else
            {
                List<string> validateMessages = validationResults.Select(s => s.ErrorMessage).ToList();
                LogMessage.AddRange(validateMessages);
            }
        }
    }
}
