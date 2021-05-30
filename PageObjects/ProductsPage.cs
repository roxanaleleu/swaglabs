using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace swaglabs.PageObjects
{
    public class ProductsPage : BasePage
    {

        private  By headerTitle = By.CssSelector("div[class='header_secondary_container'] span[class='title']");
  private  By addToCartButton = By.Id("add-to-cart-sauce-labs-backpack");
  private  By goToCartButton = By.Id("shopping_cart_container");
  private  By shoppingCartBadge = By.CssSelector("#shopping_cart_container > a > span");
  private  By productDescription = By.ClassName("inventory_item_desc");
  private  By productPrice = By.ClassName("inventory_item_price");
  private  By dropDown = By.ClassName("product_sort_container");
  private  By facebookLocationButton = By.CssSelector("#page_wrapper > footer > ul > li.social_facebook");
  private  By burgerButton = By.Id("react-burger-menu-btn");
  private  By logoutButton = By.Id("logout_sidebar_link");
  private  By productsName = By.ClassName("inventory_item_name");
  private  By productsPrice = By.ClassName("inventory_item_price");
  private  By facebookLinkButton = By.CssSelector("#page_wrapper > footer > ul > li.social_facebook");

  private int secondTab = 1;

        public ProductsPage(IWebDriver driver) : base(driver) { }

        public String getPageHeaderTitle()
        {
            return driver.FindElement(headerTitle).Text;
        }

        public void addToCart()
        {
            driver.FindElement(addToCartButton).Click();
        }

        public String getProductName()
        {
            return driver.FindElement(productsName).Text;
        }

        public String getProductDescription()
        {
            return driver.FindElement(productDescription).Text;
        }

        public String getProductPrice()
        {
            return driver.FindElement(productPrice).Text;
        }

        public void goToCart()
        {
            driver.FindElement(goToCartButton).Click();
        }

        public Boolean isShoppingCartBadgeDisplayed()
        {
            return driver.FindElement(shoppingCartBadge).Displayed;
        }

        public void openDropDrown()
        {
            driver.FindElement(dropDown).Click();
        }

        private IWebElement getDropDown()
        {
            return driver.FindElement(dropDown);
        }

        public void selectValueFromDropDown(String typeOfSorting)
        {
            SelectElement sortValue = new SelectElement(getDropDown());
            sortValue.SelectByValue(typeOfSorting);
        }

        public ICollection<String> addOptionNameToList()
        {
            ICollection<IWebElement> optionValues = driver.FindElements(productsName);
            List<String> names = new List<String>();

            foreach (IWebElement currentOptionValue in optionValues)
            {
                names.Add(currentOptionValue.Text);
            }
            return names;
        }

        public List<String> sortNames(List<String> names)
        {
            names.Sort();
            names.Reverse();
            return names;
        }

        public List<Double> addOptionPriceToList()
        {
            ICollection<IWebElement> optionValue = driver.FindElements(productsPrice);
            List<Double> prices = new List<Double>();

            foreach (IWebElement webElement in optionValue)
            {
                double number = Double.Parse(webElement.Text.Replace("$", ""));
                prices.Add(number);
            }
            return prices;
        }

        public List<Double> sortPrices(List<Double> sortedPrice)
        {
            sortedPrice.Sort();
            sortedPrice.Reverse();
            return sortedPrice;
        }

        public void navigateToSauceFacebookUrl()
        {
            driver.FindElement(facebookLinkButton).Click();
        }

        public String getFacebookUrl()
        {
            String[] tabs = driver.WindowHandles.ToArray();
            driver.SwitchTo().Window(tabs[secondTab]);
            new WebDriverWait(driver, TimeSpan.FromSeconds(2)).Until(ExpectedConditions.UrlContains("https://www.facebook.com/saucelabs"));
            return driver.Url;
        }

        public void openBurgerMenu()
        {
            driver.FindElement(burgerButton).Click();
        }

        public IWebElement waitUntilLogoutButtonIsPresent()
        {
            IWebElement logoutElement = driver.FindElement(logoutButton);
            return new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(ExpectedConditions.ElementToBeClickable(logoutElement));
        }

        public void logout()
        {
            driver.FindElement(logoutButton).Click();
        }
    }
}
