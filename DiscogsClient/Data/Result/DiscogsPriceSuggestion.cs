using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient.Data.Result
{
    public class DiscogsPriceSuggestion
    {
        [JsonProperty("Mint (M)")]
        public DiscogsPrice Mint { get; set; }

        [JsonProperty("Near Mint (NM or M-)")]
        public DiscogsPrice NearMint { get; set; }

        [JsonProperty("Very Good Plus (VG+)")]
        public DiscogsPrice VeryGoodPlus { get; set; }

        [JsonProperty("Very Good (VG)")]
        public DiscogsPrice VeryGood { get; set; }

        [JsonProperty("Good Plus (G+)")]
        public DiscogsPrice GoodPlus { get; set; }

        [JsonProperty("Good (G)")]
        public DiscogsPrice Good { get; set; }

        [JsonProperty("Fair (F)")]
        public DiscogsPrice Fair { get; set; }

        [JsonProperty("Poor (P)")]
        public DiscogsPrice Poor { get; set; }
    }
}
