using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsOrderItem : DiscogsEntity
    {
        public DiscogsOrderRelease release { get; set; }
        public DiscogsPrice price { get; set; }
        public string media_condition { get; set; }
        public string sleeve_condition { get; set; }
    }
}
