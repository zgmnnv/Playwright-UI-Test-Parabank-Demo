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

        public ILocator FirstNameError;
        public ILocator LastNameError;
        public ILocator AddressError;
        public ILocator CityError;
        public ILocator StateError;
        public ILocator ZipCodeError;
        public ILocator PhoneError;
        public ILocator SsnError;
        public ILocator UsernameError;
        public ILocator PasswordError;
        public ILocator ConfirmPasswordError;

        public ILocator WelcomeTitle;
        public ILocator WelcomeMessage;

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

            FirstNameError = _page.Locator("//span[@id='customer.firstName.errors']");
            LastNameError = _page.Locator("//span[@id='customer.lastName.errors']");
            AddressError = _page.Locator("//span[@id='customer.address.street.errors']");
            CityError = _page.Locator("//span[@id='customer.address.city.errors']");
            StateError = _page.Locator("//span[@id='customer.address.state.errors']");
            ZipCodeError = _page.Locator("//span[@id='customer.address.zipCode.errors']");
            SsnError = _page.Locator("//span[@id='customer.ssn.errors']");
            UsernameError = _page.Locator("//span[@id='customer.username.errors']");
            PasswordError = _page.Locator("//span[@id='customer.password.errors']");
            ConfirmPasswordError = _page.Locator("//span[@id='repeatedPassword.errors']");

            
            WelcomeMessage = _page.Locator("//p[contains(text(),'Your account was created successfully. You are now')]");
            WelcomeTitle = _page.Locator("//h1[@class='title']");
        }
        
        public async Task OpenPage()
        {
            await _page.GotoAsync(Urls.RegisterPageUrl);
        }
        public async Task<bool> InspectRegisterFormTitle()
        {
            var actualTitle = await _registerFormTitle.TextContentAsync();
            var expectedTitle = "Signing up is easy!";
            var isRegisterTitleValid = actualTitle == expectedTitle;
            return isRegisterTitleValid;
        }
        
        public async Task<bool> InspectRegisterFormSubtitle()
        {
            var actualSubtitle = await _registerFormSubtitle.TextContentAsync();
            var expectedSubtitle = "If you have an account with us you can sign-up for free instant online access. " +
                "You will have to provide some personal information.";
            var isRegisterSubtitleValid = actualSubtitle == expectedSubtitle;
            return isRegisterSubtitleValid;

        }

        public async Task ClickRegisterButton()
        {
            _registerButton.ClickAsync();
        }

        public async Task<string> GetErrorMessage(ILocator locator)
        {
            var actualErrorMessage = await locator.TextContentAsync();
            return actualErrorMessage;
        }

        public async Task SetFieldValue(ILocator locator, string value)
        {
            await locator.FillAsync(value);
        }

        public async Task FillOutAllFields(string firstName, string lastName, string address, string city, string state, 
            string zipCode, string phone, string ssn, string username, string password, string confirmPassword)
        {
            await SetFieldValue(_firstNameField, firstName);
            await SetFieldValue(_lastNameField, lastName);
            await SetFieldValue(_addressField, address);
            await SetFieldValue(_cityField, city);
            await SetFieldValue(_stateField, state);
            await SetFieldValue(_zipCodeField, zipCode);
            await SetFieldValue(_phoneField, phone);
            await SetFieldValue(_ssnField, ssn);
            await SetFieldValue(_usernameField, username);
            await SetFieldValue(_passwordField, password);
            await SetFieldValue(_confirmPasswordField, confirmPassword);
        }

    }
}
