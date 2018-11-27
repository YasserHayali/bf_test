using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF_Test.Models
{
    public class Request
    {
        public string Query { get; set; }
        public decimal Amount { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
