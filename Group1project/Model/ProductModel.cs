using System;

namespace Group1project.Model
{
    public class ProductModel
    {
        public string SKUcode { get; set; }
        public string SPUcode { get; set; }
        public string SPUname { get; set; }
        public string brand { get; set; }
        public string SKUspec { get; set; }
        public string SKUname { get; set; }
        public decimal purchase_price { get; set; }
        public decimal retail_price { get; set; }
        public DateTime creative_time { get; set; }
        public DateTime edit_time { get; set; }

        // 其他属性可以根据需要添加
        public int Stock { get; set; } // StockQTY
    }
}
