using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebMVC.Application.Common.Exceptions
{
    class BadRequestExcpetion : Exception
    {
        public BadRequestExcpetion()
    : base()
        {
        }

        public BadRequestExcpetion(string message)
            : base(message)
        {
        }

        public BadRequestExcpetion(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}
