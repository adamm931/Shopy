namespace Shopy.Sdk.Models
{
    public class ProductListResponse : ListResponse<Product>
    {
        public int TotalRecords { get; set; }
    }
}
