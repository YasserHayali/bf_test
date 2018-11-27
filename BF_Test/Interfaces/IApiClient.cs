using BF_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF_Test.Interfaces
{
    interface IApiClient
    {
        RateResult GetLatest();
    }
}
