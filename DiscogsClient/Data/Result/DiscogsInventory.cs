using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsInventory
    {
        public DiscogsPagination pagination { get; set; }
        public List<DiscogsListing> listings { get; set; }
    }
}
