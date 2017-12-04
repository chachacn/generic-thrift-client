using System;
using System.Collections.Generic;
using System.Text;

namespace generic_thrift_client.common
{
    /// <summary>
    /// 参数类型
    /// </summary>
    public enum TypeEnum
    {
        /// <summary>
        /// 基本类型
        /// </summary>
        PRIMITIVE_TYPE = 0,
        /// <summary>
        /// 集合类型
        /// </summary>
        COLLECTION_TYPE = 1,

        /// <summary>
        /// 复杂类型
        /// </summary>
        SYNTHETIC_TYPE = 2

    }
}