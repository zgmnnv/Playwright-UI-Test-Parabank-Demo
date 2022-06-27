using System.Text;

namespace PlaywrightDemoTestProject.Helpers;

public class UserGenerator
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string state { get; set; }
    public string zipcode { get; set; }
    public string phone { get; set; }
    public string ssn { get; set; }
    public string username { get; set; }
    public string password { get; set; }
    public string confirmPassword { get; set; }

    private const string _alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvxyzabcdefghijklmnopqrstuvxyz";
    private const int stringLength = 12;
    private readonly Random _random = new Random();

    public async Task GenerateValidUserCredentials()
    {
        firstName = await GetRandonString();
        lastName = await GetRandonString();
        address = await GetRandonString();
        city = await GetRandonString();
        state = await GetRandonString();
        zipcode = await GetRandomStringNumber();
        phone = await GetRandomStringNumber();
        ssn = await GetRandomStringNumber();
        username = await GetRandonString();
        password = await GetRandonString();
        confirmPassword = password;
    }

    private async Task<string> GetRandonString()
    {
        return new string(Enumerable.Repeat(_alphabet, stringLength)
            .Select(s => s[_random.Next(s.Length)]).ToArray());
    }

    private async Task<string> GetRandomStringNumber()
    {
        return _random.Next(1000,999999999).ToString();
    }


}