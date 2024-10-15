using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace BankProject.Exceptions
{
    public class InvalidMoneyException : Exception
    {
        private static readonly string _message = "Money cannot be negative";
        public InvalidMoneyException():base(_message)
        {
        }

        public InvalidMoneyException(string? message) : base(message)
        {
        }

        public InvalidMoneyException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InvalidMoneyException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}
