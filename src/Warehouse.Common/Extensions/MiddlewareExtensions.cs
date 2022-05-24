using Microsoft.AspNetCore.Builder;
using Warehouse.Common.Helpers;

namespace Warehouse.Common.Extensions
{
    public static class MiddlewareExtensions
    {
        public static IApplicationBuilder UseErrorWrapping(
            this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ErrorWrappingMiddleware>();
        }
    }
}