using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.DragAndDrop
{
    [TestFixture]
    [AllureNUnit]
    public class DragAndDropDefaultValue : BaseTestCase
    {
        [Test]
        public async Task CheckDefaultState()
        {
            await Page.GotoAsync(BaseUrl + "drag_and_drop");
            var title = await Page.TextContentAsync("h3");
            Assert.AreEqual("Drag and Drop", title);
            var defaultOption = await Page.TextContentAsync("#columns div:first-child");
            Assert.AreEqual("A", defaultOption);
        }
    }
}