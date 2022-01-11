using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hatogan.Domain.Exceptions
{
    public class GeneralException : Exception
    {

        public string? Details { get; set; }
        public GeneralException()
        {
        }

        public GeneralException(string message) : base(message)
        {
        }

        public GeneralException(string message, Exception innerException) : base(message, innerException)
        {
        }

        public GeneralException(string title, string details) : base(title)
        {
            this.Details = details;
        }


    }
}
