using Shopy.Proto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Proto.Client
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
            var list = await _client.GetAsync<ListResponse<Brand>>("brands");
            return list.Result;
        }
    }
}