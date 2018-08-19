using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Common.Serialize
{
    /// <summary>
    /// 序列化者接口。
    /// </summary>
    public interface ISerializer
    {


        /// <summary>
        /// 将一个字符串反序列化为一个对象。
        /// </summary>
        /// <param name="objType">要反序序列化的对象类型。</param>
        /// <param name="str">要反序列化的字符串。</param>
        /// <returns>反序列化得到的对象。</returns>
        T Deserialize<T>( string str);

        /// <summary>
        /// 序列化一个对象。
        /// </summary>
        /// <param name="obj">要序列的对象。</param>
        /// <returns>得到序列化。</returns>
        string Serialize(object obj);
    }
}
