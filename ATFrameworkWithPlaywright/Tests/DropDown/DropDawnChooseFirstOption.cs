using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Pages;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright
{
    [AllureNUnit]
    [TestFixture]
    public class DropDawnChooseFirstOption : BaseTestCase
    {
        [Test]
        public async Task CheckDefaultValue()
        {
            await Page.GotoAsync(BaseUrl + "dropdown");
            var title = await Page.TextContentAsync(DropDawnPage.Title);
            Assert.AreEqual("Dropdown List", title);
            await Page.EvaluateAsync(
                $"let dropdown = document.querySelector('{DropDawnPage.DropDawn}'); " +
                "let options = dropdown.querySelectorAll('option');" +
                "let index = -1;" +
                "for(let i = 0; i < options.length; i++){if(options[i].text === 'Option 1') {index = i; break;}}" +
                "dropdown.options.selectedIndex = index;" +
                "let event = new Event('change'); " +
                "dropdown.dispatchEvent(event);");
            var actualOption = await Page.TextContentAsync(DropDawnPage.SelectedOption);
            Assert.AreEqual("Option 1", actualOption);
        }
    }
}