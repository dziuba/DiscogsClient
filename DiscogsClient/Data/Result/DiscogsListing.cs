using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsListing
    {
        public string status { get; set; }
        public DiscogsPrice price { get; set; }
        public bool allow_offers { get; set; }
        public string sleeve_condition { get; set; }
        public int id { get; set; }
        public string condition { get; set; }
        public DateTime posted { get; set; }
        public string ships_from { get; set; }
        public string uri { get; set; }
        public string comments { get; set; }
        public DiscogsSeller seller { get; set; }
        public DiscogsListingRelease release { get; set; }
        public string resource_url { get; set; }
        public bool audio { get; set; }
    }
}
