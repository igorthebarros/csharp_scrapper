namespace Scrapper.Entities
{
    public class OdercoProductModel
    {
        public string Sku { get; set; } = string.Empty;
        public string Ean { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Title { get; set; } = string.Empty;   
        public string Url { get; set; } = string.Empty;
        public static string Distribuitor => "Oderço";

        public float Weight { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }
        public float Length { get; set; }

        public float CostPrice { get; set; }

    }
}
