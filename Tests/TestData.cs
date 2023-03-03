namespace CodingChallenge3.Tests;

public class TestData
{
   

    public static List<string> allPublixItems = new List<string>
        {_publixBread, _publixMilk, _publixEggs, _publixCheese};


    public static List<string> getAllPublixItems()
    {
        List<string> publixItems = new List<string>();
        publixItems.Append(_publixBread);
        publixItems.Append(_publixMilk);
        publixItems.Append(_publixEggs);
        publixItems.Append(_publixCheese);

        return publixItems;
    } 
}