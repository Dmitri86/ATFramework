using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.LoginForm
{
    [TestFixture]
    public class LoginWithIncorrectPassword : BaseTestCase
    {
        [Test]
        public async Task LoginWithIncorrectPasswordTest()
        {
            await Page.GotoAsync("http://localhost:5000/login");
            var title = await Page.TextContentAsync("h2");
            Assert.AreEqual("Login Page", title);
            await Page.FillAsync("#username", "tomsmith");
            await Page.FillAsync("#password", "test");
            await Page.PressAsync("#password", "Enter");
            var textMessage = await Page.TextContentAsync("#flash");
            Assert.IsTrue(textMessage?.Trim().StartsWith("Your password is invalid!"));
            await Page.IsVisibleAsync("Login Page");
        }
    }
}