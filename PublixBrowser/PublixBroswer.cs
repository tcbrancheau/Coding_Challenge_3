using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Text.Json;

namespace CodingChallenge3.PublixBrowser;

public class PublixBrowser
{
    private bool _useDebugMessages = false;
    private ChromeDriver _publixDriver;

    public PublixBrowser()
    {
        Dictionary<string, object> geolocationParams = new Dictionary<string, object>();
        geolocationParams.Add("origin", "https://publix.com");
        geolocationParams.Add("permissions", new List<string> () {"geolocation"});

        _publixDriver = new ChromeDriver();
        _publixDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(GlobalVars.webTimeout);
        _publixDriver.ExecuteCdpCommand("Browser.grantPermissions", geolocationParams);

    //     driver.execute_cdp_cmd(
    // "Browser.grantPermissions",
    // {
    //     "origin": "https://www.openstreetmap.org/",
    //     "permissions": ["geolocation"]
    // },
//)


    } 

    public bool setDebug
    {
        set {_useDebugMessages = value;}
    }
    public WebDriver publixDriver 
    {
        get { return _publixDriver; }
    }

    public void openPublixSite()
    {
        _publixDriver.Navigate().GoToUrl(GlobalVars.PublixURL);
    }    

    public void closePublixSite()
    {
        _publixDriver.Quit();
    }

    public IWebElement findWebElement(By elementLocator)
    {
        return _publixDriver.FindElement(elementLocator);
    }

    public List<IWebElement> findWebElements(By elementLocator)
    {
        return _publixDriver.FindElements(elementLocator).ToList();
    }

    /*
        This method simply logs a message to the Console.  It could 
        be re-written to send a message to a file or to any other
        log type one might want to use (such as windows event log)
        Parameters:
            string msg:  message to output to the log
    */
    public void logMessage(string msg)
    {
        Console.WriteLine(msg);
    }

    /*
        This method logs an error message to the Console.  This is 
        accomplished by adding ERROR to the beginning of the string 
        that is printed to the console.  It could be re-written to 
        send a message to a file or to any other log type one might 
        want to use (such as windows event log)
        Parameters:
            string msg:  error message to output to the log
    */
    public void logError(string msg)
    {
        Console.WriteLine("ERROR:  {msg}");
    }

    /*
        This method logs a debug message to the Console.  This is 
        accomplished by adding DEBUG to the beginning of the string 
        that is printed to the console.  This method only prints the
        debug message if 
        
        It could be re-written to 
        send a message to a file or to any other log type one might 
        want to use (such as windows event log)
        Parameters:
            string msg:  debug message to output to the log
    */
    public void logDebug(string msg)
    {
        if (_useDebugMessages)
            Console.WriteLine("DEBUG:  {msg}");
    }

}
