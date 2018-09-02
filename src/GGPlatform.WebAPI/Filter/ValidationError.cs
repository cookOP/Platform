using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.Filter
{
    public class ValidationError
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string Field { get; }
        public string Msg { get; }
        public ValidationError(string field, string message)
        {
            Field = field != string.Empty ? field : null;
            Msg = message;
        }
    }
}
