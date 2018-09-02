using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace GGPlatform.WebAPI.Filter
{
    public class ValidationFailedResult: ObjectResult
{
    public ValidationFailedResult(ModelStateDictionary modelState)
        : base(new ValidationResultModel(modelState))
    {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
    }
}
}
