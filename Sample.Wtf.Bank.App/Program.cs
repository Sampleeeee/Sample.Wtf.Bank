using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Sample.Wtf.Bank.App;
using Sample.Wtf.Bank.App.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped( sp => new HttpClient { BaseAddress = new Uri( ClientConfig.Current.ApiRoute ) } );
builder.Services.AddScoped<BrainService>();

await builder.Build().RunAsync();
