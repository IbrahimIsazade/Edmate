using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class UnverifiedPhoneException : Exception
    {
        public UnverifiedPhoneException()
            : base("Phone is not verified")
        {
        }
    }
}
