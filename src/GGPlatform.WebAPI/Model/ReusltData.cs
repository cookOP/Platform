using GGPlatform.WebAPI.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.Model
{
    public class ResultData
    {
        public ResultData()
        {
            State = Status.Succeed.ToString();
        }
        public string State { get; set; }
        public object Data { get; set; }
        public string Msg { get; set; }
        public int Code { get; set; }
    }
}
