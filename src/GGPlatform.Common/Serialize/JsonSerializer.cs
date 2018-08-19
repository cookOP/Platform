using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GGPlatform.Common.Serialize
{
    /// <summary>
    /// Json 序列化/反序列化。
    /// </summary>
    public class JsonSerializer : ISerializer
    {
        #region ISerializer 成员


        public T Deserialize<T>(string str)
        {
            return JsonConvert.DeserializeObject<T>(str);
        }

        public string Serialize(object obj)
        {
            return JsonConvert.SerializeObject(obj);
        }

        #endregion


    }
}
