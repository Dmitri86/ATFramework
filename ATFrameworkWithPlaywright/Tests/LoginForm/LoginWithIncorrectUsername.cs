using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.LoginForm
{
    [TestFixture]
    public class LoginWithIncorrectUsername : BaseTestCase
    {
        [Test]
        public async Task LoginWithIncorrectUsernameTest()
        {
            await Page.GotoAsync(BaseUrl + "login");
            var title = await Page.TextContentAsync("h2");
            Assert.AreEqual("Login Page", title);
            await Page.TypeAsync("#username", "test");
            await Page.TypeAsync("#password", "SuperSecretPassword!");
            await Page.ClickAsync("button");
            var textMessage = await Page.TextContentAsync("#flash");
            Assert.IsTrue(textMessage?.Trim().StartsWith("Your username is invalid!"));
            await Page.IsVisibleAsync("Login Page");
        }
    }
}