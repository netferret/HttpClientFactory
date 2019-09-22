using System.Net.Http;

namespace HttpFactoryProject
{
    public class HttpService : IHttpService
    {
        public IHttpClientFactory _httpClientFactory { get; set; }

        public HttpService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async System.Threading.Tasks.Task<string> CallAPIAsync() {
            var client = _httpClientFactory.CreateClient("Experian");

            var result = await client.GetStringAsync("https://www.google.com");

            return result;
        }
    }
}