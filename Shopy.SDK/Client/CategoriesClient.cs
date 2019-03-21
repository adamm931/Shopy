using Shopy.SDK.Models.Categories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK.Client
{
    public class CategoriesClient
    {
        private ShopyHttpClient _client;

        public CategoriesClient()
        {
            _client = new ShopyHttpClient();
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            var list = await _client.GetAsync<CategoryList>("categories");
            return list.Result;
        }
    }
}