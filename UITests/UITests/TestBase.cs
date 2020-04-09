using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests
{
    public class TestBase : IDisposable
    {
        protected static IWebDriver driver;
        private readonly string _url = "https://sso-dev.vectorworks.net/accounts/login/"; //The address needs to be in a separate file

        public TestBase()
        {
            if (driver == null)
            {
                driver = new ChromeDriver("./");
                driver.Manage().Window.Maximize();
                driver.Navigate().GoToUrl(_url);
            }
        }

        public void Dispose()
        {
            driver.Quit();
        }

        //Refresh the page
        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }
    }
}
