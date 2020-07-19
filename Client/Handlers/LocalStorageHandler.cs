using Microsoft.JSInterop;
using System.Threading.Tasks;

namespace DeliveryService.Client.Handlers
{
    public class LocalStorageHandler
    {
        private readonly IJSRuntime _jsruntime;

        public LocalStorageHandler(IJSRuntime runtime)
        {
            _jsruntime = runtime;
        }

        public async Task SetItem(string key, object value)
        {
            await _jsruntime.InvokeAsync<object>("localStorage.setItem", key, value);
        }

        public async Task RemoveItem(string key)
        {
            await _jsruntime.InvokeAsync<object>("localStorage.removeItem", key);
        }

        public async Task<T> GetItem<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                return default;
            }

            return await _jsruntime.InvokeAsync<T>("localStorage.getItem", key);
        }
    }
}
