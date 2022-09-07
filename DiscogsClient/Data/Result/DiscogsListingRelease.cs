using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsListingRelease
    {
        public string catalog_number { get; set; }
        public string resource_url { get; set; }
        public int year { get; set; }
        public int id { get; set; }
        public string description { get; set; }
        public string artist { get; set; }
        public string title { get; set; }
        public string format { get; set; }
        public string thumbnail { get; set; }
    }
}
