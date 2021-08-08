using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.LoginForm
{
    [TestFixture]
    public class LoginWithIncorrectUsername
    {
        [Test]
        public async Task LoginWithIncorrectUsernameTest()
        {
            using var playwright = await Playwright.CreateAsync();
            var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false, SlowMo = 50
            });
            var page = await browser.NewPageAsync(new BrowserNewPageOptions
            {
                ViewportSize = new ViewportSize {Width = 1920, Height = 1080}
            });
            await page.GotoAsync("http://localhost:5000/login");
            var title = await page.TextContentAsync("h2");
            Assert.AreEqual("Login Page", title);
            await page.TypeAsync("#username", "test");
            await page.TypeAsync("#password", "SuperSecretPassword!");
            await page.ClickAsync("button");
            var textMessage = await page.TextContentAsync("#flash");
            Assert.IsTrue(textMessage?.Trim().StartsWith("Your username is invalid!"));
            await page.IsVisibleAsync("Login Page");
            await browser.CloseAsync();
        }
    }
}