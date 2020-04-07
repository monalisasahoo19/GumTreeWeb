using System;
using System.Configuration;
using System.Text.RegularExpressions;
using GumTreeSearchTest.Page;
using NUnit.Framework;
using OpenQA.Selenium;

namespace GumTreeSearchTest.Test
{
    [TestFixture]
    public class SearchQueryTests
    {

        private IWebDriver _driver;

        private HomePage _homepage;
        private SearchResultPage _searchResultPage;
        private AdvertDetailPage _advertDetailPage;


        /// <summary>
        /// 1. Open a Chrome browser
        /// </summary>
        [OneTimeSetUp]
        public void Init()
        {
            _driver = new DriverFactory().GetDriver();

            _homepage = new HomePage(_driver);
            _searchResultPage = new SearchResultPage(_driver);
            _advertDetailPage = new AdvertDetailPage(_driver);
          

            _driver.Manage().Window.Maximize();

            _driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["Url"]);
        }


        /// <summary>
        /// 2. Complete the landing page values to resemble the given screen grab.
        /// 3. Click Search
        /// 4. On the results page count the number of results found on the first page.
        /// 5. Find label at bottom of page that shows the number of results.
        /// 6. Confirm that the number of results on the page matches the number of results show in label.
        /// </summary>
        [Test, Order(1)]
        public void VerifySearchResult()
        {
            _homepage.EnterSearchCriteria("Cars & Vehicles", "Toyota", "Wollongong Region, NSW", "250km");
            
            Assert.IsTrue(_searchResultPage.SearchResultSummary.Text.Contains("toyota"));
            Assert.IsTrue(_searchResultPage.SearchResultSummary.Text.Contains("Wollongong Region, NSW"));


            var resultPattern = @"^\d+ results per page$";
            Assert.IsTrue(Regex.IsMatch(_searchResultPage.PageSearchSelectedResult, resultPattern),"Should show the number of results per page");


            var searchCountNumber = Convert.ToInt32(Regex.Match(_searchResultPage.PageSearchSelectedResult, @"\d+").Value);
            
            //This test is failing as expected doesn't match to actual result
            Assert.AreEqual(searchCountNumber, _searchResultPage.SearchResults.Count, "Number of results on the page should match the number of results show in label.");

        }

        /// <summary>
        /// 7. Click on Page Number 2 of the pager.
        /// 8. Click on Page Number 3 of the pager.
        /// 9. Click on Page Number 4 of the pager.
        /// </summary>
        [Test, Order(2)]
        public void VerifySearchResultPagination()
        {
            var page2Link =_searchResultPage.ClickOnPaginationLink(2);
            Assert.IsTrue(_searchResultPage.AssertPaginationActive(page2Link),"Page 2 is active");

            var page3Link = _searchResultPage.ClickOnPaginationLink(3);
            Assert.IsTrue(_searchResultPage.AssertPaginationActive(page3Link), "Page 3 is active");

            var page4Link = _searchResultPage.ClickOnPaginationLink(4);
            Assert.IsTrue(_searchResultPage.AssertPaginationActive(page4Link), "Page 4 is active");
        }


        /// <summary>
        /// 10. Click on a random advert on this page.
        /// 11. The advert will open.
        /// 12. Click on Images button on advert.
        /// 13. Cycle through all available images by clicking the right slider.
        /// </summary>
        [Test, Order(3)]
        public void VerifyAdvertCarouselImagesOnRandomItem()
        {
            _searchResultPage.ClickOnRandomAdvert();

            var totalNumberOfImagesInCarousel = _advertDetailPage.TotalNumberOfImages;

            _advertDetailPage.SliderDetails.Click();

            for (var i = 0; i < totalNumberOfImagesInCarousel; i++)
            {
                _advertDetailPage.CarouselNextArrow.Click();
            }

        }


        [OneTimeTearDown]
        public void Teardown()
        {
            _driver.Quit();
        }
    }
}
