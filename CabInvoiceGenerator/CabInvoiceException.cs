using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
    public class InvoiceException : Exception
    {
        public enum ExceptionType
        {
            INVALID_DISTANCE, INVALID_RIDE_TYPE, INVALID_TIME, INVALID_USER_ID, NULL_RIDES
        }
        public ExceptionType type;
        /// <summary>
        /// Parameter Constructure for for setting exception type and throwing Exception type
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public InvoiceException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}