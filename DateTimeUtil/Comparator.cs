using System;
using System.Collections.Generic;

namespace DateTimeUtil
{
    public class DateTimeComparator : Comparer<DateTime>
    {
        public enum Precision
        {
            Milliseconds,
            Seconds,
            Minutes,
            Hour,
            Day,
            Month,
            Year,
            Ticks
        }

        private readonly Precision _precision;

        public DateTimeComparator(Precision precision = Precision.Ticks)
        {
            _precision = precision;
        }

        public override int Compare(DateTime x, DateTime y)
        {
            if (x.Kind != y.Kind)
            {
                throw new ArgumentException("Cannot compare because of different DateTime Kind");
            }

            TimeSpan ceilTimeSpan;

            switch (_precision)
            {
                case Precision.Milliseconds:
                    ceilTimeSpan = new TimeSpan(0, 0, 0, 0, 1);
                    x = x.Floor(ceilTimeSpan);
                    y = y.Floor(ceilTimeSpan);
                    break;

                case Precision.Seconds:
                    ceilTimeSpan = TimeSpan.FromSeconds(1.0);
                    x = x.Floor(ceilTimeSpan);
                    y = y.Floor(ceilTimeSpan);
                    break;

                case Precision.Minutes:
                    ceilTimeSpan = TimeSpan.FromMinutes(1.0);
                    x = x.Floor(ceilTimeSpan);
                    y = y.Floor(ceilTimeSpan);
                    break;

                case Precision.Hour:
                    ceilTimeSpan = TimeSpan.FromHours(1.0);
                    x = x.Floor(ceilTimeSpan);
                    y = y.Floor(ceilTimeSpan);
                    break;

                case Precision.Day:
                    ceilTimeSpan = TimeSpan.FromDays(1.0);
                    x = x.Floor(ceilTimeSpan);
                    y = y.Floor(ceilTimeSpan);
                    break;

                case Precision.Month:
                    ceilTimeSpan = TimeSpan.FromDays(1.0);
                    x = x.AddDays(-x.Day).Floor(ceilTimeSpan);
                    y = y.AddDays(-y.Day).Floor(ceilTimeSpan);
                    break;

                case Precision.Year:
                    ceilTimeSpan = TimeSpan.FromDays(1.0);
                    x = x.AddMonths(-x.Month).AddDays(-x.Day).Floor(ceilTimeSpan);
                    y = y.AddMonths(-y.Month).AddDays(-y.Day).Floor(ceilTimeSpan);
                    break;
                case Precision.Ticks:
                default:
                    // do not round
                    break;
            }

            return x.CompareTo(y);
        }
    }

    public static class DateExtension
    {
        public static DateTime Round(this DateTime date, TimeSpan span)
        {
            var ticks = (date.Ticks + (span.Ticks / 2) + 1) / span.Ticks;
            return new DateTime(ticks * span.Ticks, date.Kind);
        }
        public static DateTime Floor(this DateTime date, TimeSpan span)
        {
            var ticks = (date.Ticks / span.Ticks);
            return new DateTime(ticks * span.Ticks, date.Kind);
        }

        public static DateTime Ceil(this DateTime date, TimeSpan span)
        {
            var ticks = (date.Ticks + span.Ticks - 1) / span.Ticks;
            return new DateTime(ticks * span.Ticks, date.Kind);
        }
    }
}