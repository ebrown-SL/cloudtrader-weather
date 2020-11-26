using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CloudTrader.Weather
{
    public static class ObjectExtensions
    {
        public static string ToJson(this object obj)
        {
            return Newtonsoft.Json.JsonConvert.SerializeObject(obj);
        }

        public static HttpContent ToJsonStringContent(this object obj)
        {
            return new StringContent(
                obj.ToJson(),
                Encoding.UTF8,
                "application/json"
            );
        }

        public static async Task EachAsync<T>(this IEnumerable<T> ie, Func<T, int, Task> action)
        {
            var i = 0;
            foreach (var e in ie) await action(e, i++);
        }
    }
}