using Microsoft.Playwright;
using PlaywrightDemoTestProject.Constants;

namespace PlaywrightDemoTestProject.PageObjects
{
    internal class RegisterPage
    {
        private static IPage _page;

        private ILocator _registerFormTitle;
        private ILocator _registerFormSubtitle;

        private ILocator _firstNameField;
        private ILocator _lastNameField;
        private ILocator _addressField;
        private ILocator _cityField;
        private ILocator _stateField;
        private ILocator _zipCodeField;
        private ILocator _phoneField;
        private ILocator _ssnField;
        private ILocator _usernameField;
        private ILocator _passwordField;
        private ILocator _confirmPasswordField;
        private ILocator _registerButton;

        public RegisterPage(IPage page)
        {
            _page = page;

            _registerFormTitle = _page.Locator("//h1[@class='title']");
            _registerFormSubtitle = _page.Locator("//p[contains(text(),'If you have an account with us you can sign-up for')]");

            _firstNameField = _page.Locator("//input[@id='customer.firstName']");
            _lastNameField = _page.Locator("//input[@id='customer.lastName']");
            _addressField = _page.Locator("//input[@id='customer.address.street']");
            _cityField = _page.Locator("//input[@id='customer.address.city']");
            _stateField = _page.Locator("//input[@id='customer.address.state']");
            _zipCodeField = _page.Locator("//input[@id='customer.address.zipCode']");
            _phoneField = _page.Locator("//input[@id='customer.phoneNumber']");
            _ssnField = _page.Locator("//input[@id='customer.ssn']");

            _usernameField = _page.Locator("//input[@id='customer.username']");
            _passwordField = _page.Locator("//input[@id='customer.password']");
            _confirmPasswordField = _page.Locator("//input[@id='repeatedPassword']");
            _registerButton = _page.Locator("//input[@value='Register']");
        }
        
        public async Task openPage()
        {
            await _page.GotoAsync(Urls.RegisterPageUrl);
        }
        public async Task<bool> inspectRegisterFormTitle()
        {
            var actualTitle = await _registerFormTitle.TextContentAsync();
            var expectedTitle = "Signing up is easy!";
            var isRegisterTitleValid = actualTitle == expectedTitle;
            return isRegisterTitleValid;
        }
        
        public async Task<bool> inspectRegisterFormSubtitle()
        {
            var actualSubtitle = await _registerFormSubtitle.TextContentAsync();
            var expectedSubtitle = "If you have an account with us you can sign-up for free instant online access. " +
                "You will have to provide some personal information.";
            var isRegisterSubtitleValid = actualSubtitle == expectedSubtitle;
            return isRegisterSubtitleValid;

        }

    }
}
