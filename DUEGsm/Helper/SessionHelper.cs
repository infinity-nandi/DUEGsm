using Newtonsoft.Json;

namespace DUEGsm.Helper
{
        public static class SessionHelper
        {
            public static void SetObjectAsJson(this ISession session, string key, object value)
            {
                session.SetString(key, JsonConvert.SerializeObject(value));
            }

            public static void ClearSession(this ISession session, string key)
            {
                session?.Clear();
            }

            public static T? GetObjectFromJson<T>(this ISession session, string key)
            {
                var value = session.GetString(key);
                return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
            }
        }
}
