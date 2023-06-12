using System.ComponentModel;

namespace Scrapper.Enums
{
    public enum OdercoHtmlEnum
    {
        [Description("//*[@id=\"cnpj\"]")]
        UserNameXPath = 1,

        [Description("//*[@id=\"pass\"]")]
        UserPassXPath = 2,

        [Description("//*[@id=\"authorization-trigger\"]")]
        AccessLoginBtnXPath = 3,

        [Description("//*[@id=\"send2\"]")]
        SubmitLoginBtnXPath = 4,

        [Description("//*[@id=\"product-list-container\"]/div[5]/div[2]/ul/li[7]/a")]
        NextPageBtnXPath = 5,

        [Description("//*[@id=\"category-products-grid\"]/ol/li")]
        ProductMainElementXPath = 6,

        [Description("/div/div[1]/div/a")]
        ProductAElementXPath = 7
    }
}
