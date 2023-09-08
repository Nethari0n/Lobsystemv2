using Lobsystem.Client.Services;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Lobsystem.Client.APICallers;
using Lobsystem.Client.IAPICallers;
using Blazored.Toast;
using Blazored.Modal;
using Blazored.LocalStorage;

namespace Lobsystem.Client
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebAssemblyHostBuilder.CreateDefault(args);
            builder.RootComponents.Add<App>("#app");
            builder.RootComponents.Add<HeadOutlet>("head::after");

            builder.Services.AddOptions();
            builder.Services.AddAuthorizationCore();
            builder.Services.AddScoped<CustomStateProvider>();
            builder.Services.AddScoped<AuthenticationStateProvider>(s => s.GetRequiredService<CustomStateProvider>());
            builder.Services.AddScoped<IAuthService, AuthService>();

            builder.Services.AddScoped<IEventCaller, EventCaller>();
            builder.Services.AddScoped<ICRUDCaller, CRUDCaller>();
            builder.Services.AddScoped<IScanCaller, ScanCaller>();
            builder.Services.AddScoped<ITypesCaller, TypesCaller>();
            builder.Services.AddScoped<IPostCaller, PostCaller>();
            builder.Services.AddScoped<IChipCaller, ChipCaller>();
            builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

            

            builder.Services.AddBlazoredToast();
            builder.Services.AddBlazoredModal();
            builder.Services.AddBlazoredLocalStorage();

            await builder.Build().RunAsync();
        }
    }
}