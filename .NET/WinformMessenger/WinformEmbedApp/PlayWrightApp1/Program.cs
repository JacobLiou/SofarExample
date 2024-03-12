// See https://aka.ms/new-console-template for more information
using Microsoft.Playwright;

Console.WriteLine("Hello, World!");

var playWright = await Playwright.CreateAsync();
var browser = await playWright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = true});

var page = await browser.NewPageAsync();

await page.GotoAsync("Https://www.baidu.com");
