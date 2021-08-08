using System.Threading.Tasks;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.Tests
{
    public class BaseTestCase
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        protected IPage Page;
        
        [SetUp]
        public void StartUp()
        {
            Initialize().Wait();
        }

        private async Task Initialize()
        {
            _playwright = await Playwright.CreateAsync();
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
                {Headless = false, SlowMo = 50, Devtools = true});
            Page = await _browser.NewPageAsync(new BrowserNewPageOptions
                {ViewportSize = new ViewportSize {Width = 1920, Height = 1080}});
        }


        [TearDown]
        public void ShutDown()
        {
            CloseBrowser().Wait();
        }

        private async Task CloseBrowser()
        {
            await _browser.CloseAsync();
        }
    }
}