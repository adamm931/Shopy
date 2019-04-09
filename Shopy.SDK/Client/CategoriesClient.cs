using Shopy.SDK.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK.Client
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
            var list = await _client.GetAsync<ListResponse<Category>>("categories");
            return list.Result;
        }

        public async Task<IEnumerable<Category>> ListWithProductsAsync()
        {
            var list = await _client.GetAsync<ListResponse<Category>>($"categories/?withProductsOnly={true}");
            return list.Result;
        }

        public async Task AddAsync(Category category)
        {
            await _client.PostAsync<Category, object>("categories", category);
        }

        public async Task DeleteAsync(Guid uid)
        {
            await _client.DeleteAsync<Category>($"categories/{uid}");
        }
    }
}