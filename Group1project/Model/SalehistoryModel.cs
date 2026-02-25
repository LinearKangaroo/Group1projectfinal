using System;

namespace Group1project.Model
{
    public class SalehistoryModel
    {
        //from tblsale
        public int invoice_id { get; set; }
        public DateTime sell_date { get; set; }
        public int userId { get; set; }
        public decimal amount { get; set; }
        public string payment_type { get; set; }

        //from tbluser
        public string username { get; set; }
    }
}
