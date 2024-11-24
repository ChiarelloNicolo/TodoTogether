using Blazored.LocalStorage;
using Newtonsoft.Json;
using Supabase.Gotrue;
using Supabase.Gotrue.Interfaces;

namespace TodoTogether.Blazor.Security;

public class LocalStorageSessionHandler : IGotrueSessionPersistence<Session>
{
    private readonly ISyncLocalStorageService _localStorage;
    
    private const string SessionKey = "todotogether.session";


    public LocalStorageSessionHandler(ISyncLocalStorageService localStorage)
    {
        _localStorage = localStorage;
    }
    
    public void SaveSession(Session session)
    {
        try
        {
            var serializedSession = JsonConvert.SerializeObject(session);
            _localStorage.SetItem(SessionKey, serializedSession);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while trying to save the session to the local storage: {ex}");
        }
    }

    public void DestroySession() => _localStorage.RemoveItem(SessionKey);

    public Session? LoadSession()
    {
        try
        {
            var serializedSession = _localStorage.GetItem<string>(SessionKey);

            if (string.IsNullOrWhiteSpace(serializedSession))
                return null;

            var session = JsonConvert.DeserializeObject<Session>(serializedSession);

            if (session == null || session.Expired())
                return null;

            return session;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while trying to load the session from the local storage: {ex}");
            return null;
        }
    }
}