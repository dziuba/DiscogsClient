using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public enum DiscogsListingStatusType
    {
        [Description("Draft")]
        Draft,

        [Description("For Sale")]
        ForSale
    }
}
