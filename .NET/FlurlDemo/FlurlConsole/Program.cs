// See https://aka.ms/new-console-template for more information
// Console.WriteLine("Hello, World!");

using Flurl;
using Flurl.Http;
using Flurl.Http.Testing;

var url = "http://localhost:5090/api/weather"
    .AppendPathSegment("endpoints")
    .SetQueryParams(new 
    {
        // api_key = _config.GetValue<string>("api_key"),
        max_results = 20,
        q = @"I'll get enocoded"
    })
    .SetFragment("after-hash");

Console.WriteLine(url);


var result = await "http://localhost:5090/api/weather".GetStringAsync();
var poco = await "http://localhost:5090/api/weather".GetJsonAsync<object>();

var rets = await "http://localhost:5090/api/weather".PostJsonAsync(poco);

//声明式语义 post方法发送json 接收结果 再序列化为json T
// var result = await "http://api.foo.com".PostJsonAsync(requestObj).ReceiveJson<T>();


// using var httpTest = new HttpTest();
// await httpTest.ForCallsTo("http://localhost:5090/api/weather")
// .AllowRealHttp().ReceiveJson();


//Flurl vs Refit vs RestSharp vs HttpClient
