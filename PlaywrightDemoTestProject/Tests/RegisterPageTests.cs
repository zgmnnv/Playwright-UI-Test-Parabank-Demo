using Microsoft.Playwright;
using PlaywrightDemoTestProject.PageObjects;
using PlaywrightDemoTestProject.Constants;

namespace PlaywrightDemoTestProject
{
    public class RegisterPageTests
    {
        IPlaywright playwright;
        IBrowser browser;
        IPage page;
        MainPage mainPage;
        RegisterPage registerPage;

    [SetUp]
        public async Task Setup()
        {
            playwright = await Playwright.CreateAsync();
            browser = await playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
            page = await browser.NewPageAsync();
            mainPage = new MainPage(page);
            registerPage = new RegisterPage(page);
        }

        [Test]
        public async Task GoToRegisterPageFromMainPage_InspectRegisterPageTitleAndUrl()
        {
            await mainPage.openPage();
            await mainPage.clickToRegisterLink();

            var expectedPageTitle = PageTitles.RegistrationPageTitle;
            var actualPageTitle = await page.TitleAsync();
            var expectedPageUrl = Urls.RegisterPageUrl;
            var actualPageUrl = page.Url.Substring(0, 51);

            Assert.That(actualPageTitle, Is.EqualTo(expectedPageTitle));
            Assert.That(actualPageUrl, Is.EqualTo(expectedPageUrl));

        }

        [Test]
        public async Task GoToRegistrationPageByUrl_InspectRegisterFormTitles()
        {
            await registerPage.openPage();

            var isRegisterFormTitleValid =  await registerPage.inspectRegisterFormTitle();
            var isRegisterFormSubtitleValid = await registerPage.inspectRegisterFormSubtitle();

            Assert.IsTrue(isRegisterFormTitleValid);
            Assert.IsTrue(isRegisterFormSubtitleValid);
        }
    }
}