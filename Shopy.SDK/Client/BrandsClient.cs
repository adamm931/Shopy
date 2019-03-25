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

        public async Task<IEnumerable<BrandType>> ListAsync()
        {
            var list = await _client.GetAsync<ListResult<BrandType>>("brands");
            return list.Result;
        }
    }
}