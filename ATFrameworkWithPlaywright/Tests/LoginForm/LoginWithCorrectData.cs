using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.LoginForm
{
    [TestFixture]
    public class LoginWithCorrectData : BaseTestCase
    {
        [Test]
        public async Task LoginWithCorrectDataTest()
        {
            await Page.GotoAsync(BaseUrl + "login");
            var title = await Page.TextContentAsync("h2");
            Assert.AreEqual("Login Page", title);
            await Page.TypeAsync("#username", "tomsmith");
            await Page.TypeAsync("#password", "SuperSecretPassword!");
            await Page.ClickAsync("button[type='submit']");
            var messageText = await Page.TextContentAsync("#flash");
            Assert.IsTrue(messageText?.Trim().StartsWith("You logged into a secure area!"));
            var secureText = await Page.TextContentAsync("h4");
            Assert.AreEqual("Welcome to the Secure Area. When you are done click logout below.", secureText);
            var button = await Page.TextContentAsync("a.button");
            Assert.AreEqual("Logout", button?.Trim());
        }
    }
}