using Core;
using Microsoft.Playwright.NUnit;
using NUnit.Framework;
using Pages;

namespace TestTask;

public class TermsPageTest : PageTest
{
    private TermsPage? _termsPage;

    [SetUp]
    public async Task SetUp()
    {
        _termsPage = new TermsPage(Page);
        await _termsPage.Goto(Constants.TermsPageUrl);
    }

    [Test]
    public async Task PageIsOpened()
    {
        var innerText = await _termsPage!.GetText();
        Assert.Multiple(() =>
        {
            Assert.That(_termsPage.GetUrl(), Is.EqualTo(Constants.TermsPageUrl));
            Assert.That(innerText,
                Is.EqualTo(Constants.TermsPageText));
        });
    }
}