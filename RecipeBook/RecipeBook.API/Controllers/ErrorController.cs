using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RecipeBook.API.Controllers
{
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;
        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("error")]
        public MyErrorResponse Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;

            _logger.LogError(exception, "Something went wrong.");

            var message = "Internal Server Error";
            var code = 500;

            if (exception is ArgumentException)
            {
                code = 400;
                message = "Some problem with the parameters";
            }
            //...
            else if (exception is HttpResonseException ex)
            {
                code = ex.Status;
                message = ex.Message;
            }

            Response.StatusCode = code;
            return new MyErrorResponse(message);
        }
    }

    public class MyErrorResponse
    {
        public string Message { get; init; }

        public MyErrorResponse(string message)
        {
            Message = message;
        }
    }

    public class HttpResonseException : Exception
    {
        public HttpResonseException(string message, int status) : base(message)
        {
            Status = status;
        }

        public int Status { get; init; }
    }
}
