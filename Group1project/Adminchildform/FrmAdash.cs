using Group1project.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Reflection;
using System.Linq;

namespace Group1project.Adminchildform
{
    public partial class FrmAdash : UIPage
    {
        public FrmAdash()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            var salesSvc = new project.BLL.SalesService();
            var prodSvc = new project.BLL.ProductService();

            // 先加载核心数字，避免图表异常导致全部回退为 0
            try
            {
                int sellout = salesSvc.GetTodaySellout();
                lblso.Text = sellout.ToString();

                int stock = prodSvc.GetTotalStock();
                lblstock.Text = stock.ToString();

                decimal avgDaily = salesSvc.GetAverageDailySalesLast7DaysTotal();
                lblDos.Text = avgDaily > 0 ? Math.Round(stock / avgDaily, 0).ToString("0", CultureInfo.InvariantCulture) : "-";

                decimal profit = salesSvc.GetTodayProfit();
                lblamount.Text = profit.ToString("0.##");

                string best = salesSvc.GetTodayBestSellSpuName();
                lblhotsell.Text = string.IsNullOrWhiteSpace(best) ? "-" : best;
            }
            catch (Exception ex)
            {
                // simple fallback: show errors in labels
                //lblso.Text = "0";
                //lblstock.Text = "0";
                //lblDos.Text = "-";
                //lblamount.Text = "0";
                //lblhotsell.Text = "-";
                // optionally log exception
                Console.WriteLine(ex.ToString());
            }

            // 图表单独保护，避免影响上面数字显示
            try
            {
                BindDailySalesChart(salesSvc.GetRecent7DaySales());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            try
            {
                BindBrandRatioChart(salesSvc.GetTodayBrandRatio());
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void BindDailySalesChart(List<DailySalesPointModel> series)
        {
            string[] labels = series.Select(x => x.Date.ToString("MM-dd")).ToArray();
            double[] values = series.Select(x => (double)x.Quantity).ToArray();

            dynamic chart = bctdailyso;
            chart.Clear();

            // 直接用 SunnyUI API（先走 SetData，再回退 AddSeries+SetCategories）
            try
            {
                chart.SetData("销量", labels, values);
            }
            catch
            {
                chart.AddSeries("销量", values);
                chart.SetCategories(labels);
            }

            chart.Refresh();
        }

        private void BindBrandRatioChart(List<BrandSalesRatioModel> ratios)
        {
            dynamic chart = pctratio;
            chart.Clear();

            string[] names;
            double[] values;

            if (ratios.Count == 0)
            {
                names = new[] { "无销售" };
                values = new[] { 1d };
            }
            else
            {
                names = ratios.Select(x => x.Brand).ToArray();
                values = ratios.Select(x => (double)x.Quantity).ToArray();
            }

            // 直接用 SunnyUI API（先走 SetData，再回退 AddData）
            try
            {
                chart.SetData(names, values);
            }
            catch
            {
                for (int i = 0; i < names.Length && i < values.Length; i++)
                {
                    chart.AddData(names[i], values[i]);
                }
            }

            chart.Refresh();
        }
    }
}
