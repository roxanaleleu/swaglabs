using Microsoft.VisualStudio.TestTools.UnitTesting;
using swaglabs.PageObjects;
using System;

namespace swaglabs
{
    [TestClass]
    public class AddToCartTests : BaseTest
    {

        private static  String FIRSTNAME = "John";
    private static  String LASTNAME = "Mark";
    private static  String ZIPCODE = "12345";

    private static  String QTY_LABEL = "QTY";
    private static  String DESCRIPTION_LABEL = "DESCRIPTION";
    private static  String EXPECTED_QUANTITY = "1";

    private static  String CHECKOUT_YOUR_INFORMATION = "CHECKOUT: YOUR INFORMATION";
    private static  String CHECKOUT_OVERVIEW = "CHECKOUT: OVERVIEW";
    private static  String SAUCE_CARD_NUMBER = "SauceCard #31337";
    private static  String FREE_PONY_EXPRESS_DELIVERY = "FREE PONY EXPRESS DELIVERY!";

    private static  String CHECKOUT_COMPLETE = "CHECKOUT: COMPLETE!";
    private static  String THANK_YOU_FOR_YOUR_ORDER = "THANK YOU FOR YOUR ORDER";

    private ProductsPage productsPage;
        private CheckoutPage checkOutPage;
        private CartPage cartPage;
        private CheckoutOverviewPage checkoutOverviewPage;
        private CheckoutCompletePage checkoutCompletePage;

        [TestInitialize]
    public void beforeEachTest()
        {
            productsPage = new ProductsPage(driver);
            checkOutPage = new CheckoutPage(driver);
            cartPage = new CartPage(driver);
            checkoutOverviewPage = new CheckoutOverviewPage(driver);
            checkoutCompletePage = new CheckoutCompletePage(driver);
        }

        [TestMethod]
    public void shouldSuccessfullyOrderSingleProduct()
        {

            productsPage.addToCart();
            Assert.IsTrue(productsPage.isShoppingCartBadgeDisplayed());

            productsPage.goToCart();
            Assert.AreEqual(QTY_LABEL, cartPage.getQtyLabel());
            Assert.AreEqual(DESCRIPTION_LABEL, cartPage.getDescriptionLabel());
            Assert.AreEqual(EXPECTED_QUANTITY, cartPage.checkQuantity());
            Assert.AreEqual(productsPage.getProductName(), cartPage.getCartProductName());
            Assert.AreEqual(productsPage.getProductDescription(), cartPage.getCartProductDescription());
            Assert.AreEqual(productsPage.getProductPrice(), cartPage.getCartProductPrice());
  

            cartPage.checkOutProduct();
            Assert.AreEqual(CHECKOUT_YOUR_INFORMATION, checkOutPage.getPageHeaderTitle());

            checkOutPage.continueOrder(FIRSTNAME, LASTNAME, ZIPCODE);

            Assert.AreEqual(CHECKOUT_OVERVIEW, checkoutOverviewPage.getCheckoutOverviewTitle());
            Assert.AreEqual(SAUCE_CARD_NUMBER, checkoutOverviewPage.getPaymentInfo());
            Assert.AreEqual(FREE_PONY_EXPRESS_DELIVERY, checkoutOverviewPage.getShippingInfo());
            Assert.AreEqual(cartPage.getCartProductPrice(), checkoutOverviewPage.getPriceItem());

            checkOutPage.finishOrder();

            Assert.AreEqual(CHECKOUT_COMPLETE, checkoutCompletePage.getCheckoutCompleteTitle());
            Assert.AreEqual(THANK_YOU_FOR_YOUR_ORDER, checkoutCompletePage.getMessageComplete());
            Assert.IsTrue(checkoutCompletePage.isLogoDisplayed());

        }
    }
}
