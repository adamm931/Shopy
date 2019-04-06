using System;

namespace Shopy.Core.Exceptions
{
    public class CategoryNotFoundException : Exception
    {
        private const string ExceptionMessageFormat = "There is no category with id: {0}";

        public CategoryNotFoundException(Guid uid)
            : base(string.Format(ExceptionMessageFormat, uid))
        {

        }
    }
}
