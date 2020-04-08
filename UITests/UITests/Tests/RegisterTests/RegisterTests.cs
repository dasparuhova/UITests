using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Xunit;
using Assert = Xunit.Assert;

namespace UITests
{
    public class RegisterTests : TestBase
    {
        [Fact]
        public void User_Can_Create_Account_Only_With_Required_Fields() 
        {
            //the test TODO
            SsoApp.LoginPage.EnterAccountInfo();
        }
    }
}
