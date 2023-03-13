using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace CodingChallenge3.PublixBrowser
{
    /*
        This class represents the locators that will be used 
        to find elements on the various pages within this 
        namespace.

        The locators themselves are static as methods like
        webdriver.FindElement are static.
    */
    class PublixLocators
    {
        public static By searchInputBoxLocator = By.Id("global-search-input");
        public static By searchButtonLocator = By.ClassName("search-button");

        public static By shoppingListButtonLocator = By.LinkText("Shopping List");

        public static By shoppingListItemLocator = By.ClassName("title-wrapper");

        public static By shoppingListRemoveItem = By.CssSelector("span[class=\"trash\"]");
    }
}