using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient
{
    [System.AttributeUsage(System.AttributeTargets.All)]
    public class DiscogsParameterValueAttribute : System.Attribute
    {
        public string Value { get; }

        public DiscogsParameterValueAttribute(string value)
        {
            Value = value;
        }
    }
}
