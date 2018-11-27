using System;
using BF_Test.Models;

namespace BF_Test.Services.Interfaces
{
    public interface IMemoryCacheService
    {
        RateResult GetLatestFromCache();
        void SaveLatestToCache(RateResult rates);

        void SetCallingInterval(int interval);

        void UpdateTimeForNextCall();
        DateTime GetTimeForNextCall();
    }
}
