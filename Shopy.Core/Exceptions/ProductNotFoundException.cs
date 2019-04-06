using System;

namespace Shopy.Core.Exceptions
{
    public class ProductNotFoundException : Exception
    {
        private const string ExceptionMessageFormat = "There is no product with id: {0}";

        public ProductNotFoundException(Guid uid)
            : base(string.Format(ExceptionMessageFormat, uid))
        {

        }
    }
}
