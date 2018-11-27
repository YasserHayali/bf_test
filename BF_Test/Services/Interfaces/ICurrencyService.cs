using BF_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF_Test.Services.Interfaces
{
    public interface ICurrencyService
    {
        string ConvertTo(string toCurrency, decimal value);
        string ConvertFrom(string fromCurrency, decimal value);

        void SetCallingInterval(int interval);

    }
}
