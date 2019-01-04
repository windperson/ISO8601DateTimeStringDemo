using System;

namespace Iso8601DateTimeTool
{
    public static class DateTimeConvert
    {
        private const string Iso8601LongFormat = @"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffffffK";
        private const string Iso8601ShortFormat = @"yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fffK";

        public static string ToIso8601LongFormatString(DateTime input)
        {
            return input.ToString(Iso8601LongFormat);
        }

        public static string ToIso8601ShortFormatString(DateTime input)
        {
            return input.ToString(Iso8601ShortFormat);
        }

        public static DateTime ParseIso8601(string input)
        {
            return DateTime.ParseExact(
                input,
                new[] { Iso8601LongFormat, Iso8601ShortFormat },
                System.Globalization.CultureInfo.InvariantCulture,
                System.Globalization.DateTimeStyles.RoundtripKind);
        }
    }
}