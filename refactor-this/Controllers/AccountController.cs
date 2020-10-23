using refactor_this.Models;
using refactor_this.Repository;
using System;
using System.Net;
using System.Web.Http;

namespace refactor_this.Controllers
{
    /// <summary>
    /// Account Controller for all account endpoints
    /// </summary>
    public class AccountController : ApiController
    {
        /// <summary>
        /// Data Access Class instance
        /// </summary>
        private readonly DataAccess _dataAccess = new DataAccess();

        /// <summary>
        /// Get Account by Id
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Action Result</returns>
        [HttpGet, Route("api/Accounts/{id}")]
        public IHttpActionResult GetAccountById(Guid id)
        {
            try
            {
                var account = _dataAccess.GetAccount(id);
                return Ok(account);
            }
            catch (Exception ex)
            {
                //logging to be done
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns>Action Result</returns>
        [HttpGet, Route("api/Accounts")]
        public IHttpActionResult GetAccounts()
        {
            try
            {
                var accounts = _dataAccess.GetAccounts();
                return Ok(accounts);
            }
            catch (Exception ex)
            {
                //logging to be done
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }
       
        /// <summary>
        /// Add Account Record
        /// </summary>
        /// <param name="account">Account Record <see cref="Account"/></param>
        /// <returns>Action Result</returns>
        [HttpPost, Route("api/Accounts")]
        public IHttpActionResult Add(Account account)
        {
            try
            {
                _dataAccess.AccountSave(account, true);
                return Ok();
            }
            catch (Exception ex)
            {
                //logging to be done
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Update Account Record
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <param name="account">Account Record <see cref="Account"/></param>
        /// <returns>Action Result</returns>
        [HttpPut, Route("api/Accounts/{id}")]
        public IHttpActionResult UpdateAccount(Guid id, Account account)
        {
            try
            {
                var existing = _dataAccess.GetAccount(id);
                existing.Name = account.Name;
                _dataAccess.AccountSave(existing, false);
                return Ok();
            }
            catch (Exception ex)
            {
                //logging to be done
                return Content(HttpStatusCode.BadRequest, ex.Message);
            }
        }

        /// <summary>
        /// Delete Account Record
        /// </summary>
        /// <param name="id">Account Id</param>
        /// <returns>Action Result</returns>
        [HttpDelete, Route("api/Accounts/{id}")]
        public IHttpActionResult DeleteAccount(Guid id)
        {
            try
            {
                var existing = _dataAccess.GetAccount(id);
                _dataAccess.AccountDelete(existing);
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