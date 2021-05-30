using OpenQA.Selenium;
using System;

namespace swaglabs.PageObjects
{
    public class CheckoutCompletePage : BasePage
    {

        private  By headerCheckOutCompleteTitle = By.ClassName("title");
    private  By messageComplete = By.ClassName("complete-header");
    private  By logo = By.ClassName("pony_express");

        public CheckoutCompletePage(IWebDriver driver) :base(driver){ }

        public String getCheckoutCompleteTitle()
        {
            return driver.FindElement(headerCheckOutCompleteTitle).Text;
        }

        public String getMessageComplete()
        {
            return driver.FindElement(messageComplete).Text;
        }
        public Boolean isLogoDisplayed()
        {
            return driver.FindElement(logo).Displayed;
        }
    }
}
