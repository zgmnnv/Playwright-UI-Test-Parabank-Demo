
using Microsoft.Playwright;
using PlaywrightDemoTestProject.Constants;

namespace PlaywrightDemoTestProject.PageObjects
{
    public class MainPage
    {
        private static IPage _page;
        private ILocator _registerLink;

        public MainPage(IPage page)
        {
            _page = page;
            _registerLink = page.Locator("//*[text() = 'Register']");
        }

        public async Task openPage()
        {
            await _page.GotoAsync(Urls.MainPageUrl);
        }

        public async Task clickToRegisterLink()
        {
            await _registerLink.ClickAsync();
        }
    }
}
