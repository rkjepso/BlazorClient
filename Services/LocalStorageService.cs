using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;

namespace BlazorGloser.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);
        Task SetItem<T>(string key, T value);
        Task RemoveItem(string key);
    }

    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsr;

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsr = jsRuntime;
        }

        public async Task<T> GetItem<T>(string key)
        {
            string json = await  _jsr.InvokeAsync<string>("localStorage.getItem", key);
            return JsonSerializer.Deserialize<T>(json);
        }

        public async Task SetItem<T>(string key, T value)
        {
            string jsonStr = JsonSerializer.Serialize(value);
             await 
            _jsr.InvokeVoidAsync("localStorage.setItem", key, jsonStr) ;
        }

        public async Task RemoveItem(string key)
        {
            await 
            _jsr.InvokeVoidAsync("localStorage.removeItem", key) ;
        }
    }
}