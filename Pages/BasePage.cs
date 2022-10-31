using Microsoft.Playwright;

namespace Pages;

public abstract class BasePage
{
    protected readonly IPage Page;

    protected BasePage(IPage page)
    {
        Page = page;
    }

    public virtual async Task Goto(string url = "https://qainterview.pythonanywhere.com/" ) => await Page.GotoAsync(url);
}