using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Parameters
{
    public enum OrderSort
    {
        [DiscogsParameterValue("id")]
            Id,

        [DiscogsParameterValue("buyer")]
            Buyer,

        [DiscogsParameterValue("created")]
            Created,

        [DiscogsParameterValue("status")]
            Status,

        [DiscogsParameterValue("last_activity")]
            LastActivity
    }
}
