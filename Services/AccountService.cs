using BlazorGloser.Services;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using WebGloser.Model;

using BlazorClient;

namespace BlazorClient.Services
{
    static class AccountService 
    {
        [Inject]
        static  ILocalStorageService Storage { get; set; }

        //private readonly static string BaseUrl = @"https://localhost:5000/Gloser/";
        private readonly static string BaseUrl = @"https://localhost:44331/Gloser/";
        //private readonly static string BaseUrl = @"https://webgloser.azurewebsites.net/";

        static public bool IsServerDown {get; set;} = false;

        static public async Task<string> GetErrorString()
        {
            try
            {
                string uri = BaseUrl + @"GetErrorString";
                var s = await Program.Http.GetStringAsync(uri);
                return s;
            }
            catch (Exception)
            {
                return "";
            }
 
        }


#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        static public async Task<TWord[]> GetDefaultDictionary()
#pragma warning restore CS1998 // Async method lacks 'await' operators and will run synchronously
        {
            string url = BaseUrl + @"GetDefaultDictionary";
            //string sampleUrl = "sample-data/Spanish.json";
            TWord[] aWord = null;

            

            if (IsServerDown)
            {
                // aWord = await Storage.GetItem<TWord[]>("_sample_");
                // aWord = await Program.Http.GetFromJsonAsync<TWord[]>(sampleUrl);
                // return aWord;
                List<TWord> lst = new();
                aWord = BlazorClient.Misc.FillWords(lst).ToArray();   
            }
         
            try
            {
                // aWord = await Program.Http.GetFromJsonAsync<TWord[]>(url);
                List<TWord> lst = new();
                BlazorClient.Misc.FillWords(lst);
                aWord = lst.ToArray();
            }
            catch
            {
                IsServerDown = true;
                //aWord = await Program.Http.GetFromJsonAsync<TWord[]>(sampleUrl);
                List<TWord> lst = new();
                BlazorClient.Misc.FillWords(lst);
                aWord = lst.ToArray();
            }   
            return aWord;
        }


        static public async Task<UserRecord> DoLogin(Login login)
        {
            UserRecord user;
            string url = BaseUrl + @"Login";
            user = await Put<UserRecord>(url, login);
            return user;
        }

        static public async Task<UserRecord> Register(AddUser login)
        {
            UserRecord user;
            string url = BaseUrl + @"Register";

            user = await Put<UserRecord>(url, login);
            return user;
        }

        static private async Task<T> Put<T>(string uri, object value)
        {
            var request = createRequest(HttpMethod.Put, uri, value);
            return await sendRequest<T>(request);
        }
        static private HttpRequestMessage createRequest(HttpMethod method, string uri, object value = null)
        {
            var request = new HttpRequestMessage(method, uri);
            if (value != null)
                request.Content = new StringContent(System.Text.Json.JsonSerializer.Serialize(value), Encoding.UTF8, "application/json");
            return request;
        }
        static private async Task<T> sendRequest<T>(HttpRequestMessage request)
        {
            // send request
            using var response = await Program.Http.SendAsync(request);
            if (!response.IsSuccessStatusCode)
                throw new Exception( "Something went wrong on the server" );


            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;
            // FARLIG options.Converters.Add(new StringConverter());
            return await response.Content.ReadFromJsonAsync<T>(options);
        }

   
    }
}
