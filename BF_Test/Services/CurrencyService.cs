using BF_Test.Helpers;
using BF_Test.Models;
using BF_Test.Services.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF_Test.Services
{
    public class CurrencyService : ICurrencyService
    {
        private RateClient _rateClient = new RateClient(Constants.API_KEY);
        private IMemoryCacheService _memoryCacheService;
        public CurrencyService(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService;
        }
        public string ConvertTo(string toCurrency, decimal value)
        {
            var rates = this.GetLatest().Rates;
            var rate = rates.FirstOrDefault(x => x.Key == toCurrency.ToUpper()).Value;
            return System.Math.Round((rate * value), 2).ToString();
        }

        public string ConvertFrom(string fromCurrency, decimal value)
        {
            var rates = this.GetLatest().Rates;
            var rate = rates.FirstOrDefault(x => x.Key == fromCurrency.ToUpper()).Value;
            return System.Math.Round((value / rate), 2).ToString();
        }

        public void SetCallingInterval(int interval)
        {
            _memoryCacheService.SetCallingInterval(interval);
        }


        private RateResult GetLatest()
        {
            RateResult rates;
            var nextCallTime = _memoryCacheService.GetTimeForNextCall();
            if (nextCallTime > DateTime.UtcNow)
            {
                rates = _memoryCacheService.GetLatestFromCache();
            }
            else
            {
                try
                {
                    rates = _rateClient.GetLatest();
                    _memoryCacheService.SaveLatestToCache(rates);
                    _memoryCacheService.UpdateTimeForNextCall();

                }
                catch (Exception ex)
                {
                    rates = _memoryCacheService.GetLatestFromCache();
                }

            }
            //save to cashe
            return rates;
        }


    }
}
