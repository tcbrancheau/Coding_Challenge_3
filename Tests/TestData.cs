namespace CodingChallenge3.Tests
{
    public class TestData
    {
    
        private static string _publixBread = "Publix Bread, Buttercrust";
        private static string _publixMilk = "Publix Milk, Fat Free";
        private static string _publixEggs = "Publix Eggs, Jumbo"; 
        private static string _publixCheese = "Publix Four Cheese Mexican Blend, Shredded Cheese";
        private static string _brandBread = "Nature's Own Bread, Enriched, Butterbread";
        private static string _brandMilk = "Horizon Organic Milk, Organic, Whole";
        private static string _brandEggs = "Happy Egg Co. Eggs, Heritage, Blue & Brown, Large"; 
        private static string _brandCheese = "Sargento Sliced Cheese, Aged Swiss";

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
}