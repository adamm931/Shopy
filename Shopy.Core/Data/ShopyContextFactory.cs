using Shopy.Data;

namespace Shopy.Core.Data
{
    public class ShopyContextFactory
    {
        public static IShopyContext CreateContext()
        {
            return new ShopyContext();
        }
    }
}
