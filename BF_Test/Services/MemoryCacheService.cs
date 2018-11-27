using System;
using BF_Test.Helpers;
using BF_Test.Models;
using BF_Test.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace BF_Test.Services
{
	public class MemoryCacheService : IMemoryCacheService
    {
        private readonly IMemoryCache _memoryCache;
        public MemoryCacheService(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public RateResult GetLatestFromCache()
        {
            var successResult = _memoryCache.TryGetValue(Constants.RATES_CACHE_KEY, out RateResult rates);
            if (successResult)
            {
                return rates;
            }
            else
            {
                return null;
            }
        }

        public void SaveLatestToCache(RateResult rates)
        {
            _memoryCache.Set(Constants.RATES_CACHE_KEY, rates, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = Constants.DEFAULT_CACHE_EXPIRATION
            });

        }

        public void UpdateTimeForNextCall()
        {
            var gettingAdminCountResult = _memoryCache.TryGetValue(Constants.ADMIN_REPEAT_INTERVAL_CALL_KEY, out int repeatResponseCount);

            var timeForNextCall = DateTime.UtcNow.AddMilliseconds(gettingAdminCountResult ? repeatResponseCount : Constants.DEFAULT_ADMIN_REPEAT_INTERVAL_CALL_VALUE);
            _memoryCache.Set(Constants.TIME_FOR_NEXT_CALL_KEY, timeForNextCall, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = Constants.DEFAULT_CACHE_EXPIRATION
            });
        }

        public void SetCallingInterval(int interval)
        {

            _memoryCache.Set(Constants.ADMIN_REPEAT_INTERVAL_CALL_KEY, interval, new MemoryCacheEntryOptions
            {
                AbsoluteExpirationRelativeToNow = Constants.DEFAULT_CACHE_EXPIRATION
            });
            UpdateTimeForNextCall();
        }
        public DateTime GetTimeForNextCall()
        {
            var successResult = _memoryCache.TryGetValue(Constants.TIME_FOR_NEXT_CALL_KEY, out DateTime nextCallTime);
            if(successResult)
            {
                return nextCallTime;
            }
            else
            {
                return DateTime.MinValue;
            }

        }


    }
}
