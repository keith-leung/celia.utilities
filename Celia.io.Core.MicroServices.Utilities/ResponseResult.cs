using System;
using System.Collections.Generic;
using System.Text;

namespace Celia.io.Core.MicroServices.Utilities
{
    public class ResponseResult<T>
    {
        /// <summary>
        /// 状态码
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 消息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }


        /// <summary>
        /// 响应token(为空使用本地token)
        /// </summary>
        public string AccessToken { get; set; }
    }
}
