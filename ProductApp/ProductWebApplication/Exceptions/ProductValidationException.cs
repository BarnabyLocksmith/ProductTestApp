namespace ProductWebApplication.Exceptions
{
    using System;

    public class ProductValidationException : Exception
    {
        public ProductValidationException()
        {

        }

        public ProductValidationException(string message) : base(message)
        {

        }

        public ProductValidationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
