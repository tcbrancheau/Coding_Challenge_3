namespace CodingChallenge3;


using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;

public class Starter {
    public static void Main() {
        var myDriver = new ChromeDriver();
        myDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromMilliseconds(500);

        myDriver.Navigate().GoToUrl("https://publix.com");

        Thread.Sleep(8000);

        myDriver.Quit();
    }
}








