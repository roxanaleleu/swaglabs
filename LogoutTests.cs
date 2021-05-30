using Microsoft.VisualStudio.TestTools.UnitTesting;
using swaglabs.PageObjects;

namespace swaglabs
{
    [TestClass]
    public class LogoutTests : BaseTest
    {

        private ProductsPage productsPage;

        [TestInitialize]
    public void beforeEachTest()
        {
            productsPage = new ProductsPage(driver);
        }

        [TestMethod]
    public void shouldSuccessfullyLogout()
        {
            productsPage.openBurgerMenu();
            productsPage.waitUntilLogoutButtonIsPresent();
            productsPage.logout();

            Assert.IsTrue(loginPage.isDisplayed());
        }
    }
}
