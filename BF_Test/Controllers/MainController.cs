using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BF_Test.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace BF_Test.Controllers
{
    [Route("api")]
    public class MainController : Controller
    {
        private ICurrencyService _service;
        public MainController(ICurrencyService service)
        {
            _service = service;
        }

        [HttpGet]
        [Route("ConvertTo")]
        public string ConvertTo(string to, decimal value)
        {
            try
            {
                var convertedValue = _service.ConvertTo(to, value);
                return $"Converted value - {convertedValue}";

            }
            catch (Exception ex)
            {
                // logging, etc
                return $"Issue on server side. Issue message - {ex.Message}";
            }
        }

        [HttpGet]
        [Route("ConvertFrom")]
        public string ConvertFrom(string from, decimal value)
        {
            try
            {
                var convertedValue = _service.ConvertFrom(from, value);
                return $"Converted value - {convertedValue}";

            }catch(Exception ex)
            {
                // logging, etc
                return $"Issue on server side. Issue message - {ex.Message}";
            }
        }


        [HttpGet]
        [Route("SetInterval")]
        public string SetInterval(int intervalMillisecondsValue)
        {
            try
            {
                _service.SetCallingInterval(intervalMillisecondsValue);
                var finalResult = TimeSpan.FromMilliseconds(intervalMillisecondsValue);
                var finalResultSec = finalResult.TotalSeconds;
                var finalResultMin = finalResult.TotalMinutes;
                return $"Calling interval sec - {finalResultSec}, min - {finalResultMin}";

            }
            catch (Exception ex)
            {
                // logging, etc
                return $"Issue on server side. Issue message - {ex.Message}";
            }
        }
    }
}