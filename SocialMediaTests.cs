using Microsoft.VisualStudio.TestTools.UnitTesting;
using swaglabs.PageObjects;
using System;

namespace swaglabs
{
    [TestClass]
    public class SocialMediaTests : BaseTest
    {

        private ProductsPage productsPage;

        [TestInitialize]
    public void beforeEachTest()
        {
            productsPage = new ProductsPage(driver);
        }

        [TestMethod]
    public void shouldDisplayFacebookPage()
        {
            String facebookURL = "https://www.facebook.com/saucelabs";
            productsPage.navigateToSauceFacebookUrl();

            Assert.AreEqual(productsPage.getFacebookUrl(), facebookURL);
        }
    }
}
