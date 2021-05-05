using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsOrderShipping
    {
        public string currency { get; set; }
        public string method { get; set; }
        public int value { get; set; }
    }
}
