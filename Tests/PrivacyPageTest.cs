using Core;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Pages;

namespace TestTask;

public class PrivacyPageTest : PageTest
{
    private PrivacyPage? _privacyPage;

    [SetUp]
    public async Task SetUp()
    {
        _privacyPage = new PrivacyPage(Page);
        await _privacyPage.Goto(Constants.PrivacyPageUrl);
    }

    [Test]
    public async Task PageIsOpened()
    {
        var innerText = await _privacyPage!.GetText();
        Assert.Multiple(() =>
        {
            Assert.That(_privacyPage.GetUrl(), Is.EqualTo(Constants.PrivacyPageUrl));
            Assert.That(innerText,
                Is.EqualTo(Constants.PrivacyPageText));
        });
    }
}