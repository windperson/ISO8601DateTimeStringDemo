using System;
using DateTimeUtil;
using Iso8601DateTimeTool;

namespace ISO8601DateTimeStringDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var utcNow = DateTime.UtcNow;
            var utcNowStr = DateTimeConvert.ToIso8601ShortFormatString(utcNow);
            Console.WriteLine($"ISO 8601 DateTime UtcNow = {utcNowStr}");

            var nowStr = DateTimeConvert.ToIso8601ShortFormatString(utcNow.ToLocalTime());
            Console.WriteLine($"ISO 8601 DateTime    Now = {nowStr}");

            var convertedUtcNow = DateTimeConvert.ParseIso8601(utcNowStr);
            Console.WriteLine($"Using Built-in DateTime.Compare() = {DateTime.Compare(utcNow, convertedUtcNow)}");

            var customCompareResult = new DateTimeComparator(DateTimeComparator.Precision.Milliseconds).Compare(utcNow, convertedUtcNow);
            Console.WriteLine($"Using custom Comparator = {customCompareResult}");

            Console.WriteLine("Press Enter to exit");
            Console.ReadLine();
        }
    }
}
