using Shopy.SDK.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK.Client
{
    public class BrandsClient
    {
        private ShopyHttpClient _client;

        public BrandsClient(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Brand>> ListAsync()
        {
            var list = await _client.GetAsync<ListResult<Brand>>("brands");
            return list.Result;
        }
    }
}