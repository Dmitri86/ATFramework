using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.DragAndDrop
{
    [TestFixture]
    public class DragAndDropFirstElement
    {
        [Test]
        public async Task DragAndDropFirstElementTest()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser =
                await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {Headless = false, SlowMo = 250, Devtools = true});
            var page = await browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize {Width = 1920, Height = 1080}
            });
            await page.GotoAsync("http://localhost:5000/drag_and_drop");
            var title = await page.TextContentAsync("h3");
            Assert.AreEqual("Drag and Drop", title);
            await page.DragAndDropAsync("#columns div:first-child", "#columns div:last-child");
            var defaultOption = await page.TextContentAsync("#columns div:first-child");
            Assert.AreEqual("B", defaultOption);
            await browser.CloseAsync();
        }
    }
}