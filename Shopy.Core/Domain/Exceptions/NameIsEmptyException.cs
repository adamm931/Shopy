using Shopy.Core.Domain.Exceptions;

namespace Shopy.Core.Domain
{
    public class NameIsEmptyException : LocalizedException
    {
        public NameIsEmptyException() : base("NameIsEmpty")
        {
        }
    }
}
