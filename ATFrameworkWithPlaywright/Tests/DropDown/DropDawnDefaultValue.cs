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
            await Page.GotoAsync("http://localhost:5000/dropdown");
            var title = await Page.TextContentAsync(DropDawnPage.Title);
            Assert.AreEqual("Dropdown List", title);
            var defaultOption = await Page.TextContentAsync(DropDawnPage.SelectedOption);
            Assert.AreEqual("Please select an option", defaultOption);
        }
    }
}