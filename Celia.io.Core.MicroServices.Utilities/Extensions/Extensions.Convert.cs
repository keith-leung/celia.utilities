﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Celia.io.Core.MicroServices.Utilities
{
    /// <summary>
    /// 系统扩展 - 类型转换
    /// </summary>
    public static partial class Extensions {
        /// <summary>
        /// 安全转换为字符串，去除两端空格，当值为null时返回""
        /// </summary>
        /// <param name="input">输入值</param>
        public static string SafeString( this object input ) {
            return input == null ? string.Empty : input.ToString().Trim();
        }

    }
}
