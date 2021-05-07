using BlazorGloser.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BlazorClient
{
    public class Program
    {
        static public HttpClient Http { get; set; }
        static public bool IsLoggedIn { get; set; } = false;
        static public bool Br
        {
            get;
            set;
        } = true;


        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");

            builder.Services.
                AddScoped(sp => Http = new HttpClient 
                { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) })
                .AddSingleton<ILocalStorageService, LocalStorageService>();


            await builder.Build().RunAsync();
        }
    }
}
