using DeliveryService.Shared.Constants;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DeliveryService.Client.Handlers
{
    public class HttpHandler
    {
        private readonly HttpClient _client;
        private readonly LocalStorageHandler _storage;

        public HttpHandler(HttpClient client,LocalStorageHandler storage)
        {
            _client = client;
            _storage = storage;

        }

        private async Task AddHeader()
        {
            _client.DefaultRequestHeaders.Authorization = 
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer",await _storage.GetItem<string>(Constants.JWTKey));
        }
        public async Task<T> GetJsonAsync<T>(string url)
        {
            await AddHeader();
            var result = await _client.GetAsync(url);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }

        public async Task<T> PutAsync<T>(string url, object model)
        {
            await AddHeader();
            var json = JsonConvert.SerializeObject(model);
            var payLoad = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PutAsync(url, payLoad);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }

        public async Task<T> PostAsync<T>(string url, object model)
        {
            await AddHeader();
            var json = JsonConvert.SerializeObject(model);
            var payLoad = new StringContent(json, Encoding.UTF8, "application/json");
            var result = await _client.PostAsync(url, payLoad);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }

        public async Task<T> DeleteAsync<T>(string url)
        {
            await AddHeader();
            var result = await _client.DeleteAsync(url);
            var answer = await result.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<T>(answer);
            return data;
        }

    }
}
