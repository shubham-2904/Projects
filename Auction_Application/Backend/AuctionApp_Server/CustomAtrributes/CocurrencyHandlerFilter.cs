using LoggerService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using Reference.Domain.Model;
using Reference.Infrastructure.DBContext;
using ReferenceServices.Dtos;
using SharedData;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CustomAtrributes;

public class ConcurrencyHandlerAttribute : TypeFilterAttribute
{
    public ConcurrencyHandlerAttribute() : base(typeof(CocurrencyHandlerFilter))
    {
        
    }
}

public class CocurrencyHandlerFilter : IAsyncActionFilter
{
    private readonly ILoggerManager _logger;
    private readonly ReferenceDbContext _referenceeDbContext;

    public CocurrencyHandlerFilter(ReferenceDbContext referenceDbContext, ILoggerManager _loggerManager)
    {
        _referenceeDbContext = referenceDbContext;
        _logger = _loggerManager;
    }

    public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        _logger.LogInfo("OnActionExecutionAsync Start");

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

        _logger.LogInfo("OnActionExecutionAsync End");
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
            switch (actionName)
            {
                case "UpdateUser":
                    if (actionArgument is not null)
                    {
                        var value = actionArgument["userDto"];
                        if (value is UserForUpdationDto updationDto)
                        {
                            var user = await _referenceeDbContext.User
                                .Where(u => u.UserId == updationDto.Id && u.IsDeleted == false)
                                .Select(u => new
                                {
                                    u.UserId,
                                    u.LockId
                                })
                                .FirstOrDefaultAsync();
                            if (user is null)
                            {
                                string error = $"User with id {updationDto.Id} not found";
                                _logger.LogError(error);
                                throw new Exception(error);
                            }
                            if (user.LockId != updationDto.LockId)
                            {
                                throw new Exception($"Data is modify by another user please refresh the data");
                            }
                            int lockId = user.LockId;
                            updationDto.LockId = lockId + 1;
                        }
                    }
                    break;
                case "CreateUser":
                    if (actionArgument is not null)
                    {
                        var value = actionArgument["userDto"];
                        if (value is UserForCreationDto creationDto)
                        {
                            if (creationDto is null)
                            {
                                _logger.LogError("User creation payload is null");
                                throw new Exception("User creation payload is null");
                            }
                            creationDto.LockId = 1;
                        }
                    }
                    break;
            }
        }
    }
}
