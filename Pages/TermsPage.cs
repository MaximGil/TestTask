using Microsoft.Playwright;

namespace Pages;

public class TermsPage : BasePage
{
    public TermsPage(IPage page) : base(page)
    {
    }

    private ILocator PageText() => Page.Locator("body");

    public string GetUrl() => Page.Url;
    public async Task<string> GetText() => await PageText().InnerTextAsync();
}