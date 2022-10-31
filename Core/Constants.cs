namespace Core;

public static class Constants
{
    public static string BaseUrl => "https://qainterview.pythonanywhere.com/";
    public static string FactorialPageUrl => BaseUrl + "factorial";
    public static string TermsPageUrl => BaseUrl + "terms";
    public static string PrivacyPageUrl => BaseUrl + "privacy";

    public static string TermsPageText =>
        "This is the terms and conditions document. We are not yet ready with it. Stay tuned!";

    public static string PrivacyPageText => "This is the privacy document. We are not yet ready with it. Stay tuned!";
}