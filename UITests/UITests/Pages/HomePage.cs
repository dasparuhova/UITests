using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITests.Pages
{
    public class HomePage : TestBase
    {
        private WebDriverWait wait;

        public HomePage() 
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(60));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(ContentAccount));
        }
        #region Elements
        private By ContentAccount => By.ClassName("accounts-container");


        private IWebElement ContentAccountPage => driver.FindElement(ContentAccount);
        #endregion

        #region Assertion
        public bool IsContentAccountDisplayed()
        {
            return ContentAccountPage.Displayed;
        }

        public bool IsTextDisplayed(string text, string tag = "span")
        {
            if (string.IsNullOrEmpty(text)) return false;

            try
            {
                WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
                wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.TextToBePresentInElementLocated(By.XPath($"//{tag}[contains(text(), '" + text + "')]"), text));
                IWebElement webElement = driver.FindElement(By.XPath($"//{tag}[contains(text(), '" + text + "')]"));

                return webElement.Displayed;
            }
            catch (WebDriverTimeoutException e)
            {
                if (e.InnerException != null && e.InnerException is NoSuchElementException)
                {
                    return false;
                }
                throw e;
            }
        }


        #endregion
    }
}
