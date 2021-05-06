using DiscogsClient.Data.Result;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public class DiscogsOrdersFilter
    {
        public DiscogsOrderStatusType? status { get; set; }
        public string created_after { get; set; }
        public string created_before { get; set; }
        public bool? archived { get; set; }

        public DiscogsOrderSortType? sort { get; set; }
        public DiscogsSortOrderType? sort_order { get; set; }
    }
}
