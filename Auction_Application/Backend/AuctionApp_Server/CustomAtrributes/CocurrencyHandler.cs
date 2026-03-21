using CustomAtrributes.Reference;
using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ReferenceServices.Dtos;
using SharedData;

namespace CustomAtrributes;

public sealed class ConcurrencyHandlerAttribute : TypeFilterAttribute
{
    /// <summary>
    /// Handle the data concurrency
    /// </summary>
    /// <param name="dbContextType">Context which you want to deal</param>
    /// <param name="tableType">Enity for which you want to check concurrency</param>
    public ConcurrencyHandlerAttribute(Type dbContextType, Type tableType) : base(typeof(CocurrencyHandlerFilter))
    {
        Arguments = new object[] { dbContextType, tableType };
    }
}

public class CocurrencyHandlerFilter : IAsyncActionFilter
{
    private readonly ILoggerManager _logger;
    private readonly DbContext _context;
    private readonly Type _tableType;

    public CocurrencyHandlerFilter(
        Type dbContextType,
        Type tableType,
        IServiceProvider serviceProvider,
        ILoggerManager _loggerManager
    )
    {
        _context = (DbContext)serviceProvider.GetRequiredService(dbContextType);
        _tableType = tableType;
        _logger = _loggerManager;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {   
        try
        {
            string controllerName = context.ActionDescriptor.RouteValues["controller"]!;
            string actionName = context.ActionDescriptor.RouteValues["action"]!;
            var actionArgument = context.ActionArguments;

            _logger.LogInfo($"Controller: {controllerName} and Action: {actionName}");

            await HandleConcurrency(controllerName, actionName, actionArgument);

            await next();
        }
        catch (Exception ex)
        {

            _logger.LogError(ex, $"Got Exception {ex.Message}");
            context.Result = new JsonResult(Response<bool>.Fail($"Exception: {ex.Message}"))
            {
                StatusCode = StatusCodes.Status500InternalServerError
            };
        }
    }

    /// <summary>
    /// Method to Handle Concurrency
    /// </summary>
    /// <param name="controllerName"></param>
    /// <param name="actionName"></param>
    /// <param name="value"></param>
    private async Task HandleConcurrency(string controllerName, string actionName, IDictionary<string, object?> actionArgument)
    {
        if (controllerName.ToLower() == "reference")
        {
            await ReferenceConcurrencyHandler.ConcurrencyHandlerAsync(actionName, actionArgument, _context, _tableType, _logger);
        }
    }
}
