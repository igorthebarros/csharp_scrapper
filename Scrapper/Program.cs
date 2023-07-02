using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Scrapper.Services;
using System.Threading;

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

            var productTest = scrapper.GetProduct();

            //var productsTask = Task.Run(() => scrapper.GetProductsAsync());

            //productsTask.Wait();

            //var consumerTask = Task.Run(() => consumerService.ExecuteAsync_Public(cancellationToken));

            //await Task.Delay(10000);// Wait for a short time to allow the consumer service to start and enter the while loop

            //cancellationTokenSource.Cancel();

            ////Act
            //await consumerTask;
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            //Console.ReadKey();
        }
    }
}