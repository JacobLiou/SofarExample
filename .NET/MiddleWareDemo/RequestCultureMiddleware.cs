using System.Globalization;

namespace MiddleWareDemo;

public class RequestCultureMiddleware
{
    private readonly RequestDelegate _next;

    public RequestCultureMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        // Get the requested culture from the query string
        var requestedCulture = context.Request.Query["culture"].ToString();

        // Set the culture for the current request
        if (!string.IsNullOrEmpty(requestedCulture))
        {
            var culture = new CultureInfo(requestedCulture);
            CultureInfo.CurrentCulture = culture;
            CultureInfo.CurrentUICulture = culture;

        }

        await _next(context);
    }
}