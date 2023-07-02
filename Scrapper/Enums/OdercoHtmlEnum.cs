using System.ComponentModel;

namespace Scrapper.Enums
{
    public enum OdercoHtmlEnum
    {
        #region LOGIN
        [Description("//*[@id=\"onesignal-slidedown-cancel-button\"]")]
        CloseNotificationsBtnXPath = 0,

        [Description("//*[@id=\"cnpj\"]")]
        UserNameXPath = 1,

        [Description("//*[@id=\"pass\"]")]
        UserPassXPath = 2,

        [Description("//*[@id=\"authorization-trigger\"]")]
        AccessLoginBtnXPath = 3,

        [Description("//*[@id=\"send2\"]")]
        SubmitLoginBtnXPath = 4,
        #endregion

        #region CURRENT PRODUCT FROM CATEGORY PAGE
        [Description("//*[@id=\"product-list-container\"]/div[5]/div[2]/ul/li[7]/a")]
        NextPageBtnXPath = 5,

        [Description("//*[@id=\"category-products-grid\"]/ol/li")]
        ProductMainElementXPath = 6,

        [Description("/div/div[1]/div/a")]
        ProductAElementXPath = 7,
        #endregion

        #region PRODUCT DETAILS
        [Description("//*[@id=\"maincontent\"]/div[3]/div/div[1]/div[2]/div[1]/div/div")]
        SkuProductDetailElementXPath = 8,

        [Description("/html/body/div[1]/main/div[3]/div/div[3]/div[2]/div/div/div[2]/div/table/tbody/tr[8]/td")]
        EanProductDetailElementXPath = 9,

        [Description("/html/body/div[1]/main/div[3]/div/div[3]/div[2]/div/div/div[2]/div/table/tbody/tr[1]/td")]
        BrandProductDetailElementXPath = 10,

        [Description("/html/body/div[1]/main/div[3]/div/div[1]/div[2]/div[1]/h1/span")]
        TitleProductDetailElementXPath = 11,

        [Description("/html/body/div[1]/main/div[3]/div/div[3]/div[2]/div/div/div[2]/div/table/tbody/tr[2]/td")]
        WeightProductDetailElementXPath = 12,

        [Description("/html/body/div[1]/main/div[3]/div/div[3]/div[2]/div/div/div[2]/div/table/tbody/tr[6]/td")]
        HeightProductDetailElementXPath = 13,

        [Description("/html/body/div[1]/main/div[3]/div/div[3]/div[2]/div/div/div[2]/div/table/tbody/tr[5]/td")]
        WidthProductDetailElementXPath = 14,

        [Description("/html/body/div[1]/main/div[3]/div/div[3]/div[2]/div/div/div[2]/div/table/tbody/tr[7]/td")]
        LengthProductDetailElementXPath = 15,

        [Description("/html/body/div[1]/main/div[3]/div/div[1]/div[2]/div[3]/div/span/span/span")]
        CostPriceProductDetailElementXPath = 16
        #endregion
    }
}
