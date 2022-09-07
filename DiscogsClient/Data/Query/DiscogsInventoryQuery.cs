using DiscogsClient.Data.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public class DiscogsInventoryQuery
    {
        public DiscogsListingStatusType status { get; set; }

        public DiscogsInventorySortType sort { get; set; }

        public DiscogsSortOrderType sort_order { get; set; }

    }
}
