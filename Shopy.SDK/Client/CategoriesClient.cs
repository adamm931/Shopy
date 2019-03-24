using Shopy.SDK.ApiModels.Categories;
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

        public async Task<IEnumerable<Category>> ListWithProductsAsync()
        {
            var list = await _client.GetAsync<CategoryList>($"categories/?withProductsOnly={true}");
            return list.Result;
        }

        public async Task AddAsync(AddCategory addCategory)
        {
            await _client.PostAsync<AddCategory, object>("categories", addCategory);
        }
    }
}