using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Shopy.SDK.ErrorHandler
{
    public class ResponseMessageHandler : DelegatingHandler
    {
        public ResponseMessageHandler() : base(new HttpClientHandler())
        { }

        protected async override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            var response = await base.SendAsync(request, cancellationToken);

            if (response.IsSuccessStatusCode)
            {
                return response;
            }

            if (response.StatusCode == HttpStatusCode.NotFound)
            {
                return null;
            }

            var stream = await response.Content.ReadAsStringAsync();
            throw new Exception(stream);
        }
    }
}
