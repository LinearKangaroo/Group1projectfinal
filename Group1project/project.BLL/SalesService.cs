using System;
using System.Collections.Generic;
using System.Linq;
using Dapper;
using Group1project.project.DAL;
using Group1project.Model;
using System.Data;

namespace Group1project.project.BLL
{
    public class SalesService
    {
        private readonly SaleDAL _saleDal = new SaleDAL();

        public int GetTodaySellout()
        {
            return _saleDal.GetTodaySalesQuantity();
        }

        public decimal GetTodayProfit()
        {
            return _saleDal.GetTodaySalesProfit();
        }

        public string GetTodayBestSellSpuName()
        {
            return _saleDal.GetTodayHotSellSpuName();
        }
        // Average daily sold items (total across all products) for the last 7 days
        public decimal GetAverageDailySalesLast7DaysTotal()
        {
            List<DailySalesPointModel> last7Days = GetRecent7DaySales();
            if (last7Days.Count == 0)
            {
                return 0m;
            }

            int sum = 0;
            foreach (DailySalesPointModel item in last7Days)
            {
                sum += item.Quantity;
            }

            return sum / 7m;
        }

        public List<DailySalesPointModel> GetRecent7DaySales()
        {
            return _saleDal.GetRecent7DaySales();
        }

        public List<BrandSalesRatioModel> GetTodayBrandRatio()
        {
            return _saleDal.GetTodayBrandSalesRatios();
        }
    }
}
