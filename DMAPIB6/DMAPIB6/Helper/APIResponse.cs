using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace DMAPIB6.Helper
{
    public class APIResponse<T>
    {
        public T Data { get; set; }
        public string Message { get; set; }
        public int Status { get; set; }

        public List<string> Errors { get; set; }

        public APIResponse(T data, string message, int status) //constructor
        {
            Data = data;
            Message = message;
            Status = status;
            Errors = new List<string>();
        }

        public static ActionResult BadRequest(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage).ToList();
            var response = new APIResponse<T>(default, "Invalid data", 400)
            {
                Errors = errors
            };
            return new BadRequestObjectResult(response);
        }

        public static ActionResult Exception(Exception ex)
        {
            var response = new APIResponse<T>(default, ex.Message, 500)
            {
                Errors = new List<string> { ex.ToString() }
            };
            return new ObjectResult(response)
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }
}

