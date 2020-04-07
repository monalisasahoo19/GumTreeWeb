using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace GumTreeSearchTest
{
    public class DriverFactory
    {
        static IWebDriver _driver;


        public DriverFactory()
        {
            if (_driver==null)
            {
                _driver = new ChromeDriver();
            }
        }

        public  IWebDriver GetDriver()
        {
            return _driver;
        }
    }
}
