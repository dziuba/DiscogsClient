using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsOrders
    {
        public DiscogsPagination pagination { get; set; }
        public List<DiscogsOrder> orders { get; set; }
    }
}
