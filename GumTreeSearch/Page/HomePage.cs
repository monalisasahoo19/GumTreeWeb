using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium;

namespace GumTreeSearchTest.Page
{
    public class HomePage
    {
        private readonly IWebDriver _driver;

        public HomePage(IWebDriver driver)
        {
            _driver = driver;
        }

        private IWebElement CategoriesDropDown => _driver.FindElement(By.Id("categoryId-wrp"));
        private IEnumerable<IWebElement> ItemCategories => _driver.FindElements(By.CssSelector("div#categoryId-wrpwrapper > ul > li"));
        private IWebElement SearchQueryName => _driver.FindElement(By.Id("search-query"));
        private IWebElement LocationInput => _driver.FindElement(By.Id("search-area"));
        private IWebElement RadiusInput => _driver.FindElement(By.Id("srch-radius-input"));
        private IEnumerable<IWebElement> DistanceRadiuses => _driver.FindElements(By.CssSelector("div#srch-radius-wrpwrapper > ul > li"));
        private IWebElement SearchButton => _driver.FindElement(By.CssSelector("button[type='submit']"));
      
        public void EnterSearchCriteria(string name, string itemName,string locationName,string radius)
        {
            CategoriesDropDown.Click();
            var itemCategory = ItemCategories.FirstOrDefault(x=> x.Text.Equals(name,StringComparison.OrdinalIgnoreCase));
            itemCategory?.Click();

            SearchQueryName.SendKeys(itemName);

            LocationInput.SendKeys(locationName);

            RadiusInput.Click();
            var radiusValue = DistanceRadiuses.FirstOrDefault(x => x.Text.Equals(radius, StringComparison.OrdinalIgnoreCase));
            radiusValue?.Click();

            SearchButton.Click();
        }

       
    }
}
