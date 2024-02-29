using System.Text.Json.Serialization;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return new XmlResult<WeatherForecast[]>(forecast);
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();

[Serializable]
public class WeatherForecast
{
    public DateOnly Date { get; set; }

    public int TemperatureC { get; set; }

    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

    public string? Summary { get; set; }

    public WeatherForecast(DateOnly date, int tempC, string? summary)
    {
        Date = date;
        TemperatureC = tempC;
        Summary = summary;
    }

    public WeatherForecast()
    {
        Date = DateOnly.MinValue;
        TemperatureC = 1;
        Summary = "";
    }
}

public class XmlResult<T> : IResult
{
    // Create the serializer that will actually perform the XML serialization
    private static readonly XmlSerializer Serializer = new(typeof(T));

    // The object to serialize
    private readonly T _result;

    public XmlResult(T result)
    {
        _result = result;
    }

    public async Task ExecuteAsync(HttpContext httpContext)
    {
        // NOTE: best practice would be to pull this, we'll look at this shortly
        using var ms = new MemoryStream();

        // Serialize the object synchronously then rewind the stream
        Serializer.Serialize(ms, _result);
        ms.Position = 0;

        httpContext.Response.ContentType = "application/xml";
        await ms.CopyToAsync(httpContext.Response.Body);
    }
}
