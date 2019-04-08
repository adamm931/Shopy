namespace Shopy.Core.Models
{
    public class SizeOrder
    {
        public static int GetOrderForEid(string eId)
        {
            switch (eId)
            {
                case "S": return 0;
                case "M": return 1;
                case "L": return 2;
                case "XL": return 3;
                default: return -1;
            }
        }
    }
}
