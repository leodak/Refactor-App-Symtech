using refactor_this.Models;
using refactor_this.Repository;
using System;
using System.Net;
using System.Web.Http;

namespace refactor_this.Controllers
{
    /// <summary>
    /// Transaction Controller for transaction endpoints
    /// </summary>
    public class TransactionController : ApiController
    {
        /// <summary>
        /// Data Access Class instance
        /// </summary>
        private readonly DataAccess _dataAccess = new DataAccess();

        /// <summary>
        /// Get Transactions
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>ActionResult</returns>
        [HttpGet, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult GetTransactions(Guid id)
        {
            try
            {
                var transactions = _dataAccess.GetTransactions(id);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                //logging to be done
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Add Transaction Record
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <param name="transaction">Transaction Record</param>
        /// <returns>ActionResult</returns>
        [HttpPost, Route("api/Accounts/{id}/Transactions")]
        public IHttpActionResult AddTransaction(Guid id, Transaction transaction)
        {
            try
            {
                _dataAccess.AddTrans(id, transaction);
                return Ok();
            }
            catch (Exception ex)
            {
                //logging to be done
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
          
        }
    }
}