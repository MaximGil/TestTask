using Core;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Pages;

namespace TestTask;

public class FactorialPageTests : PageTest
{
    private FactorialPage? _factorialPage;
    private string Result(string number, string count) => $"The factorial of {number} is: {count}";
    private readonly string _errorMessage = "Please enter an integer";

    [SetUp]
    public async Task Setup()
    {
        _factorialPage = new(Page);
        await _factorialPage.Goto(Constants.FactorialPageUrl);
    }

    [Test]
    public async Task PageIsEnabled()
    {
        Assert.That(await _factorialPage!.IsPageDisplayed(), Is.True);
    }


    [TestCase("", "Please enter an integer")]
    [TestCase("@@", "Please enter an integer")]
    public async Task InvalidSymbolsCalculate(string number, string message)
    {
        await _factorialPage!.Calculate(number);
        Assert.That(await _factorialPage.GetResult(), Is.EqualTo(_errorMessage));
    }

    [TestCase("0", "1")]
    [TestCase("50", "3.0414093201713376e+64")]
    public async Task CalculateValidNumber(string number, string result)
    {
        await _factorialPage!.Calculate(number);
        Assert.That(await _factorialPage.GetResult(), Is.EqualTo(Result(number, result)));
    }

    [Test]
    public async Task OpenTerms()
    {
        var termsPage = await _factorialPage!.OpenTermsPage();
        Assert.AreEqual(Constants.TermsPageUrl, termsPage.GetUrl());
    }

    [Test]
    public async Task OpenPrivacy()
    {
        var privacyPage = await _factorialPage!.OpenPrivacyPage();
        Assert.AreEqual(Constants.PrivacyPageUrl, privacyPage.GetUrl());
    }
}