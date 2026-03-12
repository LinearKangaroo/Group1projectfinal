using Group1project.Model;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;

namespace Group1project.Adminchildform
{
    public partial class FrmUdash : UIPage
    {
        public FrmUdash()
        {
            InitializeComponent();
            LoadData();
            uiToolTip1.SetToolTip(uiPanel1, "Today Sell Quantity");
            uiToolTip1.SetToolTip(uiPanel2, "Stock");
            uiToolTip1.SetToolTip(uiPanel3, "Days of Supply = Stock/Average Daily Selllout of recent 7days");
            uiToolTip1.SetToolTip(uiPanel1, "Today Hot Sell Product");
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


                string best = salesSvc.GetTodayBestSellSpuName();
                lblhotsell.Text = string.IsNullOrWhiteSpace(best) ? "-" : best;
            }
            catch (Exception ex)
            {
                // simple fallback: show errors in labels
                //lblso.Text = "0";
                //lblstock.Text = "0";
                //lblDos.Text = "-";
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
        }

        private void BindDailySalesChart(List<DailySalesPointModel> series)
        {
            // 1. 创建 Option
            UIBarOption option = new UIBarOption();
            option.Title = new UITitle { Text = "Recent 7days Sellout" };

            option.YAxis.AxisLabel.DecimalPlaces = 0; // 设置坐标轴标签小数位为 0

            // 2. 创建 Series (注意是 UIBarSeries)
            var barSeries = new UIBarSeries();
            barSeries.Name = "Sellout";

            // 3. 填充数据
            foreach (var item in series)
            {
                // 添加 X 轴标签
                option.XAxis.Data.Add(item.Date.ToString("MM-dd"));
                // 添加 Y 轴数值
                barSeries.AddData((int)item.Quantity);
            }

            // 4. 将 Series 添加到 Option
            option.Series.Add(barSeries);

            // 5. 设置并刷新
            bctdailyso.SetOption(option);
        }
    
    }
}
