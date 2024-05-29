// See https://aka.ms/new-console-template for more information
using Microsoft.SemanticKernel;
using SematicKernelDemo;

Console.WriteLine("Hello, World!");


var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var openAiCOnfiguration = new OpenAIConfig(
    configuration.GetSection("LLM_OPEN_MODEL").Value,
    configuration.GetSection("LLM_OPEN_API_KEY").Value,
         configuration.GetSection("LLM_OPEN_API_KEY").Value);


var openAiclinet = new HttpClient(new CustomOpenAiHandler(openAiCOnfiguration.EndPoint));

var builder = Kernel.CreateBuilder();
builder.AddOpenAIChatCompletion(openAiCOnfiguration.ModelId, openAiCOnfiguration.ApiKey, openAiclinet.ToString());
httpClient: openAiclinet);
var kernel = builder.Build();

//建立连接之后 开启文字对话
// 开始对话
string userMessage = string.Empty;
var promptTemplate = @"<message role=""user"">{0}</message>";
while (!string.IsNullOrEmpty(userMessage = Console.ReadLine()))
{
    var prompt = string.Format(promptTemplate, userMessage);
    var summarize = kernel.CreateFunctionFromPrompt(prompt);
    var response = kernel.InvokePromptStreamingAsync(summarize);
    Console.WriteLine("AI回答");
    await foreach (var item in response)
    {
        Console.WriteLine(item.Text);
    }
    Console.WriteLine(Environment.NewLine);
}