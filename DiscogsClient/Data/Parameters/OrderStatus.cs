using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Parameters
{
    public enum SortOrder
    {
        [DiscogsParameterValue("asc")]
        Asc,

        [DiscogsParameterValue("desc")]
        Desc
    }
}
