using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Text;

namespace DiscogsClient.Data.Query
{
    public enum DiscogsConditionType
    {
        [EnumMember(Value = "Mint (M)")]
        [Description("Mint (M)")]
        Mint,

        [EnumMember(Value = "Near Mint (NM or M-)")]
        [Description("Near Mint (NM or M-)")]
        NearMint,

        [EnumMember(Value = "Very Good Plus (VG+)")]
        [Description("Very Good Plus (VG+)")]
        VeryGoodPlus,

        [EnumMember(Value = "Very Good (VG)")]
        [Description("Very Good (VG)")]
        VeryGood,

        [EnumMember(Value = "Good Plus (G+)")]
        [Description("Good Plus (G+)")]
        GoodPlus,

        [EnumMember(Value = "Good (G)")]
        [Description("Good (G)")]
        Good,

        [EnumMember(Value = "Fair (F)")]
        [Description("Fair (F)")]
        Fair,

        [EnumMember(Value = "Poor (P)")]
        [Description("Poor (P)")]
        Poor,

        [EnumMember(Value = "Generic")]
        [Description("Generic")]
        Generic,

        [EnumMember(Value = "Not Graded")]
        [Description("Not Graded")]
        NotGraded,

        [EnumMember(Value = "No Cover")]
        [Description("No Cover")]
        NoCover            
    }
}
