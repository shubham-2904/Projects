using Microsoft.EntityFrameworkCore;
using ReferenceServices.Dtos;
using LoggerService;

namespace CustomAtrributes.Reference;

/// <summary>
/// Class handle the concurrency for reference
/// </summary>
public static class ReferenceConcurrencyHandler
{
    /// <summary>
    /// Handle concurrency for reference data
    /// </summary>
    /// <param name="actionName"></param>
    /// <param name="actionArgument"></param>
    /// <param name="context"></param>
    /// <param name="tableType"></param>
    /// <param name="logger"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    public static async Task ConcurrencyHandlerAsync(
        string actionName,
        IDictionary<string, object?> actionArgument,
        DbContext context,
        Type tableType,
        ILoggerManager logger
    )
    {
        switch (actionName)
        {
            case "UpdateUser":
                if (actionArgument is not null)
                {
                    var value = actionArgument["userDto"];
                    if (value is UserForUpdationDto updationDto)
                    {
                        var entity = await context.FindAsync(tableType, updationDto.Id);
                        if (entity is null)
                        {
                            string error = $"User with id {updationDto.Id} not found";
                            logger.LogError(error);
                            throw new Exception(error);
                        }
                        int existingLockId = (int)context.Entry(entity).Property("LockId").CurrentValue!;
                        if (existingLockId != updationDto.LockId)
                        {
                            throw new Exception($"Data is modify by another user please refresh the data");
                        }
                        updationDto.LockId = existingLockId + 1;
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
                            logger.LogError("User creation payload is null");
                            throw new Exception("User creation payload is null");
                        }
                        creationDto.LockId = 1;
                    }
                }
                break;
        }
    }
}
