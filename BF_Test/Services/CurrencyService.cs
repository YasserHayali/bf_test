using BF_Test.Models;
using BF_Test.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF_Test.Services
{
    public class CurrencyService : ICurrencyService
    {
        private RateClient _rateClient = new RateClient("fb577531b0ac4fceb17d7e3dd5c33c3b");

        public string ConvertTo(string toCurrency, decimal value)
        {
            var rates = this.GetLatest().Rates;
            var rate = rates.FirstOrDefault(x => x.Key == toCurrency.ToUpper()).Value;
            return System.Math.Round((rate * value),2).ToString();
        }

        public string ConvertFrom(string fromCurrency, decimal value)
        {
            var rates = this.GetLatest().Rates;
            var rate = rates.FirstOrDefault(x => x.Key == fromCurrency.ToUpper()).Value;
            return System.Math.Round((value / rate),2).ToString();
        }

        private RateResult GetLatest()
        {
            //load from memory/bd/etc
            //else
            var rates =  _rateClient.GetLatest();
            //save to cashe
            return rates;
        }
    }
}
