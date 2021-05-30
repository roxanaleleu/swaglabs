using Microsoft.VisualStudio.TestTools.UnitTesting;
using swaglabs.PageObjects;
using System;
using System.Collections.Generic;

namespace swaglabs
{
    [TestClass]
    public class FilterTests : BaseTest
    {

        private ProductsPage productsPage;

        [TestInitialize]
    public void beforeEachTest()
        {
            productsPage = new ProductsPage(driver);
        }

        [TestMethod]
    public void should_ProductNamesBeOnDescendingOrder_OnZAOption()
        {
            String typeOfSorting = "za";
            List<String> namesOfProducts = new List<String>() { "Sauce Labs Backpack", "Sauce Labs Bike Light", "Sauce Labs Bolt T-Shirt", "Sauce Labs Fleece Jacket", "Sauce Labs Onesie", "Test.allTheThings() T-Shirt (Red)" };

            productsPage.openDropDrown();
            productsPage.selectValueFromDropDown(typeOfSorting);
            productsPage.addOptionNameToList();
            productsPage.sortNames(namesOfProducts);


            Assert.IsTrue(productsPage.sortNames(namesOfProducts).Count > 0);
            CollectionAssert.AreEqual((System.Collections.ICollection)productsPage.addOptionNameToList(), productsPage.sortNames(namesOfProducts));
        }

        [TestMethod]
    public void should_BeDescendingPrices_OnHiLoOption()
        {
            String type_of_sorting = "hilo";
            List<Double> pricesOfProducts = new List<Double>() { 49.99, 29.99, 9.99, 15.99, 7.99, 15.99 };

            productsPage.openDropDrown();
            productsPage.selectValueFromDropDown(type_of_sorting);
            productsPage.addOptionPriceToList();
            productsPage.sortPrices(pricesOfProducts);


            Assert.IsTrue(productsPage.addOptionPriceToList().Count > 0);
            CollectionAssert.AreEqual(productsPage.addOptionPriceToList(), productsPage.sortPrices(pricesOfProducts));

        }
    }
}
