﻿using System.Threading.Tasks;
using ATFrameworkWithPlaywright.Tests;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.DragAndDrop
{
    [TestFixture]
    public class DragAndDropFirstElement : BaseTestCase
    {
        [Test]
        public async Task DragAndDropFirstElementTest()
        {
            await Page.GotoAsync("http://localhost:5000/drag_and_drop");
            var title = await Page.TextContentAsync("h3");
            Assert.AreEqual("Drag and Drop", title);
            await Page.DragAndDropAsync("#columns div:first-child", "#columns div:last-child");
            var defaultOption = await Page.TextContentAsync("#columns div:first-child");
            Assert.AreEqual("B", defaultOption);
        }
    }
}