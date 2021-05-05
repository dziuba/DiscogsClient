using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Parameters
{
    public class DiscogsMarketplaceOrdersParameters : DiscogsParametersBase
    {
        public OrderStatus? status { get; set; }
        public string created_after { get; set; }
        public string created_before { get; set; }
        public bool? archived { get; set; }

        public OrderSort? sort { get; set; }
        public SortOrder? sort_order { get; set; }

    }
}
