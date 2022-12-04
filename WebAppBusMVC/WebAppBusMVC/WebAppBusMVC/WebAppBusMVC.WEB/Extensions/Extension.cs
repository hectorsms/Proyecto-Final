using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;


namespace WebAppBusMVC.WEB.Extensions
{
    public static class Extension
    {
        public static void SetObject(this ISession session, string key, Object value)
        {
            string data = JsonConvert.SerializeObject(value);
            session.SetString(key, data);
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            string data = session.GetString(key);
            if (data == null)
            {
                return default(T);
            }
            else
            {
                return JsonConvert.DeserializeObject<T>(data);
            }
        }


    }
}
