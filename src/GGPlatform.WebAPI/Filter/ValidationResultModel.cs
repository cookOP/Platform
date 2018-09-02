using GGPlatform.WebAPI.Enum;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GGPlatform.WebAPI.Filter
{
    public class ValidationResultModel
    {
        public string Msg { get; }
        public int Code { get; }
        public string State { get; }
        public List<ValidationError> Data { get; }

        public ValidationResultModel(ModelStateDictionary modelState)
        {
            State = Status.Fail.ToString();
            Msg = "填写数据验证失败，请检查！";
            Code = -2;
            Data = modelState.Keys
                    .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                    .ToList();

        }
    }
}
