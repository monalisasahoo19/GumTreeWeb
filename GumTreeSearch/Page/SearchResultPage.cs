using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using GumTreeSearchTest.Helper;
using OpenQA.Selenium;

namespace GumTreeSearchTest.Page
{
    public class SearchResultPage
    {
        private readonly IWebDriver _driver;

        public SearchResultPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SearchResultSummary => _driver.FindElement(By.CssSelector("h1.breadcrumbs__summary--enhanced"), 30);
        public ICollection<IWebElement> SearchResults => _driver.FindElements(By.CssSelector("section.search-results-page__user-ad-collection a.user-ad-row"));
        private IWebElement PageSearchResultOptions => _driver.FindElement(By.CssSelector("div.results-per-page-selector"));

        public bool AssertPaginationActive(IWebElement pageLink) => pageLink.GetAttribute("class").Contains("page-number-navigation__link-number--current");

        public string PageSearchSelectedResult
        {
            get
            {
                ScrollToFooterResultSection();

                var je = (IJavaScriptExecutor)_driver;

                return (string)je.ExecuteScript("return arguments[0].options[arguments[0].selectedIndex].text;",
                    _driver.FindElement(By.CssSelector("div.results-per-page-selector select")));
            }

        }

        public IWebElement ClickOnPaginationLink(int pageNumber)
        {
           var pageLinks = _driver.FindElements(By.CssSelector(".page-number-navigation > a.page-number-navigation__link-number"));
           var pageLink = pageLinks[pageNumber - 1];
           pageLink.Click();
           Thread.Sleep(TimeSpan.FromSeconds(10));
           ScrollToFooterResultSection();
           return pageLink;
        }

        public IWebElement ClickOnRandomAdvert()
        {
            var randomElementNumber = new Random().Next(1, SearchResults.Count -1);
            var randomAdvert = SearchResults.ToList()[randomElementNumber];
            randomAdvert.Click();
            _driver.WaitUntilPageLoadsCompletely();
            return randomAdvert;
        }


        private void ScrollToFooterResultSection()
        {
            IJavaScriptExecutor je = (IJavaScriptExecutor)_driver;
            je.ExecuteScript("arguments[0].scrollIntoView(false);", PageSearchResultOptions);

        }
    }
}
