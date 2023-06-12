using Moq;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Scrapper.Services;

namespace Tests.Services
{
    [TestClass]
    public class ScrapperServiceTest
    {
        private IScrapperService _scrapperService;
        private Mock<ChromeDriver> _driver;

        public ScrapperServiceTest()
        {
            _driver = new Mock<ChromeDriver>();
            //Arrange
            _driver.
                Setup(x => x.Navigate().GoToUrl(It.IsAny<string>()));

            _driver.
                Setup(x => x.FindElement(By.XPath(It.IsAny<string>())))
                .Returns(new WebElement(_driver.Object, string.Empty));

            //Act
            var result = _scrapperService.StartConnection();

            //Assert
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void StartConnection_Return_False()
        {
            //Arrange
            
            //Act
            var result = _scrapperService.StartConnection();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void StartConnection_Throw_NullReferenceException()
        {
            //Arrange
            _scrapperService = new ScrapperService(null);

            //Act
            var result = _scrapperService.StartConnection();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void GetProductsUrls_Return_List()
        {

        }
    }
}
