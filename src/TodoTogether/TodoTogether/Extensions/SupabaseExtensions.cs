using Supabase;

namespace TodoTogether.Extensions;

public static class SupabaseExtensions
{
    public static IServiceCollection AddSupabase(this IServiceCollection services, string url, string publicKey)
    {
        var options = new SupabaseOptions
        {
            AutoRefreshToken = true,
            AutoConnectRealtime = true,
            // SessionHandler = new SupabaseSessionHandler() <-- This must be implemented by the developer
        };
        
        return services.AddSingleton(new Client(url, publicKey, options));
    }
}