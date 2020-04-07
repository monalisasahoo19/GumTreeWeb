using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace GumTreeSearchTest.Helper
{
    public static class Extensions
    {
        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));

                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void WaitUntilPageLoadsCompletely(this IWebDriver driver, int timeoutInSeconds = 60)
        {
            new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds))
                .Until(drv =>
                    ((IJavaScriptExecutor) driver).ExecuteScript("return document.readyState").Equals("complete"));
        }

    }
}
