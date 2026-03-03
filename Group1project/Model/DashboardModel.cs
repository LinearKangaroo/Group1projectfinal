using System;

namespace Group1project.Model
{
    public class DailySalesPointModel
    {
        public DateTime Date { get; set; }
        public int Quantity { get; set; }
    }

    public class BrandSalesRatioModel
    {
        public string Brand { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
