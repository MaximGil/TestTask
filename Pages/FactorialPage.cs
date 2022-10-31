using Microsoft.Playwright;

namespace Pages;

public class FactorialPage : BasePage
{
    public FactorialPage(IPage page) : base(page)
    {
    }

    private ILocator InputField => Page.Locator("[id='number']");
    private ILocator CalculateButton => Page.Locator("//button[@id='getFactorial']");
    private ILocator Result => Page.Locator("[id='resultDiv']");
    private ILocator Title => Page.Locator("xpath=//h1[contains(@class, 'text-center')]");
    private ILocator Footer => Page.Locator("xpath=//div[@class='row-fluid']");
    private ILocator Privacy => Page.Locator("[href='/terms']");
    private ILocator TermAndConditions => Page.Locator("[href='/privacy']");


    public async Task Calculate(string number)
    {
        await InputField.FillAsync(number);
        await CalculateButton.ClickAsync();
    }

    public async Task<string> GetResult()
    {
        await Result.WaitForAsync(new LocatorWaitForOptions { State = WaitForSelectorState.Visible });
        return await Result.InnerTextAsync();
    }

    public async Task<bool> IsPageDisplayed()
    {
        return await InputField.IsEnabledAsync() && await CalculateButton.IsEnabledAsync() &&
               await Result.IsEnabledAsync() && await Title.IsEnabledAsync() &&
               await Footer.IsEnabledAsync();
    }

    public async Task<PrivacyPage> OpenPrivacyPage()
    {
        await Privacy.ClickAsync();
        return new PrivacyPage(Page);
    }

    public async Task<TermsPage> OpenTermsPage()
    {
        await TermAndConditions.ClickAsync();
        return new TermsPage(Page);
    }
}