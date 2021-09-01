using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Allure.Core;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.DragAndDrop
{
    [AllureNUnit]
    [TestFixture]
    public class DragAndDropSecondElement : BaseTestCase
    {
        [Test]
        public async Task DragAndDropSecondElementTest()
        {
            await Page.GotoAsync(BaseUrl + "drag_and_drop");
            var title = await Page.TextContentAsync("h3");
            Assert.AreEqual("Drag and Drop", title);
            await Page.DragAndDropAsync("#columns div:last-child", "#columns div:first-child");
            var defaultOption = await Page.TextContentAsync("#columns div:first-child");
            Assert.AreEqual("B", defaultOption);
        }
    }
}