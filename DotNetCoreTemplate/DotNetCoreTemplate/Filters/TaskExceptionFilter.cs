using DotNetCore.Exceptions;
using DotNetCore.Models;
using DotNetCore.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DotNetCore.Filters;

public class TaskExceptionFilter: ActionFilterAttribute
{
    private readonly ILoggerService _logger;

    public TaskExceptionFilter(ILoggerService logger)
    {
        _logger = logger;
    }

    public override void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Exception != null)
        {
            _logger.Error(
                $"[{context.Controller.GetType().Name}Controller] Api occurred exception : {context.Exception.Message}, Stack {context.Exception.StackTrace}");
            

            if (context.Exception is ApiException apiException)
            {
                context.Result = new ObjectResult(new TaskResponseBase()
                {
                    Status = (int)apiException.Error,
                    Description = apiException.Message
                });
                
                context.HttpContext.Response.StatusCode = (int)apiException.Error;
                context.Result ??= new ObjectResult(new TaskResponseBase());
                context.ExceptionHandled = true;
            }
        }

        base.OnActionExecuted(context);
    }
}