using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsSeller : DiscogsEntity
    {
        public string username { get; set; }
        public string resource_url { get; set; }
        public int id { get; set; }
    }
}
