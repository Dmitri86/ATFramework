using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Pages;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright
{
    [TestFixture]
    public class DropDawnDefaultValue : BaseTestCase
    {
        [Test]
        public async Task CheckDefaultValue()
        {
            await Page.GotoAsync(BaseUrl + "dropdown");
            var title = await Page.TextContentAsync(DropDawnPage.Title);
            Assert.AreEqual("Dropdown List", title);
            var defaultOption = await Page.TextContentAsync(DropDawnPage.SelectedOption);
            Assert.AreEqual("Please select an option", defaultOption);
        }
    }
}