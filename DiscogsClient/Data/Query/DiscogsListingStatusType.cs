using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public enum DiscogsListingStatusType
    {
        [Description("Draft")]
        [EnumMember(Value ="Draft")]
        Draft,

        [Description("For Sale")]
        [EnumMember(Value ="For Sale")]
        ForSale
    }
}
