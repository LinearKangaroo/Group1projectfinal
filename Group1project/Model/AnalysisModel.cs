using System;

namespace Group1project.Model
{
    public enum AnalysisViewType
    {
        SKU = 0,
        SPU = 1
    }

    public enum AnalysisSortType
    {
        Sellout = 0,
        Stock = 1,
        DOS = 2,
        DemandStock = 3,
        Profit = 4
    }

    public enum TrendRange
    {
        Week = 0,
        Month = 1,
        Year = 2
    }

    public class AnalysisRowModel
    {
        public string Name { get; set; } = string.Empty;
        public int Sellout { get; set; }
        public int Stock { get; set; }
        public decimal DOS { get; set; }
        public decimal DemandStock { get; set; }
        public decimal Profit { get; set; }
    }

    public class SalesTrendPointModel
    {
        public DateTime Date { get; set; }
        public string Label { get; set; } = string.Empty;
        public int Quantity { get; set; }
    }
}
