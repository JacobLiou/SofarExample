// See https://aka.ms/new-console-template for more information
using CrawlDemo;

Console.WriteLine("Hello, World!");

Console.WriteLine("网页数据抓取开始...");

await RecommendedRankingSpider.RunAsync();

Console.WriteLine("网页数据抓取完成...");
