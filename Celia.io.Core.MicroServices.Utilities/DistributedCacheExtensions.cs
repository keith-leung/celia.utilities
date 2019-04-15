using Microsoft.Extensions.Caching.Distributed;
using System;
using System.Threading.Tasks;


namespace Celia.io.Core.MicroServices.Utilities
{
    /// <summary>
    /// <see cref="IDistributedCache"/>扩展方法
    /// </summary>
    public static class DistributedCacheExtensions
    {
        /// <summary>
        /// 将对象存入缓存中
        /// </summary>
        public static void Set(this IDistributedCache cache, string key, object value, DistributedCacheEntryOptions options = null)
        {
            string json = Json.ToJson(value); 
            if (options == null)
            {
                cache.SetString(key, json);
            }
            else
            {
                cache.SetString(key, json, options);
            }
        }

        /// <summary>
        /// 异步将对象存入缓存中
        /// </summary>
        public static async Task SetAsync(this IDistributedCache cache, string key, object value, DistributedCacheEntryOptions options = null)
        {
            string json = Json.ToJson(value);
            if (options == null)
            {
                await cache.SetStringAsync(key, json);
            }
            else
            {
                await cache.SetStringAsync(key, json, options);
            }
        }

        /// <summary>
        /// 将对象存入缓存中，使用指定时长
        /// </summary>
        public static void Set(this IDistributedCache cache, string key, object value, int cacheSeconds)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheSeconds));
            cache.Set(key, value, options);
        }

        /// <summary>
        /// 异步将对象存入缓存中，使用指定时长
        /// </summary>
        public static Task SetAsync(this IDistributedCache cache, string key, object value, int cacheSeconds)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheSeconds));
            return cache.SetAsync(key, value, options);
        }

     
        /// <summary>
        /// 获取指定键的缓存项
        /// </summary>
        public static TResult Get<TResult>(this IDistributedCache cache, string key)
        {
            string json = cache.GetString(key);
            if (json == null)
            {
                return default(TResult);
            }
            return Json.ToObject<TResult>(json);
        }

        /// <summary>
        /// 异步获取指定键的缓存项
        /// </summary>
        public static async Task<TResult> GetAsync<TResult>(this IDistributedCache cache, string key)
        {
            string json = await cache.GetStringAsync(key);
            if (json == null)
            {
                return default(TResult);
            }
            return Json.ToObject<TResult>(json);
        }

        /// <summary>
        /// 获取指定键的缓存项，不存在则从指定委托获取，并回存到缓存中再返回
        /// </summary>
        public static TResult Get<TResult>(this IDistributedCache cache, string key, Func<TResult> getFunc, DistributedCacheEntryOptions options = null)
        {
            TResult result = cache.Get<TResult>(key);
            if (!Equals(result, default(TResult)))
            {
                return result;
            }
            result = getFunc();
            if (Equals(result, default(TResult)))
            {
                return default(TResult);
            }
            cache.Set(key, result, options);
            return result;
        }

        /// <summary>
        /// 异步获取指定键的缓存项，不存在则从指定委托获取，并回存到缓存中再返回
        /// </summary>
        public static async Task<TResult> GetAsync<TResult>(this IDistributedCache cache, string key, Func<Task<TResult>> getAsyncFunc, DistributedCacheEntryOptions options = null)
        {
            TResult result = await cache.GetAsync<TResult>(key);
            if (!Equals(result, default(TResult)))
            {
                return result;
            }
            result = await getAsyncFunc();
            if (Equals(result, default(TResult)))
            {
                return default(TResult);
            }
            await cache.SetAsync(key, result, options);
            return result;
        }

        /// <summary>
        /// 获取指定键的缓存项，不存在则从指定委托获取，并回存到缓存中再返回
        /// </summary>
        public static TResult Get<TResult>(this IDistributedCache cache, string key, Func<TResult> getFunc, int cacheSeconds)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheSeconds));
            return cache.Get<TResult>(key, getFunc, options);
        }

        /// <summary>
        /// 异步获取指定键的缓存项，不存在则从指定委托获取，并回存到缓存中再返回
        /// </summary>
        public static Task<TResult> GetAsync<TResult>(this IDistributedCache cache, string key, Func<Task<TResult>> getAsyncFunc, int cacheSeconds)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            options.SetAbsoluteExpiration(TimeSpan.FromSeconds(cacheSeconds));
            return cache.GetAsync<TResult>(key, getAsyncFunc, options);
        }

        /// <summary>
        /// 获取指定键的缓存项，不存在则从指定委托获取，并回存到缓存中再返回
        /// </summary>
        public static Task<TResult> GetAsync<TResult>(this IDistributedCache cache, string key, Func<Task<TResult>> getAsyncFunc)
        {
            DistributedCacheEntryOptions options = new DistributedCacheEntryOptions();
            return cache.GetAsync<TResult>(key, getAsyncFunc, options);
        }

   
    }
}