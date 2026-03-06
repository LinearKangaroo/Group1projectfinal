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

        private void BindBrandRatioChart(List<BrandSalesRatioModel> ratios)
        {
            // 1. 创建 Option
            UIPieOption option = new UIPieOption();
            option.Title = new UITitle { Text = "Today Sellout Ratio", Left = UILeftAlignment.Center };
            option.ToolTip.Visible = true;

            // --- 添加图例 (Legend) 配置 ---
            option.Legend = new UILegend();
            option.Legend.Orient = UIOrient.Vertical;   // 垂直排列
            option.Legend.Left = UILeftAlignment.Left;  // 靠左显示
            option.Legend.Top = UITopAlignment.Top;     // 靠上显示

            option.ToolTip.Visible = true;

            // 2. 创建 Series (注意是 UIPieSeries)
            var pieSeries = new UIPieSeries();
            pieSeries.Name = "Ratio";
            pieSeries.Radius = 70;             // 调整圆环大小以留出图例空间
            pieSeries.Center = new UICenter(60, 50); // 将圆心稍向右移动

            if (ratios == null || ratios.Count == 0)
            {
                string name = "No sell";
                pieSeries.AddData(name, 1);
                option.Legend.AddData(name);   // 图例必须手动添加对应的数据名称
            }
            else
            {
                foreach (var item in ratios)
                {
                    string brandName = item.Brand ?? "Unknown";
                    pieSeries.AddData(brandName, (double)item.Quantity);
                    option.Legend.AddData(brandName); // 将品牌名加入图例列表
                }
            }

            option.Series.Clear();
            option.Series.Add(pieSeries);
            pctratio.SetOption(option);
        }
    }
}
