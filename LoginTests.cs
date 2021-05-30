using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using swaglabs.PageObjects;
using System;

namespace swaglabs
{
    [TestClass]
    public class LoginTests
    {

    private static  String EXPECTED_ERROR_MESSAGE = "Epic sadface: Username and password do not match any user in this service";
    private static  String ASSERTION_LOGIN_ERROR_MESSAGE = "Incorrect/Missing error message when invalid user tries to login";
    private static  String EXPECTED_HEADER_TITLE = "PRODUCTS";
    private static  String ASSERTION_HEADER_ERROR_MESSAGE = "Page header title not equals";

    private String username = "standard_user";
        private String password = "secret_sauce";

        private LoginPage loginPage;
        private ProductsPage productsPage;
        IWebDriver driver = new ChromeDriver();

        [TestInitialize]
    public void beforeEachTest()
        {

            //maximize window
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseTest.APP_URL);
            loginPage = new LoginPage(driver);
            productsPage = new ProductsPage(driver);
        }

        [TestMethod]
    public void shouldSuccessfullyLogin()
        {
            loginPage.login(username, password);

            Assert.AreEqual(EXPECTED_HEADER_TITLE, productsPage.getPageHeaderTitle());
        }

        [TestMethod]
    public void shouldFailLoginWithInvalidUser()
        {
            String username = "Roxana";
            String password = "12345";

            loginPage.login(username, password);
            Assert.AreEqual(EXPECTED_ERROR_MESSAGE, loginPage.getErrorMessage());
        }

        [TestCleanup]
        public void afterEachTest()
        {
            driver.Quit();
        }
    }
}
