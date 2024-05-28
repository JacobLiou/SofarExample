using DotnetSpider;
using DotnetSpider.DataFlow;
using DotnetSpider.DataFlow.Parser;
using DotnetSpider.Downloader;
using DotnetSpider.HtmlAgilityPack.Css;
using DotnetSpider.Http;
using DotnetSpider.Scheduler;
using DotnetSpider.Scheduler.Component;
using DotnetSpider.Selector;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawlDemo
{
    internal class RecommendedRankingSpider : Spider
    {
        public RecommendedRankingSpider(IOptions<SpiderOptions> options,
            DependenceServices services,
            ILogger<Spider> logger) : base(options, services, logger) { }

        public static async Task RunAsync()
        {
            var builder = Builder.CreateDefaultBuilder<RecommendedRankingSpider>();
            builder.UseSerilog();
            builder.UseDownloader<HttpClientDownloader>();
            builder.UseQueueDistinctBfsScheduler<HashSetDuplicateRemover>();
            await builder.Build().RunAsync();
        }

        protected override async Task InitializeAsync(CancellationToken stoppingToken = default)
        {
            //添加自定义解析
            AddDataFlow(new Parser());
            AddDataFlow(new ConsoleStorage());
            await AddRequestsAsync(new Request("https://www.cnblogs.com/aggsite/topdiggs")
            {
                //请求超时10秒
                Timeout = 10000
            });
        }

        class Parser : DataParser
        {
            public override Task InitializeAsync()
            {
               return Task.CompletedTask;
            }

            protected override Task ParseAsync(DataFlowContext context)
            {
                var recommendedRankingList = new List<RecommendedRankingModel>();
                // 网页数据解析
                var number = 1;
                var recommendedList = context.Selectable.SelectList(Selectors.XPath(".//article[@class='post-item']"));
                foreach (var news in recommendedList)
                {
                    var articleTitle = news.Select(Selectors.XPath(".//a[@class='post-item-title']"))?.Value;
                    var articleSummary = news.Select(Selectors.XPath(".//p[@class='post-item-summary']"))?.Value?.Replace("\n", "").Replace(" ", "");
                    var articleUrl = news.Select(Selectors.XPath(".//a[@class='post-item-title']/@href"))?.Value;

                    Console.WriteLine($"第{number}篇文章 标题：{articleTitle}");

                    recommendedRankingList.Add(new RecommendedRankingModel
                    {
                        ArticleTitle = articleTitle,
                        ArticleSummary = articleSummary,
                        ArticleUrl = articleUrl
                    });

                    number++;
                }

                using (StreamWriter sw = new StreamWriter("RecommendedRanking.txt"))
                {
                    foreach (RecommendedRankingModel model in recommendedRankingList)
                    {
                        string line = $"文章标题：{model.ArticleTitle}\r\n文章简介：{model.ArticleSummary}\r\n文章地址：{model.ArticleUrl}";
                        sw.WriteLine(line + "\r\n ========================================================================================== \r\n");
                    }
                }
                return Task.CompletedTask;
            }
        }
    }
}
