using System;
using GumTreeSearchTest.Helper;
using OpenQA.Selenium;

namespace GumTreeSearchTest.Page
{
    public class AdvertDetailPage
    {
        private readonly IWebDriver _driver;

        public AdvertDetailPage(IWebDriver driver)
        {
            _driver = driver;
        }

        public IWebElement SliderDetails => _driver.FindElement(By.CssSelector("button span.icon-slider-arrow"), 30);
        public IWebElement CarouselNextArrow => _driver.FindElement(By.CssSelector("button.vip-ad-gallery__nav-btn--next"), 30);
        private IWebElement TotalNumberOfImagesLegend => _driver.FindElement(By.CssSelector("div.vip-ad-image__legend"), 30);
        public int TotalNumberOfImages => Convert.ToInt32(TotalNumberOfImagesLegend.Text.Replace("images", "").Trim());
    }
}
