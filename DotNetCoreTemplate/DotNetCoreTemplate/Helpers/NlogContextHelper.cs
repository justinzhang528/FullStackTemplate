using NLog;

namespace DotNetCore.Helpers;

public class NlogContextHelper
{
    public static void PushScopeProperty<TValue>(string key, TValue value)
    {
        ScopeContext.PushProperty(key, value);
    }

    public static bool TryGetScopeProperty(string key, out object value)
    {
        return ScopeContext.TryGetProperty(key, out value);
    }
}