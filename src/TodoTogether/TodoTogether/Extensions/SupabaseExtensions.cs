using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Supabase;

namespace TodoTogether.Extensions;

public static class SupabaseExtensions
{
    public static void AddSupabase(this WebAssemblyHostBuilder builder)
    {
        var url = builder.Configuration["supabase:url"];
        if (string.IsNullOrWhiteSpace(url))
            throw new InvalidOperationException("Cannot find supabase url");

        var key = builder.Configuration["supabase:key"];
        if (string.IsNullOrWhiteSpace(key))
            throw new InvalidOperationException("Cannot find supabase key");
        
        var options = new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
            // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
        };
        
        builder.Services.AddSingleton(new Client(url, key, options));
    }
}