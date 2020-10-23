using Dapper;
using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace refactor_this.Repository
{
    /// <summary>
    /// Data Access Class for all SQL Operations
    /// </summary>
    public class DataAccess
    {
        /// <summary>
        /// Get All Accounts
        /// </summary>
        /// <returns>List Of Accounts <see cref="List{Account}"/></returns>
        public List<Account> GetAccounts()
        {
            using (var connection = Helpers.NewConnection())
            {
                var accounts = connection.QueryAsync<Account>("GetAccounts", commandType: CommandType.StoredProcedure).Result.ToList();
                return accounts;
            }
        }

        /// <summary>
        /// Get All Transactions
        /// </summary>
        /// <param name="id">AccountId of transaction</param>
        /// <returns>List Of Transaction <see cref="List{Transaction}"/> </returns>
        public List<Transaction> GetTransactions(Guid id)
        {
            using (var connection = Helpers.NewConnection())
            {
                var sqlParams = new { Id = id };
                var transactions = connection.QueryAsync<Transaction>("GetTransactions", sqlParams, commandType: CommandType.StoredProcedure).Result.ToList();
                return transactions;
            }
        }

        /// <summary>
        /// Get Account By Id
        /// </summary>
        /// <param name="id">Id of Account</param>
        /// <returns>Account <see cref="Account"/></returns>
        public Account GetAccount(Guid id)
        {
            using (var connection = Helpers.NewConnection())
            {
                var sqlParams = new { Id = id };
                var account = connection.QueryAsync<Account>("GetAccountById", sqlParams, commandType: CommandType.StoredProcedure).Result.ToList().FirstOrDefault();
                return account;
            }
        }

        /// <summary>
        /// Save the Account Record
        /// </summary>
        /// <param name="accRecord">Account Record Object</param>
        /// <param name="isNew">Is new record or existing record</param>
        public void AccountSave(Account accRecord, bool isNew)
        {
            using (var connection = Helpers.NewConnection())
            {
                if (isNew)
                    connection.QueryAsync($"insert into Accounts (Id, Name, Number, Amount) values ('{Guid.NewGuid()}', '{accRecord.Name}', {accRecord.Number}, 0)");
                else
                    connection.QueryAsync($"update Accounts set Name = '{accRecord.Name}' where Id = '{accRecord.Id}'");
            }
        }

        /// <summary>
        /// Delete the record
        /// </summary>
        /// <param name="accRecord">Account record to be deleted</param>
        public void AccountDelete(Account accRecord)
        {
            using (var connection = Helpers.NewConnection())
            {
                var sqlParams = new { Id = accRecord.Id };
                connection.QueryAsync("DeleteAccountById", sqlParams, commandType: CommandType.StoredProcedure);
            }
        }

        /// <summary>
        /// Add transaction record
        /// </summary>
        /// <param name="id">Transaction Id</param>
        /// <param name="transaction">Transaction record</param>
        public void AddTrans(Guid id, Transaction transaction)
        {
            using (var connection = Helpers.NewConnection())
            {
                connection.QueryAsync($"update Accounts set Amount = Amount + {transaction.Amount} where Id = '{id}'");
                connection.QueryAsync($"INSERT INTO Transactions (Id, Amount, Date, AccountId) VALUES ('{Guid.NewGuid()}', {transaction.Amount}, '{DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")}', '{id}')");
            }
        }
    }
}