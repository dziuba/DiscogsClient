﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsBuyer : DiscogsEntity
    {
        public string resource_url { get; set; }
        public string username { get; set; }
        public string email { get; set; }
    }
}
