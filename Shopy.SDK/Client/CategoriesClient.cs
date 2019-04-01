using Shopy.Sdk.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Sdk.Client
{
    public class CategoriesClient
    {
        private ShopyHttpClient _client;

        public CategoriesClient(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Category>> ListAsync()
        {
            var list = await _client.GetAsync<ListResult<Category>>("categories");
            return list.Result;
        }

        public async Task<IEnumerable<Category>> ListWithProductsAsync()
        {
            var list = await _client.GetAsync<ListResult<Category>>($"categories/?withProductsOnly={true}");
            return list.Result;
        }

        public async Task AddAsync(Category category)
        {
            await _client.PostAsync<Category, object>("categories", category);
        }
    }
}