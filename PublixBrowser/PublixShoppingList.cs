using OpenQA.Selenium;

namespace CodingChallenge3.PublixBrowser
{
    /*
        The PublixShoppingList class represents interacting 
        with the shopping list on the Publix website.
    */
    public class PublixShoppingList
    {
        private PublixBrowser _pBroswer;

        /*
            Constructor for the PublixShoppingList class
            Parameters:
                PbulixBrowser pBroswer: object that represents the browser

        */
        public PublixShoppingList(PublixBrowser pBrowser)
        {
            _pBroswer = pBrowser;
        }

    public void clickShoppingList()
        {
            IWebElement shoppingListButton = _pBroswer.findWebElement(PublixLocators.shoppingListButtonLocator);
            if (shoppingListButton.Displayed)
                shoppingListButton.Click();
        }

        public IWebElement findShoppingListItem(string itemName)
        {
            this.clickShoppingList();
            IWebElement foundItem = _pBroswer.findWebElement(By.CssSelector("span[has-text={itemName}]"));
            if (foundItem.Displayed)
            {
                return foundItem;
            }

            return null;
        }

        public List<IWebElement> getShoppingListItems()
        {
            List<IWebElement> listItems = _pBroswer.findWebElements(PublixLocators.shoppingListItemLocator);
            
            return listItems;
        }

        public string[] getShoppingListItemNames()
        {
            string[] itemNames = {};
            List<IWebElement> listItems = this.getShoppingListItems();
            foreach (IWebElement item in listItems)
            {
                itemNames.Append(item.Text);
            }
            return itemNames;
        }

        public void clearShoppingList()
        {
            this.clickShoppingList();
            List<IWebElement> listItems = this.getShoppingListItems();

            foreach (IWebElement item in listItems)
            {
                IWebElement removeButton = item.FindElement(PublixLocators.shoppingListRemoveItem);
                try
                {
                    removeButton.Click();
                }
                catch (NoSuchElementException nsee)
                {
                    Console.WriteLine("NoSuchElementException caught:\n" + nsee.Message);
                }
            }
        }
    }
}