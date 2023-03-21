using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public class DiscogsNewListingQuery
    {
        public int release_id { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public DiscogsConditionType condition { get; set; }


        [JsonConverter(typeof(StringEnumConverter))]
        public DiscogsConditionType? sleeve_condition { get; set; }

        public decimal price { get; set; }

        public string comments { get; set; }

        public bool? allow_offers { get; set; }

        [JsonConverter(typeof(StringEnumConverter))]
        public DiscogsListingStatusType status { get; set; }

        public string external_id { get; set; }

        public string location { get; set; }

        public decimal weight { get; set; }

        public decimal format_quantity { get; set; }

        public int quantity { get; set; }
    }
}
