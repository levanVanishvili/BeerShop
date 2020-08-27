using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace BeerShop.Utility
{
    public static class SessionExtension
    {
        //Set Session
        public static void SetObject(this ISession session , string key , object value)
        {
            
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        //retrieve and Convert Session
        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
