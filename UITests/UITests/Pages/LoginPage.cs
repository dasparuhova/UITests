using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;

namespace UITests.Pages
{
    public class LoginPage : TestBase
    {
        private WebDriverWait wait;

        public LoginPage()  : base()
        {
            this.wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(LogInMenu));
        }

        #region RegisterMenu Locators and elements
        private By LogInMenu => By.Id("log-in-menu");
        private By UserName => By.Name("login");
        private By Password => By.XPath("//input[contains(@name, 'password') and @placeholder='Create a password']"); //It's not the best xpath, but it's hard to locate this one
        private By ConfirmPassword => By.XPath("//input[contains(@name, 'password') and @placeholder='Confirm your password']"); 
        private By Email => By.XPath("//input[contains(@name, 'email') and @placeholder='Email address']");
        private By PhoneNumber => By.Id("phone");
        private By FirstName => By.Name("first_name");
        private By LastName => By.Name("last_name");
        private By CreateAccount => By.XPath("//button[contains(text(), 'Create account')]");
        private By UserLoginForm => By.ClassName("user-login-menu");
        private By LoginForm => By.ClassName("nav-header btn-link");

        private IWebElement UserNameInput => driver.FindElement(UserName);
        private IWebElement PasswordInput => driver.FindElement(Password);
        private IWebElement ConfirmPasswordIntut => driver.FindElement(ConfirmPassword); //It's not the best xpath, but it's hard to locate this one
        private IWebElement EmailInput => driver.FindElement(Email);
        private IWebElement PhoneNumberInput => driver.FindElement(PhoneNumber);
        private IWebElement FirstNameInput => driver.FindElement(FirstName);
        private IWebElement LastNameInput => driver.FindElement(LastName);
        private IWebElement CreateAccountButton => driver.FindElement(CreateAccount);

        private IWebElement RegisterMenuCollapsed => driver.FindElement(By.XPath("//*[contains(@class, 'nav-header collapsed btn-link')]"));

        private IWebElement LoginFormElement => driver.FindElement(LoginForm);

        #endregion

        #region Iteractions in the page 

        /// <summary>
        /// Fill register account fields
        /// </summary>
        public void EnterAccountInfo(string userName, string password, string confirmPassword, string email, string name, string lastName, string phone = null)
        {
            RegisterMenuCollapsed.Click();

            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(UserName));

            if (userName != null)
            {
                UserNameInput.Click();
                UserNameInput.SendKeys(userName);
            }
            if (password != null)
            {
                PasswordInput.Click();
                PasswordInput.SendKeys(password);
            }
            if (confirmPassword != null)
            {
                ConfirmPasswordIntut.Click();
                ConfirmPasswordIntut.SendKeys(confirmPassword);
            }
            if (email != null)
            {
                EmailInput.Click();
                EmailInput.SendKeys(email);
            }

            if (name != null)
            {
                FirstNameInput.Click();
                FirstNameInput.SendKeys(confirmPassword);
            }

            if (lastName != null)
            {
                LastNameInput.Click();
                LastNameInput.SendKeys(confirmPassword);
            }
            if (phone != null)
            {
                PhoneNumberInput.Click();
                ConfirmPasswordIntut.SendKeys(confirmPassword);
            }
        }

        /// <summary>
        /// Enter email in order to check validation of the email
        /// </summary>
        public void EnterEmail(string email)
        {
            EmailInput.Click();
            EmailInput.Clear();             
            EmailInput.SendKeys(email);
        }

        
        public void ClickCreateAccountButton() => CreateAccountButton.Click();

        //Find all element according to the criteria on the page
        public int GetElementsCount(string text, string tag = "span")
        { 
            var count = driver.FindElements(By.XPath($"//{tag}[contains(text(), '" + text + "')]"));
            return count.Count;
        }

        public void PressEnterToCheckEmailValidationMessage()
        {
            EmailInput.SendKeys(Keys.Enter);
            Thread.Sleep(1000);
        }
        #endregion

        #region Assertions
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
