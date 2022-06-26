using Foundation;
using System;

namespace EvilGenius.RxDataBindings.iOS.Utils
{
    public static class DateTimeExtensions
    {
        private static readonly DateTime ReferenceNSDateTime = new DateTime(2001, 1, 1, 0, 0, 0, DateTimeKind.Utc);

        public static DateTime ToDateTimeUtc(this NSDate date)
        {
            return ReferenceNSDateTime.AddSeconds(date.SecondsSinceReferenceDate);
        }

        public static NSDate ToNSDate(this DateTime date)
        {
            return NSDate.FromTimeIntervalSinceReferenceDate((date - ReferenceNSDateTime).TotalSeconds);
        }

        public static DateTime WithKind(this DateTime date, DateTimeKind kind)
        {
            return new DateTime(date.Ticks, kind);
        }
    }
}