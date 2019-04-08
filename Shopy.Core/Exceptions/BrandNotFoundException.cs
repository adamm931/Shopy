using System;

namespace Shopy.Core.Exceptions
{
    public class BrandNotFoundException : Exception
    {
        public BrandNotFoundException() : base("No valid brand found.")
        {

        }
    }
}
