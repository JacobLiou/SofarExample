using System;

namespace SematicKernelDemo
{
    public class OpenAIConfig
    {
        public string ModelId { get; set; }
        public string EndPoint { get; set; }
        public string ApiKey { get; set; }

        public OpenAIConfig(string modelId, string endPoint, string apiKey)
        {
            ModelId = modelId;
            EndPoint = endPoint;
            ApiKey = apiKey;
        }
    }
}