using Blazored.LocalStorage;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;
using TodoTogether.Blazor;
using TodoTogether.Blazor.Extensions;
using TodoTogether.Blazor.Security;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<IGotrueSessionPersistence<Session>, LocalStorageSessionHandler>();
builder.Services.AddSupabase();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

await builder.Build().RunAsync();