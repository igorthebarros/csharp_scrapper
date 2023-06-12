using OpenQA.Selenium;
using Scrapper.Enums;
using Scrapper.Utils;

namespace Scrapper.Services
{
    public interface IScrapperService
    {
        bool StartConnection();
        List<string> GetProductsUrls();
        void GetProductsDetails();
        IWebElement GetNextPageButton();
    }

    public class ScrapperService : IScrapperService
    {
        private readonly IWebDriver _driver;
        private static readonly string _loginUrl = "https://www.oderco.com.br/";
        private static readonly string _collectiblesUrl = "https://www.oderco.com.br/colecionaveis.html";
        private static readonly string _userName = "50.577.818/0001-40";
        private static readonly string _userPass = "-nYGBuPYi4h.zks";
        private static readonly uint _amountByPage = 32;

        private uint currentPage = 1;
        private uint currentProduct = 1;

        public ScrapperService(IWebDriver driver)
        {
            _driver = driver;
        }

        public bool StartConnection()
        {
            if (_driver == null)
                throw new NullReferenceException(nameof(_driver));

            try
            {
                _driver.Navigate().GoToUrl(_loginUrl);

                var accessLoginBtn = _driver.FindElement(By.XPath(OdercoHtmlEnum.AccessLoginBtnXPath.GetDescription()));

                var userNameInput = _driver.FindElement(By.XPath(OdercoHtmlEnum.UserNameXPath.GetDescription()));

                var userPassInput = _driver.FindElement(By.XPath(OdercoHtmlEnum.UserPassXPath.GetDescription()));

                var submitLoginBtn = _driver.FindElement(By.XPath(OdercoHtmlEnum.SubmitLoginBtnXPath.GetDescription()));

                if(accessLoginBtn == null || userNameInput == null || userPassInput == null || submitLoginBtn == null)
                    return false;

                accessLoginBtn.Click();

                userNameInput.SendKeys(_userName);

                userPassInput.SendKeys(_userPass);

                submitLoginBtn.Click();

                return true;
            }
            catch (Exception ex)
            {
                throw new Exception($"Error: Can not access stablish connection with {_loginUrl} - {ex.Message}");
            }
        }

        public List<string> GetProductsUrls()
        {
            _driver.Navigate().GoToUrl(_collectiblesUrl);

            var productsUrls = new List<string>();

            try
            {
                for (uint i = 1; i <= _amountByPage; i++)
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

        public void GetProductsDetails()
        {
            throw new NotImplementedException();
        }

        public IWebElement GetNextPageButton()
        {
            return _driver.FindElement(By.XPath(OdercoHtmlEnum.NextPageBtnXPath.GetDescription()));
        }
    }
}
