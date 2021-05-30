using OpenQA.Selenium;
using System;

namespace swaglabs.PageObjects
{
    public class CheckoutOverviewPage : BasePage
    {
        private  By headerCheckOutOverviewTitle = By.ClassName("title");
    private  By paymentInfo = By.CssSelector("#checkout_summary_container > div > div.summary_info > div:nth-child(2)");
    private  By shippingInfo = By.CssSelector("#checkout_summary_container > div > div.summary_info > div:nth-child(4)");
    private  By priceItem = By.ClassName("inventory_item_price");

        public CheckoutOverviewPage(IWebDriver driver) : base(driver) { }

        public String getCheckoutOverviewTitle()
        {
            return driver.FindElement(headerCheckOutOverviewTitle).Text;
        }

        public String getPaymentInfo()
        {
            return driver.FindElement(paymentInfo).Text;
        }

        public String getShippingInfo()
        {
            return driver.FindElement(shippingInfo).Text;
        }

        public String getPriceItem()
        {
            return driver.FindElement(priceItem).Text;
        }
    }
}
