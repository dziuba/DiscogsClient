using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsPagination
    {
        public int per_page { get; set; }
        public int pages { get; set; }
        public int page { get; set; }
        public int items { get; set; }
        public DiscogsUrls urls { get; set; }
    }
}
