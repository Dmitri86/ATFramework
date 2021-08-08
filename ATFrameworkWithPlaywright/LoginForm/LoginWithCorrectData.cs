using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.LoginForm
{
    [TestFixture]
    public class LoginWithCorrectData
    {
        [Test]
        public async Task LoginWithCorrectDataTest()
        {
            using var playwright = await Playwright.CreateAsync();
            await using var browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
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
            await page.TypeAsync("#username", "tomsmith");
            await page.TypeAsync("#password", "SuperSecretPassword!");
            await page.ClickAsync("button[type='submit']");
            var messageText = await page.TextContentAsync("#flash");
            Assert.IsTrue(messageText?.Trim().StartsWith("You logged into a secure area!"));
            var secureText = await page.TextContentAsync("h4");
            Assert.AreEqual("Welcome to the Secure Area. When you are done click logout below.", secureText);
            var button = await page.TextContentAsync("a.button");
            Assert.AreEqual("Logout", button?.Trim());
            await browser.CloseAsync();
        }
    }
}