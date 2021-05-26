using System;
using System.Collections.Generic;
using System.Text;

namespace DiscogsClient
{
    public class DateTimeFormatter : IFormatProvider, ICustomFormatter
    {
        public string Format(string format, object arg, IFormatProvider formatProvider)
        {
            if (arg.GetType() != typeof(DateTime))
                throw new FormatException("Formatter accepts only DateTime");

            DateTime time = (DateTime)arg;
            return string.IsNullOrEmpty(format) ? time.ToString("s") : time.ToString(format);
        }

        public object GetFormat(Type formatType)
        {
            if (formatType == typeof(ICustomFormatter))
                return this;
            else
                return null;
        }
    }
}
