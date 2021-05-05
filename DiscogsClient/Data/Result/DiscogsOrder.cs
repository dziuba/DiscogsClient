using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsOrder //: DiscogsEntity
    {
        public string id { get; set; }
        public string resource_url { get; set; }
        public string messages_url { get; set; }
        public string uri { get; set; }
        public string status { get; set; }
        public List<string> next_status { get; set; }
        public DiscogsFee fee { get; set; }
        public DateTime created { get; set; }
        public List<DiscogsOrderItem> items { get; set; }
        public DiscogsOrderShipping shipping { get; set; }
        public string shipping_address { get; set; }
        public string additional_instructions { get; set; }
        public bool archived { get; set; }
        public DiscogsSeller seller { get; set; }
        public DateTime last_activity { get; set; }
        public DiscogsBuyer buyer { get; set; }
        public DiscogsOrderTotal total { get; set; }
    }
}
