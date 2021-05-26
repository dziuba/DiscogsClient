using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient
{
    public class DiscogsClientConfiguration
    {
        public static IFormatProvider[] RestParameterFormatProviders { get; set; } = new IFormatProvider[] { new DateTimeFormatter(), new EnumDescriptionFormatter() };
    }
}
