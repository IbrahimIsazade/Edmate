using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UserNameOrPasswordIncorrectException : Exception
    {
        public UserNameOrPasswordIncorrectException()
            : base("User Name Or Password Incorrect")
        {
        }
    }
}
