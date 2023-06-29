using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Scrapper.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Scrapper is running!");

        try
        {
            var driver = new ChromeDriver();
            var scrapper = new ScrapperService(driver);

            var isConnected = scrapper.StartConnection();

            if (!isConnected)
                throw new Exception("Can't reach the website.");

            Console.WriteLine($"Connected: {isConnected}");

            //var currentProductsUrl = scrapper.GetProductsUrls();

            //var productsUrls = new List<string>();

            //if (currentProductsUrl.Count >= 1)
            //    productsUrls.AddRange(currentProductsUrl);

            //var nextPageBtn = scrapper.GetNextPageButton();

            //if(nextPageBtn != null)
            //    nextPageBtn.Click();
            //else
            //{
            //    //Call GetDetails
            //}
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //Console.ReadKey();
        }
    }
}