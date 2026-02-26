using Group1project.Model;
using Group1project.project.DAL;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Group1project.project.BLL
{
    public class SaleBLL
    {
        private readonly SaleDAL _saleDal = new SaleDAL();

        public List<SalehistoryModel> GetSaleHistory(DateTime startDate, DateTime endDate, string invoiceKeyword, string username)
            => _saleDal.GetSaleHistory(startDate, endDate, invoiceKeyword, username);

        public List<SaleInvoiceModel> GetInvoiceDetails(int invoiceId)
            => _saleDal.GetInvoiceDetails(invoiceId);

        public SaleInvoiceModel? GetInvoiceItemByImei(string imei)
        {
            if (string.IsNullOrWhiteSpace(imei))
            {
                return null;
            }

            return _saleDal.GetInvoiceItemByImei(imei.Trim());
        }

        public bool IsImeiInStock(string imei)
        {
            if (string.IsNullOrWhiteSpace(imei))
            {
                return false;
            }

            return _saleDal.IsImeiInStock(imei.Trim());
        }

        public List<UserModel> GetActiveUsers() => _saleDal.GetActiveUsers();

        public int GetNextInvoiceId() => _saleDal.GetNextInvoiceId();

        public bool SaveSale(int invoiceId, DateTime sellDate, int userId, string paymentType, List<SaleInvoiceModel> items)
        {
            if (invoiceId <= 0 || userId <= 0 || string.IsNullOrWhiteSpace(paymentType) || items.Count == 0)
            {
                return false;
            }

            return _saleDal.SaveSale(invoiceId, sellDate, userId, paymentType.Trim(), items);
        }

        public decimal SumAmount(List<SaleInvoiceModel> source)
            => source.Sum(x => x.unit_price);
    }
}
