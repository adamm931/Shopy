using Shopy.Core.Domain.Exceptions;
using System;

namespace Shopy.Core.Domain
{
    public class NameIsEmptyException : Exception
    {
        public NameIsEmptyException() : base(ExceptionsLocalization.NameIsEmpty)
        {
        }
    }
}
