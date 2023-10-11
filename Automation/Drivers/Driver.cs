using System;
using Microsoft.Playwright;

namespace Automation.Drivers
{
    public class Driver : IDisposable
    {
        //Creando el elemento _page
        private readonly Task<IPage> _page; 
        private IBrowser? _browser;

        public Driver() //Creando el constructor
        {
            _page = InitializePlaywright();
        }

        public IPage Page => _page.Result;
        public async Task<IPage> InitializePlaywright()
        {
            //Playwright
            var playwright = await Playwright.CreateAsync();
            //Browser
            
            _browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false 
            });
            
            //Page
            return await _browser.NewPageAsync();
        }

        public void Dispose() => _browser?.CloseAsync();
        
    }
}