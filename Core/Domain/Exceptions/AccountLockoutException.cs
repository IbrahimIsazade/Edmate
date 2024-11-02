using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class AccountLockoutException : Exception
    {
        public AccountLockoutException()
            : base("Account is locked")
        {
        }
    }
}
