using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using Application.Common.Exceptions;

namespace API.Filters;
public class ApiExceptionFilterAttribute : ExceptionFilterAttribute
{
    private readonly IDictionary<Type, Action<ExceptionContext>> _exceptionHandlers;
    public ApiExceptionFilterAttribute()
    {
        // Register known exception types and handlers.
        _exceptionHandlers = new Dictionary<Type, Action<ExceptionContext>>
            {
                { typeof(ValidationException), HandleValidationException },
                { typeof(NotFoundException), HandleNotFoundException },
                { typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException },
                { typeof(ForbiddenAccessException), HandleForbiddenAccessException },
                { typeof(Exception), UnHandleException },
            };
    }

    public override void OnException(ExceptionContext context)
    {
        HandleException(context);

        base.OnException(context);
    }

    private void HandleException(ExceptionContext context)
    {
        Type type = context.Exception.GetType();
        if (_exceptionHandlers.ContainsKey(type))
        {
            _exceptionHandlers[type].Invoke(context);
            return;
        }

        if (!context.ModelState.IsValid)
        {
            HandleInvalidModelStateException(context);
            return;
        }

        _exceptionHandlers[typeof(Exception)].Invoke(context);
    }

    private void HandleValidationException(ExceptionContext context)
    {
        var exception = (ValidationException)context.Exception;
        context.Result = new BadRequestObjectResult(exception.Message);
        context.ExceptionHandled = true;
    }

    private void HandleInvalidModelStateException(ExceptionContext context)
    {
        context.Result = new BadRequestObjectResult(context.Exception.Message);
        context.ExceptionHandled = true;
    }

    private void HandleNotFoundException(ExceptionContext context)
    {
        context.Result = new NotFoundResult();
        context.ExceptionHandled = true;
    }

    private void HandleUnauthorizedAccessException(ExceptionContext context)
    {
        context.Result = new UnauthorizedResult();
        context.ExceptionHandled = true;
    }

    private void HandleForbiddenAccessException(ExceptionContext context)
    {
        context.Result = new ForbidResult();
        context.ExceptionHandled = true;
    }

    private void UnHandleException(ExceptionContext context)
    {
        context.Result = new ObjectResult(new { Message = context.Exception.Message })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}