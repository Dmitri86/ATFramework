using System.Threading;
using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright
{
    [TestFixture]
    public class DropDawnChooseSecondOption
    {
        [Test]
        public async Task CheckDefaultValue()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser =
                await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                    {Headless = false, SlowMo = 50, Devtools = true});
            var page = await browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize {Width = 1920, Height = 1080}
            });
            await page.GotoAsync("http://localhost:5000/dropdown");
            var title = await page.TextContentAsync("h3");
            Assert.AreEqual("Dropdown List", title);
            await page.EvaluateAsync(
                "let dropdown = document.querySelector('#dropdown'); " +
                "dropdown.options.selectedIndex = 2;" +
                "let event = new Event('change'); " +
                "dropdown.dispatchEvent(event);");
            var actualOption = await page.TextContentAsync("option[selected='selected']");
            Assert.AreEqual("Option 2", actualOption);
            await browser.CloseAsync();
        }
    }
}