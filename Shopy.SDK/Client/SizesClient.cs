using Shopy.SDK.ApiModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.SDK.Client
{
    public class SizesClient
    {
        private ShopyHttpClient _client;

        public SizesClient(ShopyHttpClient client)
        {
            _client = client;
        }

        public async Task<IEnumerable<Size>> ListAsync()
        {
            var list = await _client.GetAsync<ListResult<Size>>("sizes");
            return list.Result;
        }
    }
}