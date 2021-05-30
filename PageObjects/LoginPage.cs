using System;
using OpenQA.Selenium;

namespace swaglabs.PageObjects
{
    public class LoginPage : BasePage
    {
        private By usernameInput = By.Id("user-name");
        private By passwordInput = By.Id("password");
        private By loginButton = By.Id("login-button");
        private By messageError = By.CssSelector("div[class='error-message-container error']");

        public LoginPage(IWebDriver driver) : base(driver)
        {
        }

        private void enterUsername(String username)
        {
            driver.FindElement(usernameInput).SendKeys(username);
        }

        private void enterPassword(String password)
        {
            driver.FindElement(passwordInput).SendKeys(password);
        }

        public void login(String username, String password)
        {
            enterUsername(username);
            enterPassword(password);
            driver.FindElement(loginButton).Click();
        }

        public String getErrorMessage()
        {
            return driver.FindElement(messageError).Text;
        }

        public Boolean isDisplayed()
        {
            return driver.FindElement(loginButton).Displayed;
        }
    }
}
