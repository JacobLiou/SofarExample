using System.Threading.Tasks;
using Microsoft.Playwright;

public class CallPlayWright
{
    public async Task TaskScreenshot(string filename)
    {
        using var playwright = await Playwright.CreateAsync();
        // var page = await browser.Chromium.NewpageAsync();

        await using var browser = await playwright.Chromium.LaunchAsync(new() { Headless = false });
        var page = await browser.NewPageAsync();

        var screenshotOptions = new PageScreenshotOptions
        {
            FullPage = true,
            Quality = 90,
        };

        await page.GotoAsync("https://playwright.dev/dotnet");
        await page.ScreenshotAsync(new() { Path = $"{filename}.png" });

    }
}