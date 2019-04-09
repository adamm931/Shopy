using Shopy.Proto.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Shopy.Proto.Client
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
            var list = await _client.GetAsync<ListResponse<Size>>("sizes");
            return list.Result;
        }
    }
}