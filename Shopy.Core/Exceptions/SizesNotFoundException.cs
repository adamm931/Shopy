using System;

namespace Shopy.Core.Exceptions
{
    public class SizesNotFoundException : Exception
    {
        public SizesNotFoundException() : base("No valid sizes found.")
        {

        }
    }
}
