using OpenQA.Selenium;
using System;

namespace swaglabs.PageObjects
{
    public class CheckoutPage : BasePage
    {

        private  By headerCheckOutTitle = By.CssSelector("div[class='header_secondary_container'] span[class='title']");
    private  By firstnameInput = By.Id("first-name");
    private  By lastnameInput = By.Id("last-name");
    private  By zipInput = By.Id("postal-code");
    private  By continueButton = By.Id("continue");
    private  By finishButton = By.Id("finish");

        public CheckoutPage(IWebDriver driver) : base(driver) { }

        public void enterFirstname(String firstname)
        {
            driver.FindElement(firstnameInput).SendKeys(firstname);
        }

        public void enterLastname(String lastname)
        {
            driver.FindElement(lastnameInput).SendKeys(lastname);
        }

        public void enterZipCode(String zipcode)
        {
            driver.FindElement(zipInput).SendKeys(zipcode);
        }

        public void continueOrder(String firstname, String lastname, String zipcode)
        {
            enterFirstname(firstname);
            enterLastname(lastname);
            enterZipCode(zipcode);
            driver.FindElement(continueButton).Click();
        }

        public String getPageHeaderTitle()
        {
            return driver.FindElement(headerCheckOutTitle).Text;
        }

        public void finishOrder()
        {
            driver.FindElement(finishButton).Click();
        }
    }
}
