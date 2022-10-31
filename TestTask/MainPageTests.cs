using Microsoft.Playwright.NUnit;
using Pages;

namespace TestTask;

public class MainPageTests : PageTest
{
    private MainPage? _mainPage;
    private string _title = "The greatest factorial calculator!";
    private string Result(string number, string count) => $"The factorial of {number} is: {count}";
    private readonly string _errorMessage = "Please enter an integer";

    [SetUp]
    public async Task Setup()
    {
        _mainPage = new MainPage(Page);
        await _mainPage.Goto();
    }

    [Test]
    public async Task PageIsEnabled()
    {
        Assert.That(await _mainPage!.IsPageDisplayed(), Is.True);
    }


    [TestCase("", "Please enter an integer")]
    [TestCase("@@", "Please enter an integer")]
    public async Task InvalidSymbolsCalculate(string number, string message)
    {
        await _mainPage!.Calculate(number);
        Assert.That(await _mainPage.GetResult(), Is.EqualTo(_errorMessage));
    }

    [TestCase("0", "1")]
    [TestCase("50", "3.0414093201713376e+64")]
    public async Task CalculateValidNumber(string number, string result)
    {
        await _mainPage!.Calculate(number);
        Assert.That(await _mainPage.GetResult(), Is.EqualTo(Result(number, result )));
    }
}