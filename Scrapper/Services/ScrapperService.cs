using OpenQA.Selenium;
using Scrapper.Entities;
using Scrapper.Enums;
using Scrapper.Utils;

namespace Scrapper.Services
{
    public interface IScrapperService
    {
        bool StartConnection();
        OdercoProductModel GetProduct();
        Task GetProductsAsync();
    }

    public class ScrapperService : IScrapperService
    {
        private readonly IWebDriver _driver;

        private static readonly string loginUrl = "https://www.oderco.com.br/customer/account/login/";
        private static readonly string collectiblesUrl = "https://www.oderco.com.br/colecionaveis.html";

        private static readonly string userName = "50.577.818/0001-40";
        private static readonly string userPass = "-nYGBuPYi4h.zks";

        private static readonly string odercoFunkoSufix = "COFUOD";
        private static readonly string odercoActionFigureSufix = "COACOD";

        private static readonly uint amountByPage = 32;
        private uint currentPage = 1;
        private uint currentProduct = 1;

        public ScrapperService(IWebDriver driver)
        {
            _driver = driver ?? throw new ArgumentNullException(nameof(driver)); ;
        }

        public bool StartConnection()
        {
            if (_driver == null)
                throw new NullReferenceException(nameof(_driver));

            try
            {
                _driver.Navigate().GoToUrl(loginUrl);

                Task.Delay(5000).Wait();

                var closeNotificationsBtn = _driver.FindElement(By.XPath(OdercoHtmlEnum.CloseNotificationsBtnXPath.GetDescription()));

                var accessLoginBtn = _driver.FindElement(By.XPath(OdercoHtmlEnum.AccessLoginBtnXPath.GetDescription()));

                var userNameInput = _driver.FindElement(By.XPath(OdercoHtmlEnum.UserNameXPath.GetDescription()));

                var userPassInput = _driver.FindElement(By.XPath(OdercoHtmlEnum.UserPassXPath.GetDescription()));

                var submitLoginBtn = _driver.FindElement(By.XPath(OdercoHtmlEnum.SubmitLoginBtnXPath.GetDescription()));

                if(accessLoginBtn == null || userNameInput == null || userPassInput == null || submitLoginBtn == null)
                    return false;

                closeNotificationsBtn.Click();

                accessLoginBtn.Click();

                userNameInput.SendKeys(userName);

                userPassInput.SendKeys(userPass);

                submitLoginBtn.Click();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: Can not stablish a connection with {loginUrl} | Details: {ex.Message}");
            }
        }

        public OdercoProductModel GetProduct()
        {
            _driver.Navigate().GoToUrl(collectiblesUrl);

            var productFullXPath = OdercoHtmlEnum.ProductMainElementXPath.GetDescription()
                        + $"[{1}]" + OdercoHtmlEnum.ProductAElementXPath.GetDescription();

            var productElement = _driver.FindElement(By.XPath(productFullXPath))
                ?? throw new Exception("Error trying to acess product category's element.");

            var productUrl = (productElement?.GetAttribute("href"))
                ?? throw new Exception("Error trying to acess product's url");

            _driver.Navigate().GoToUrl(productUrl);

            var product = GetProductDetails(productUrl);

            return product;
        }

        public async Task GetProductsAsync()
        {
            _driver.Navigate().GoToUrl(collectiblesUrl);

            var productsUrls = GetAllProductUrls();
         
            foreach(var productUrl in productsUrls)
            {
                Task.Delay(1000).Wait();
                _driver.Navigate().GoToUrl(productUrl);

                var currentProductDetails = GetProductDetails(productUrl);
            }
        }

        private List<string> GetAllProductUrls()
        {
            var productsUrls = new List<string>();

            try
            {
                while (true)
                {
                    var isThereANextPageBtn = false;

                    var currentPageNextPageBtn = GetNextPageButton();

                    if (currentPageNextPageBtn != null)
                        isThereANextPageBtn = true;

                    if (isThereANextPageBtn == false)
                        throw new Exception("No more pages were found.");

                    var currentProductsUrl = GetProductsUrlsFromCategoryPage();

                    if (currentProductsUrl.Count >= 1)
                        productsUrls.AddRange(currentProductsUrl);

                    currentPageNextPageBtn.Click();
                };
            }
            catch (Exception e)
            {
                if (!e.Message.Contains("No more pages were found."))
                    throw;
            }

            if (!(productsUrls.Count > 0))
                throw new Exception("Cannot get products urls.");

            return productsUrls;
        }

        private List<string> GetProductsUrlsFromCategoryPage()
        {
            var productsUrls = new List<string>();

            try
            {
                for (uint i = 1; i <= amountByPage; i++)
                {
                    currentProduct = i;

                    var currentProductFullXPath = OdercoHtmlEnum.ProductMainElementXPath.GetDescription()
                        + $"[{i}]" + OdercoHtmlEnum.ProductAElementXPath.GetDescription();

                    var currentProductElement = _driver.FindElement(By.XPath(currentProductFullXPath));

                    if (currentProductElement == null)
                        continue;

                    var currentProductUrl = currentProductElement?.GetAttribute("href");

                    if (string.IsNullOrWhiteSpace(currentProductUrl))
                        continue;

                    productsUrls.Add(currentProductUrl);
                }

                currentPage++;
            }
            catch (Exception)
            {
                Console.WriteLine($"Error trying to get product {currentProduct} from page {currentPage}.");
                return productsUrls;
            }
            return productsUrls;
        }

        private OdercoProductModel GetProductDetails(string productUrl = "")
        {
            var odercoProduct = new OdercoProductModel();

            if(!string.IsNullOrEmpty(productUrl))
                odercoProduct.Url = productUrl;

            var sku = _driver.FindElement(By.XPath(OdercoHtmlEnum.SkuProductDetailElementXPath.GetDescription()));

            if (sku != null)
                odercoProduct.Sku = sku.Text;

            var ean = _driver.FindElement(By.XPath(OdercoHtmlEnum.EanProductDetailElementXPath.GetDescription()));

            if(ean != null)
                odercoProduct.Ean = ean.Text;

            var title = _driver.FindElement(By.XPath(OdercoHtmlEnum.TitleProductDetailElementXPath.GetDescription()));

            if (title != null)
                odercoProduct.Title = title.Text;

            var weight = _driver.FindElement(By.XPath(OdercoHtmlEnum.WeightProductDetailElementXPath.GetDescription()));

            if (weight != null)
                odercoProduct.Weight = float.Parse(weight.Text);

            var height = _driver.FindElement(By.XPath(OdercoHtmlEnum.HeightProductDetailElementXPath.GetDescription()));
            if(height != null)
            {
                var heightOnlyNum = new string(height.Text.Where(char.IsDigit).ToArray());
                odercoProduct.Height = float.Parse(heightOnlyNum);
            }

            var width = _driver.FindElement(By.XPath(OdercoHtmlEnum.WidthProductDetailElementXPath.GetDescription()));
            if(width != null)
            {
                var widthOnlyNum = new string(width.Text.Where(char.IsDigit).ToArray());
                odercoProduct.Width = float.Parse(widthOnlyNum);
            }

            var length = _driver.FindElement(By.XPath(OdercoHtmlEnum.LengthProductDetailElementXPath.GetDescription()));
            if (length != null)
            {
                var lengthOnlyNum = new string(length.Text.Where(char.IsDigit).ToArray());
                odercoProduct.Length = float.Parse(lengthOnlyNum);
            }


            var costPrice = _driver.FindElement(By.XPath(OdercoHtmlEnum.CostPriceProductDetailElementXPath.GetDescription()));
            if (costPrice != null)
            {
                var cosPriceOnlyNum = new string(costPrice.Text.Where(char.IsDigit).ToArray());
                odercoProduct.CostPrice = float.Parse(cosPriceOnlyNum);
            }

            var brand = _driver.FindElement(By.XPath(OdercoHtmlEnum.BrandProductDetailElementXPath.GetDescription()));

            if (brand != null)
            {
                odercoProduct.Brand = brand.Text;

                if (brand.Text.Contains("FUNKO"))
                    odercoProduct.Category = "Funko";
            }

            if (string.IsNullOrEmpty(odercoProduct.Category))
                odercoProduct.Category = "Action Figure";

            return odercoProduct;
        }

        private IWebElement GetNextPageButton()
        {
            return _driver.FindElement(By.XPath(OdercoHtmlEnum.NextPageBtnXPath.GetDescription()));
        }
    }
}
