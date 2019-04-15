using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Web;

namespace Celia.io.Core.MicroServices.Utilities
{
    public static partial class Extensions
    {
        /// <summary>
        /// 安全方式取值
        /// </summary>
        /// <typeparam name="Tkey"></typeparam>
        /// <typeparam name="T"></typeparam>
        /// <param name="dic"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<Tkey, T>(this Dictionary<Tkey, T> dic, Tkey key, bool isPrintNoFound = true)
        {
            T t = default(T);
            dic.TryGetValue(key, out t);
            if (isPrintNoFound && (t == null || t.Equals(default(T))))
            {
                System.Diagnostics.Debug.WriteLine($"Cannot Get KEY: {key}");
            }
            return t;
        }

        /// <summary>
        /// 安全获取值，当值为null时，不会抛出异常
        /// </summary>
        /// <param name="value">可空值</param>
        public static T SafeValue<T>(this T? value) where T : struct
        {
            return value ?? default(T);
        }

        /// <summary>
        /// 获取类型成员描述，使用DescriptionAttribute设置描述
        /// </summary>
        /// <param name="member">成员</param>
        public static string Description(this Enum @enum)
        {
            var type = @enum.GetType();
            var memberName = type.GetEnumName(@enum);
            var member = type.GetTypeInfo().GetMember(memberName).FirstOrDefault();

            if (member == null)
                return string.Empty;
            return member.GetCustomAttribute<DescriptionAttribute>() is DescriptionAttribute attribute ? attribute.Description : member.Name;
        }

        /// <summary>
        /// 枚举值
        /// </summary>
        /// <param name="enum"></param>
        /// <returns></returns>
        public static int Value(this Enum @enum)
        {
            try
            {
               return Convert.ToInt32(@enum);
            }
            catch
            {
                return 0;
            }
        }
    }
}