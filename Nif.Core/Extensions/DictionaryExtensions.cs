using System;
using System.Collections.Generic;

namespace Nif.Core.Extensions
{
    public static class DictionaryExtensions
    {
        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key)
        {
            TValue value;
            
            source.TryGetValue(key, out value);

            return value;
        }

        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            TValue value;

            return source.TryGetValue(key, out value) ? value : defaultValue;
        }

        public static TValue Get<TKey, TValue>(this IDictionary<TKey, TValue> source, TKey key, Func<TValue> defaultValue)
        {
            TValue result;

            return source.TryGetValue(key, out result) ? result : defaultValue();
        }
    }
}