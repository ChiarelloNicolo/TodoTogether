using Supabase;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;
using TodoTogether.Blazor.Security;
using Client = Supabase.Client;

namespace TodoTogether.Blazor.Extensions;

public static class SupabaseExtensions
{
    public static void AddSupabase(this IServiceCollection services)
    {
        

        services.AddSingleton(provider =>
            {
                var configuration = provider.GetRequiredService<IConfiguration>();
                
                var url = configuration["supabase:url"];
                if (string.IsNullOrWhiteSpace(url))
                    throw new InvalidOperationException("Cannot find supabase url");

                var key = configuration["supabase:key"];
                if (string.IsNullOrWhiteSpace(key))
                    throw new InvalidOperationException("Cannot find supabase key");

                var sessionHandler = provider.GetRequiredService<LocalStorageSessionHandler>();
                
                var options = new SupabaseOptions
                {
                    AutoRefreshToken = true,
                    AutoConnectRealtime = true,
                    SessionHandler = sessionHandler
                };
                return new Client(url, key, options); 
                
            }
        );
    }
}