using NUnit.Framework;
using CodingChallenge3.PublixBrowser;
using OpenQA.Selenium;

namespace CodingChallenge3.Tests
{

    [TestFixture]
    public class ShoppingListTests
    {
        private PublixBrowser.PublixBrowser _pBroswer;

        private static string _publixBread = "Publix Bread, Buttercrust";
        private static string _publixMilk = "Publix Milk, Fat Free";
        private static string _publixEggs = "Publix Eggs, Jumbo"; 
        private static string _publixCheese = "Publix Four Cheese Mexican Blend, Shredded Cheese";
        private static string _brandBread = "Nature's Own Bread, Enriched, Butterbread";
        private static string _brandMilk = "Horizon Organic Milk, Organic, Whole";
        private static string _brandEggs = "Happy Egg Co. Eggs, Heritage, Blue & Brown, Large"; 
        private static string _brandCheese = "Sargento Sliced Cheese, Aged Swiss";

        static IEnumerable<string[]> ProductLists()
        {
            // all public items
            yield return new string[] {_publixBread, _publixMilk, _publixEggs, _publixCheese};
            
            // all brand name items
            yield return new string[] {_brandBread, _brandMilk, _brandEggs, _brandCheese};
            
            // mix of publix and brand name items
            yield return new string[] {_publixBread, _brandMilk, _publixEggs, _brandCheese};

        }

        public ShoppingListTests()
        {
            _pBroswer = new PublixBrowser.PublixBrowser();
        }

        [OneTimeSetUp]
        public void ClassSetup()
        {
            _pBroswer.openPublixSite();   
        }

        [SetUp]
        public void TestSetup()
        {
            _pBroswer.openPublixSite();
            PublixBrowser.PublixShoppingList shoppingListPage = new PublixBrowser.PublixShoppingList(_pBroswer); 
            shoppingListPage.clearShoppingList();
        }

        [OneTimeTearDown]
        public void ClassTearDown()
        {
            _pBroswer.closePublixSite();
        }

        // [TearDown]
        // public void TestTearDown()
        // {

        // }

        //[TestCase(params = , TestName="All Publix Items")]
        //[TestCase(new object[] {_publixBread, _publixMilk, _publixEggs, _publixCheese}, TestName="Something")]
        [TestCaseSource(nameof(ProductLists))]
        public void TestAddItemsToShoppingList(string[] storeItems)
        {
            PublixBrowser.PublixSearch pSearch = new PublixBrowser.PublixSearch(_pBroswer);
            PublixBrowser.PublixShoppingList pShopList = new PublixBrowser.PublixShoppingList(_pBroswer);

            foreach(string product in storeItems)
            {
                pSearch.clickSearchButton();
                pSearch.enterSearchTerm(product);
                pSearch.clickSearchButton();

                pSearch.addProductToShoppingList(product);
            }

            bool productsFound = true;

            pShopList.clickShoppingList();

            foreach(string product in storeItems)
            {
                if (productsFound)
                {
                    IWebElement listItem = pShopList.findShoppingListItem(product);
                    if (listItem == null)
                    {
                        productsFound = false;
                        Console.WriteLine("Did not find {product} in the shopping list.")
                    }
                }
            }

            if (productsFound)
            {
                Assert.Pass();
            }
            else
            {
                Assert.Fail();
            }
        }
    }
}