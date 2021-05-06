using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public enum DiscogsOrderSortType
    {
        [Description("id")]
            Id,

        [Description("buyer")]
            Buyer,

        [Description("created")]
            Created,

        [Description("status")]
            Status,

        [Description("last_activity")]
            LastActivity
    }
}
