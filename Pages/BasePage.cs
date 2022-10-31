using Microsoft.Playwright;

namespace Pages;

public abstract class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }

    public async Task Goto(string url) => await Page.GotoAsync(url);
}