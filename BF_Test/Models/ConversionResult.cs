using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BF_Test.Models
{
    public class ConversionResult
    {
        public string Disclaimer { get; set; }
        public decimal License { get; set; }
        public Request Request { get; set; }
        public Meta Meta { get; set; }
        public decimal Response { get; set; }
    }
}
