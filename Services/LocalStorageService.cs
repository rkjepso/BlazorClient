using Microsoft.JSInterop;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorClient.Model;
using System;

namespace BlazorGloser.Services
{
    public interface ILocalStorageService
    {
        Task<T> GetItem<T>(string key);
        Task SetItem<T>(string key, T value);    
        Task RemoveItem(string key);

        void SetItemSync<T>(string key, T value);

        Data GetData();
        Task SetData(Data dt);
    }

    public class LocalStorageService : ILocalStorageService
    {
        private readonly IJSRuntime _jsr;

        private Data _dt = new ();

        public LocalStorageService(IJSRuntime jsRuntime)
        {
            _jsr = jsRuntime;
            LoadParams();
        }

        public Data GetData() => _dt;
        public async Task SetData(Data dt)
        {
            await SetItem("__gloser", dt);
            _dt = dt;
        }
        

        public async Task LoadParams()
        {
            try
            {
                _dt = await GetItem<Data>("__gloser");
                if (_dt.Equals(default(Data)))
                    _dt.Default();
            }
            catch (Exception)
            {
                _dt.Default();
            }
            //_dtTest = _dt;
            //_dtTest.DefaultsForTest();
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



        public void SetItemSync<T>(string key, T value)
        {
            string jsonStr = JsonSerializer.Serialize(value);
           _jsr.InvokeVoidAsync("localStorage.setItem", key, jsonStr);
        }

        public async Task RemoveItem(string key)
        {
            await 
            _jsr.InvokeVoidAsync("localStorage.removeItem", key) ;
        }
    }
}