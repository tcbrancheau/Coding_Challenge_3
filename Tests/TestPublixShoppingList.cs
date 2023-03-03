using NUnit;
using CodingChallenge3.PublixBrowser;

namespace CodingChallenge3.Tests;

[TestFixture]
public class ShoppingListTests
{
    private PublixBrowser _pBroswer;

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
        yield return new string[] {_publixBread, _publixMilk, _publixEggs, _publixCheese};
        yield return new string[] {_brandBread, _brandMilk, _brandEggs, _brandCheese};
        yield return new string[] {_publixBread, _brandMilk, _publixEggs, _brandCheese};

    }

    public ShoppingListTests()
    {
        _pBroswer = new PublixBrowser();
    }

    [SetUp]
    public void Setup()
    {
    }

    //[TestCase(params = , TestName="All Publix Items")]
    //[TestCase(new object[] {_publixBread, _publixMilk, _publixEggs, _publixCheese}, TestName="Something")]
    [TestCaseSource(nameof(ProductLists))]
    public void TestAddItemsToShoppingList(string[] storeItems)
    {
        PublixSearch pSearch = new PublixSearch(_pBroswer);
        PublixShoppingList pShopList = new PublixShoppingList(_pBroswer);

        Assert.Pass();
    }
}