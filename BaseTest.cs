using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using swaglabs.PageObjects;
using System;

namespace swaglabs
{
    [TestClass]
    public class BaseTest
    {

        public static String APP_URL = "https://www.saucedemo.com/";
        private String username = "standard_user";
        private String password = "secret_sauce";

        public LoginPage loginPage;

        protected IWebDriver driver;

        [TestInitialize]
        public void beforeEachTestBase()
        {
            this.driver = new ChromeDriver();
            //maximize window
            driver.Manage().Window.Maximize();
            loginPage = new LoginPage(this.driver);

        this.navigateTo();
        loginPage.login(username, password);
        }

    private void navigateTo() { 
            driver.Navigate().GoToUrl(APP_URL);
    }

    [TestCleanup]
    public void afterEachTest()
    {
        driver.Quit();
    }
}
}
