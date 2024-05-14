using Microsoft.AspNetCore.Mvc;
using TechnicalTestOf2C2P.Models.Common;
using TechnicalTestOf2C2P.Models.Transactions;
using TechnicalTestOf2C2P.Services.Interfaces;

namespace TechnicalTestOf2C2P.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionsController : ControllerBase
    {
        private readonly ITransactionsService _trans;

        public TransactionsController(ITransactionsService trans)
        {
            _trans = trans;
        }

        [HttpPost]
        [Route("ImportTransactions")]
        /// <summary>
        /// Import data file formats is CSV or XML
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [ProducesResponseType(typeof(ResponseModel<ResponseImportTransactionModel>), 200)]
        [ProducesResponseType(typeof(ResponseModel<object>), 400)]
        public IActionResult ImportTransactions(RequestImportTransactionModel request)
        {
            try
            {
                var response = _trans.ImportTransactions(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<object>() { IsSuccess = false, Message = ex.Message});
            }
        }

        [HttpGet]
        [Route("GetTransactions")]
        /// <summary>
        /// Get all transactions with filters
        /// </summary>
        /// <param name="currency"></param>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public IActionResult GetAllTransactions(string currency, string dateFrom, string dateTo, string status)
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseModel<object>() { IsSuccess = false, Message = ex.Message });
            }
        }
    }
}
