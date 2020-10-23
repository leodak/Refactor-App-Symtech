using refactor_this.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace refactor_this.Repository
{
    public interface IDataAccess
    {
        List<Account> GetAccounts();
        Account GetAccount(Guid id);
        void AccountSave(Account accRecord, bool isNew);
        void AccountDelete(Account delRecord);
    }
}
