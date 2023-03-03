using OpenQA.Selenium;

namespace CodingChallenge3.PublixBrowser;

/*
    The PublixSearch class represents searching on the Publix website
    and the search results.
*/
class PublixSearch
{
    private PublixBrowser _pBroswer;

    /*
        Constructor for the PublixSearch class
        Parameters:
            PbulixBrowser pBroswer: object that represents the browser

    */
    public PublixSearch(PublixBrowser pBrowser)
    {
        _pBroswer = pBrowser;
    }

    /*
        Method to enter a search term in the search input box
        Parameters:
            string searchTerm: string to search for on the website
    */
    public void enterSearchTerm(string searchTerm)
    {   
        try
        {
            var searchBoxElement = _pBroswer.findWebElement(
                PublixLocators.searchInputBoxLocator
            );
            
            if (searchBoxElement.Displayed)
                searchBoxElement.SendKeys(searchTerm);
        }
        catch (NoSuchElementException nsee)
        {
            _pBroswer.logError(nsee.ToString());
        }
    }

    public void clickSearchButton()
    {
        try
        {
            var searchButton = _pBroswer.findWebElement(
                PublixLocators.searchButtonLocator
            );

            if (searchButton.Displayed)
                searchButton.Click();
        }
        catch (NoSuchElementException nsee)
        {
            _pBroswer.logError(nsee.ToString());
        }
    }

    public void addProductToShoppingList(string productName)
    {
        WebDriver webDriver = _pBroswer.publixDriver;
        IWebElement addButton = webDriver.FindElement(
            RelativeBy.WithLocator(By.LinkText(productName)).Below(
                By.ClassName("p-button")
            )
        );

        if (addButton.Displayed)
            addButton.Click();
    }

}