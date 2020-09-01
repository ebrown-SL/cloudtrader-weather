﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

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

        public static void Each<T>(this IEnumerable<T> ie, Action<T, int> action)
        {
            var i = 0;
            foreach (var e in ie) action(e, i++);
        }
    }
}
