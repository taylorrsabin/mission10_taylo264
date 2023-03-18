using System;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

//Setting up sessions so that data can be stored across different pages on the app

namespace mission10.Infrastructure
{
    public static class SessionExtensions
    {
        public static void setJson(this ISession session, string key, object value)
        {
            session.SetString(key, JsonSerializer.Serialize(value));
        }

        public static T GetJson<T>(this ISession session, string key)
        {
            var sessionData = session.GetString(key);

            return sessionData == null ? default(T) : JsonSerializer.Deserialize<T>(sessionData);
        }
    }
}

