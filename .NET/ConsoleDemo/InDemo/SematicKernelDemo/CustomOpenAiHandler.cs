namespace SematicKernelDemo;

public class CustomOpenAiHandler : HttpClientHandler    
{
    private readonly string _openAiBaseAddress;

    public CustomOpenAiHandler(string openAiEndpoint) : base()
    {
        _openAiBaseAddress = openAiEndpoint;
    }   

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
    {
        // Add custom headers or modify the request here
        // request.Headers.Add("Custom-Header", "Value");

        // var response = await base.SendAsync(request, cancellationToken);

        // // Add custom headers or modify the response here
        // response.Headers.Add("Custom-Header", "Value");

        // return response;

        request.RequestUri = new Uri($"{_openAiBaseAddress}{request.RequestUri}");
        return await base.SendAsync(request, cancellationToken);
    }
}