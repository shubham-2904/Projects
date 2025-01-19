using Contracts;
using Entities.ErrorModel;
using Entities.Exceptions;
using Microsoft.AspNetCore.Diagnostics;

namespace Person_Api.Extensions {
    public static class ExceptionMiddlewareExtensions {
        public static void ConfigurExecptionHandler(this WebApplication app, ILoggerManager logger) {
            app.UseExceptionHandler(appError => {
                appError.Run(async context => {
                    context.Response.ContentType = "application/json";

                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature != null) {
                        context.Response.StatusCode = contextFeature.Error switch {
                            NotFoundException => StatusCodes.Status404NotFound,
                            _ => StatusCodes.Status500InternalServerError
                        };

                        logger.LogError($"Somethig went wrond {contextFeature.Error}");

                        await context.Response.WriteAsync(new ErrorDetails {
                            StatusCode = context.Response.StatusCode,
                            Message = contextFeature.Error.Message
                        }.ToString());
                    }
                });
            });
        }
    }
}
