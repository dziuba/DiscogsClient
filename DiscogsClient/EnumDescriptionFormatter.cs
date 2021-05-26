using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient
{
    public class EnumDescriptionFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (!arg.GetType().IsEnum)
                throw new FormatException("Formatter accepts only Enum");

            Enum obj = (Enum)arg;

            return GetString(obj);
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }

        protected static string GetString(Enum obj)
        {
            var value = obj.GetDescription();

            return string.IsNullOrEmpty(value) ? value.ToString() : value;
        }
    }
}
