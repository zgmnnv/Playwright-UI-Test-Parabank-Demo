using Microsoft.Playwright;
using PlaywrightDemoTestProject.Constants.ErrorMessages;
using PlaywrightDemoTestProject.Helpers;
using PlaywrightDemoTestProject.PageObjects;

namespace PlaywrightDemoTestProject;

public class UserRegistrationTest
{
    private IPlaywright _playwright;
    private IBrowser _browser;
    private IPage _page;
    private RegisterPage _registerPage;
    private UserGenerator _userGenerator;

    [SetUp]
    public async Task Setup()
    {
        _playwright = await Playwright.CreateAsync();
        _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions { Headless = false });
        _page = await _browser.NewPageAsync();
        _registerPage = new RegisterPage(_page);
        _userGenerator = new UserGenerator();

        await _registerPage.OpenPage();
    }

    [TearDown]
    public async Task TearDown()
    {
   
    }

    [Test]
    public async Task UserRegistration_ValidCredentials_RegistrationIsSuccessful()
    {
        await _userGenerator.GenerateValidUserCredentials();

        await _registerPage.FillOutAllFields(
            _userGenerator.firstName,
            _userGenerator.lastName,
            _userGenerator.address,
            _userGenerator.city,
            _userGenerator.state,
            _userGenerator.zipcode,
            _userGenerator.phone,
            _userGenerator.ssn,
            _userGenerator.username,
            _userGenerator.password,
            _userGenerator.confirmPassword);

        await _registerPage.ClickRegisterButton();
        await _page.WaitForNavigationAsync();

        var actualWelcomeTitle = await _registerPage.WelcomeTitle.TextContentAsync();
        var actualWelcomeMessage = await _registerPage.WelcomeMessage.TextContentAsync();
        var expectedWelcomeMessage = "Your account was created successfully. You are now logged in.";

        Assert.AreEqual($"Welcome {_userGenerator.username}", actualWelcomeTitle);
        Assert.AreEqual(expectedWelcomeMessage, actualWelcomeMessage);
    }

    [Test]
    public async Task UserRegistration_AllFieldsIsEmpty_InspectErrorMessages()
    {
        await _registerPage.ClickRegisterButton();

        var actualFirstNameError = await _registerPage.GetErrorMessage(_registerPage.FirstNameError);
        var actualLastNameError = await _registerPage.GetErrorMessage(_registerPage.LastNameError);
        var actualAddressError = await _registerPage.GetErrorMessage(_registerPage.AddressError);
        var actualCityError = await _registerPage.GetErrorMessage(_registerPage.CityError);
        var actualStateError = await _registerPage.GetErrorMessage(_registerPage.StateError);
        var actualZipCodeError = await _registerPage.GetErrorMessage(_registerPage.ZipCodeError);
        var actualSsnError = await _registerPage.GetErrorMessage(_registerPage.SsnError);
        var actualUsernameError = await _registerPage.GetErrorMessage(_registerPage.UsernameError);
        var actualPasswordError = await _registerPage.GetErrorMessage(_registerPage.PasswordError);
        var actualConfirmPasswordError = await _registerPage.GetErrorMessage(_registerPage.ConfirmPasswordError);

        Assert.AreEqual(RegisterPageMessages.FirstNameError, actualFirstNameError);
        Assert.AreEqual(RegisterPageMessages.LastNameError, actualLastNameError);
        Assert.AreEqual(RegisterPageMessages.AddressError, actualAddressError);
        Assert.AreEqual(RegisterPageMessages.CityError, actualCityError);
        Assert.AreEqual(RegisterPageMessages.StateError, actualStateError);
        Assert.AreEqual(RegisterPageMessages.ZipCodeError, actualZipCodeError);
        Assert.AreEqual(RegisterPageMessages.SnnError, actualSsnError);
        Assert.AreEqual(RegisterPageMessages.UsernameError, actualUsernameError);
        Assert.AreEqual(RegisterPageMessages.PasswordError, actualPasswordError);
        Assert.AreEqual(RegisterPageMessages.ConfirmPasswordError, actualConfirmPasswordError);
    }
}