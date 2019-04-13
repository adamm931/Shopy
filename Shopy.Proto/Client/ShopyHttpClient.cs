using Newtonsoft.Json;
using Shopy.Proto.ResponseHandler;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Shopy.Proto.Client
{
    public class ShopyHttpClient
    {
        private HttpClient _httpClient;

        private const string ApplicationJson = "application/json";

        public ShopyHttpClient(string baseAddres)
        {
            _httpClient = new HttpClient(new ResponseMessageHandler())
            {
                BaseAddress = new Uri(baseAddres)
            };
        }

        public async Task<T> GetAsync<T>(string requestPath)
        {
            return await SendAsync<object, T>(requestPath, HttpMethod.Get);
        }

        public async Task<TResult> PostAsync<TRequest, TResult>(string requestPath, TRequest content = null)
            where TRequest : class
        {
            return await SendAsync<TRequest, TResult>(requestPath, HttpMethod.Post, content);
        }

        public async Task PutAsync<TRequest>(string requestPath, TRequest content)
            where TRequest : class
        {
            await SendAsync<TRequest, object>(requestPath, HttpMethod.Put, content);
        }

        public async Task DeleteAsync(string requestPath)
        {
            await SendAsync<object, object>(requestPath, HttpMethod.Delete);
        }

        private async Task<TResult> SendAsync<TRequest, TResult>(
            string requestPath, HttpMethod method, TRequest content = null)
            where TRequest : class
        {
            var request = new HttpRequestMessage(method, requestPath);

            if (content != null)
            {
                request.Content = new StringContent(await SerilizeAsync(content), Encoding.UTF8, ApplicationJson);
            }

            var response = await _httpClient.SendAsync(request);

            if (response == null)
            {
                return default(TResult);
            }

            var stream = await response.Content.ReadAsStringAsync();
            return await DeserializeAsync<TResult>(stream);

        }

        private Task<T> DeserializeAsync<T>(string json)
        {
            return Task.Factory.StartNew(
                () => JsonConvert.DeserializeObject<T>(json));
        }

        private Task<string> SerilizeAsync<T>(T data)
        {
            return Task.Factory.StartNew(
                () => JsonConvert.SerializeObject(data));
        }
    }
}