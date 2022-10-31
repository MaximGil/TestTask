using Microsoft.Playwright;

namespace Pages;

public class MainPage : BasePage
{
    public MainPage(IPage page) : base(page)
    {
    }

    private ILocator InputField => Page.Locator("[id='number']");
    private ILocator CalculateButton => Page.Locator("//button[@id='getFactorial']");
    private ILocator ResultLocator => Page.Locator("[id='resultDiv']");
    private ILocator TitleLocator => Page.Locator("xpath=//h1[contains(@class, 'text-center')]");


    public async Task<bool> IsPageDisplayed()
    {
        return await InputField.IsEnabledAsync() && await CalculateButton.IsEnabledAsync() &&
               await ResultLocator.IsEnabledAsync() && await TitleLocator.IsEnabledAsync();
    }


}