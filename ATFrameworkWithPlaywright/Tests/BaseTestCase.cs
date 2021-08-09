using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Playwright;
using NUnit.Framework;

namespace ATFrameworkWithPlaywright.Tests
{
    public class BaseTestCase
    {
        private IPlaywright _playwright;
        private IBrowser _browser;
        protected IPage Page;
        protected string BaseUrl;
        private string _browserType;

        [SetUp]
        public async Task StartUp()
        {
            await Task.Factory.StartNew(InitializeConfig);
            _playwright = await Playwright.CreateAsync();
            _browser = await LaunchBrowser();
            Page = await _browser.NewPageAsync(new BrowserNewPageOptions
                {ViewportSize = new ViewportSize {Width = 1920, Height = 1080}});
        }


        [TearDown]
        public async Task ShutDown()
        {
            await _browser.CloseAsync();
        }

        private void InitializeConfig()
        {
            var configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appSettings.json")
                .Build();
            BaseUrl = configuration.GetSection("BaseUrl").Value;
            _browserType = configuration.GetSection("BrowserType").Value;
        }

        private Task<IBrowser> LaunchBrowser()
        {
            var options = new BrowserTypeLaunchOptions
                {Headless = false, SlowMo = 250};
            return _browserType switch
            {
                "Firefox" => _playwright.Firefox.LaunchAsync(options),
                "Webkit" => _playwright.Webkit.LaunchAsync(options),
                _ => _playwright.Chromium.LaunchAsync(options)
            };
        }
    }
}