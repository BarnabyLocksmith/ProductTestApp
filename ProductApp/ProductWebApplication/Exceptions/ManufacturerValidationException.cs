namespace ProductWebApplication.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class ManufacturerValidationException : Exception
    {
        public ManufacturerValidationException()
        {

        }

        public ManufacturerValidationException(string message) : base(message)
        {

        }

        public ManufacturerValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
