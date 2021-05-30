using OpenQA.Selenium;
using System;

namespace swaglabs.PageObjects
{
    public class CartPage : BasePage
    {
        private  By checkOutButton = By.Id("checkout");
    private  By cartQuantity = By.CssSelector("#cart_contents_container > div > div.cart_list > div.cart_item > div.cart_quantity");
    private  By cartProductName = By.ClassName("inventory_item_name");
    private  By cartProductDescription = By.ClassName("inventory_item_desc");
    private  By cartQtyLabel = By.ClassName("cart_quantity_label");
    private  By cartDescriptionLabel = By.ClassName("cart_desc_label");
    private  By cartProductPrice = By.ClassName("inventory_item_price");

    public CartPage(IWebDriver driver) : base(driver) { }

        public void checkOutProduct()
        {
            driver.FindElement(checkOutButton).Click();
        }

        public String checkQuantity() { return driver.FindElement(cartQuantity).Text; }

        public String getQtyLabel()
        {
            return driver.FindElement(cartQtyLabel).Text;
        }

        public String getDescriptionLabel()
        {
            return driver.FindElement(cartDescriptionLabel).Text;
        }

        public String getCartProductDescription()
        {
            return driver.FindElement(cartProductDescription).Text;
        }

        public String getCartProductName()
        {
            return driver.FindElement(cartProductName).Text;
        }

        public String getCartProductPrice()
        {
            return driver.FindElement(cartProductPrice).Text;
        }
    }
}
