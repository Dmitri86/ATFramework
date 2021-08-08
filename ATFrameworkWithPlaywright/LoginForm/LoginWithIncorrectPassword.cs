using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.LoginForm
{
    [TestFixture]
    public class LoginWithIncorrectPassword
    {
        [Test]
        public async Task LoginWithIncorrectPasswordTest()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {Headless = false, SlowMo = 50});
            var page = await browser.NewPageAsync(new BrowserNewPageOptions
                {ViewportSize = new ViewportSize {Height = 1080, Width = 1920}});
            await page.GotoAsync("http://localhost:5000/login");
            var title = await page.TextContentAsync("h2");
            Assert.AreEqual("Login Page", title);
            await page.FillAsync("#username", "tomsmith");
            await page.FillAsync("#password", "test");
            await page.PressAsync("#password", "Enter");
            var textMessage = await page.TextContentAsync("#flash");
            Assert.IsTrue(textMessage?.Trim().StartsWith("Your password is invalid!"));
            await page.IsVisibleAsync("Login Page");
            await browser.CloseAsync();
        }
    }
}