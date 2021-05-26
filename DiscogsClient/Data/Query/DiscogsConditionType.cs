using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public enum DiscogsConditionType
    {
        [Description("Mint (M)")]
        Mint,

        [Description("Near Mint (NM or M-)")]
        NearMint,

        [Description("Very Good Plus (VG+)")]
        VeryGoodPlus,

        [Description("Very Good (VG)")]
        VeryGood,

        [Description("Good Plus (G+)")]
        GoodPlus,

        [Description("Good (G)")]
        Good,

        [Description("Fair (F)")]
        Fair,

        [Description("Poor (P)")]
        Poor,

        [Description("Generic")]
        Generic,

        [Description("Not Graded")]
        NotGraded,

        [Description("No Cover")]
        NoCover            
    }
}
