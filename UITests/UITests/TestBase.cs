using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UITests.Pages;

namespace UITests
{
    public class TestBase : IDisposable
    {
        private IWebDriver driver;
        private readonly string _url = "https://sso-dev.vectorworks.net/accounts/login/"; //The address needs to be in a separate file

        public TestBase()
        {
            if (driver == null)
            {
                driver = new ChromeDriver("./");
                driver.Manage().Window.Maximize();

            }
        }

        public LoginPage OpenSite()
        {
            driver.Navigate().GoToUrl(_url);

            return new LoginPage(driver);
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
