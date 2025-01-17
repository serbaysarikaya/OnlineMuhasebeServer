namespace OnlineMuhasebeServer.WebApi.Middleware
{
    public static class ExceptionMiddlewareExtensions
    {
        public static IApplicationBuilder useExceptionMiddleware(this IApplicationBuilder app)
        {
            return app.UseMiddleware<ExceptionMiddleware>();
        }
    }
}
