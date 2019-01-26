using System;
using System.Collections.Generic;
using System.Text;

namespace Celia.io.Core.MicroServices.Utilities
{
    public class DateTimeUtils
    {
        #region 秒
        /// <summary>
        /// 获取当前long型时间戳（秒）
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentTimestamp()
        {
            var dt = DateTime.UtcNow;
            return GetTimestamp(dt);
        }

        /// <summary>
        /// 获取指定时间的时间戳（秒）
        /// </summary>
        /// <param name="dt">当地时间</param>
        /// <returns></returns>
        public static long GetTimestamp(DateTime dt)
        {
            var dateTimeOffset = new DateTimeOffset(dt);
            return dateTimeOffset.ToUnixTimeSeconds();
        }

        /// <summary>
        /// 从时间戳（秒）转换回当地时间DateTime
        /// </summary>
        /// <param name="timestamp">秒时间戳</param>
        /// <returns>当地时间</returns>
        public static DateTime ToDateTimeNow(long timestamp)
        {
            return ToDateTimeUtc(timestamp).ToLocalTime();
        }

        /// <summary>
        /// 从时间戳（秒）转换回UTC DateTime
        /// </summary>
        /// <param name="timestamp">秒时间戳</param>
        /// <returns>UTC时间</returns>
        public static DateTime ToDateTimeUtc(long timestamp)
        {
            var localDateTimeOffset = DateTimeOffset.FromUnixTimeSeconds(timestamp);
            return localDateTimeOffset.DateTime;
        }
        #endregion

        #region 毫秒
        /// <summary>
        /// 获取当前long型时间戳（毫秒）
        /// </summary>
        /// <returns></returns>
        public static long GetCurrentMillisecondsTimestamp()
        {
            var dt = DateTime.UtcNow;
            return GetTimestampMilliseconds(dt);
        }

        /// <summary>
        /// 获取指定时间的时间戳（毫秒）
        /// </summary>
        /// <param name="dt">当地时间</param>
        /// <returns></returns>
        public static long GetTimestampMilliseconds(DateTime dt)
        {
            var dateTimeOffset = new DateTimeOffset(dt);
            return dateTimeOffset.ToUnixTimeMilliseconds();
        }

        /// <summary>
        /// 从时间戳（毫秒）转换回当地时间DateTime
        /// </summary>
        /// <param name="timestamp">毫秒时间戳</param>
        /// <returns>当地时间</returns>
        public static DateTime MillisecondsToDateTimeNow(long timestampGetTimestampMilliseconds)
        {
            return MillisecondsToDateTimeUtc(timestampGetTimestampMilliseconds).ToLocalTime();
        }

        /// <summary>
        /// 从时间戳（毫秒）转换回UTC DateTime
        /// </summary>
        /// <param name="timestamp">毫秒时间戳</param>
        /// <returns>UTC时间</returns>
        public static DateTime MillisecondsToDateTimeUtc(long timestamp)
        {
            var localDateTimeOffset = DateTimeOffset.FromUnixTimeMilliseconds(timestamp);
            return localDateTimeOffset.DateTime;
        }
        #endregion
    }
}
