using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Exceptions
{
    public class BadRequestt : Exception
    {
        public BadRequestt(string message) : base(message)
        {
        }

        public BadRequestt(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
