using Group1project.Model;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Text;
using System.Windows.Forms;

namespace Group1project.editForm
{
    public partial class Fchart : UIEditForm
    {
        private readonly AnalysisBLL _analysisBll = new AnalysisBLL();
        private readonly List<string> _brands;
        private TrendRange _range;

        public Fchart(List<string> brands, TrendRange range)
        {
            InitializeComponent();
            btnOK.Visible = false;
            btnCancel.Text = "Close";

            _brands = brands ?? new List<string>();
            _range = range;

            cboyear.SelectedIndexChanged += Cboyear_SelectedIndexChanged;
            cbomonth.SelectedIndexChanged += Cbomonth_SelectedIndexChanged;

            InitSelectors();
            LoadTrend();
        }

        private void InitSelectors()
        {
            List<int> years = _analysisBll.GetAvailableYears();
            if (!years.Contains(DateTime.Today.Year))
            {
                years.Add(DateTime.Today.Year);
            }

            years = years.Distinct().OrderBy(y => y).ToList();
            cboyear.Items.Clear();
            foreach (int y in years)
            {
                cboyear.Items.Add(y.ToString());
            }

            cbomonth.Items.Clear();
            for (int m = 1; m <= 12; m++)
            {
                cbomonth.Items.Add(m.ToString("00"));
            }

            int yearIndex = years.FindIndex(y => y == DateTime.Today.Year);
            cboyear.SelectedIndex = yearIndex >= 0 ? yearIndex : years.Count - 1;
            cbomonth.SelectedIndex = DateTime.Today.Month - 1;

            cboyear.Enabled = _range != TrendRange.Week;
            cbomonth.Enabled = _range == TrendRange.Month;
        }

        private void Cboyear_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_range != TrendRange.Week)
            {
                LoadTrend();
            }
        }

        private void Cbomonth_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_range == TrendRange.Month)
            {
                LoadTrend();
            }
        }

        private void LoadTrend()
        {
            int? year = int.TryParse(cboyear.Text, out int y) ? y : null;
            int? month = int.TryParse(cbomonth.Text, out int m) ? m : null;

            List<SalesTrendPointModel> points = _analysisBll.GetTrendData(_range, _brands, year, month);
            BindSalesTrend(points, _range, year, month);
        }

        public void BindSalesTrend(List<SalesTrendPointModel> points, TrendRange range, int? year = null, int? month = null)
        {
            int y = year ?? DateTime.Today.Year;
            int m = month ?? DateTime.Today.Month;
            string title = range switch
            {
                TrendRange.Week => "Last 7 days sellout",
                TrendRange.Month => $"Daily sellout {y:0000}-{m:00}",
                _ => $"Monthly sellout {y:0000}"
            };

            UILineOption option = new UILineOption();
            option.ToolTip.Visible = true;
            option.Title = new UITitle { Text = title };

            // 1. 设置轴名称（对应 Demo 中的用法）
            option.XAxis.Name = "Time";
            option.YAxis.Name = "Qty";

            // 2. 核心修复：3.9.2 使用 CustomLabels 来处理 X 轴的自定义字符串标签
            // 参数说明：起始值, 步长, 标签总数
            option.XAxis.CustomLabels = new CustomLabels(0, 1, points.Count);

            // 3. 创建系列
            var series = option.AddSeries(new UILineSeries("Sellout"));
            series.Symbol = UILinePointSymbol.Square; // 设置点形状
            series.Smooth = true; // 平滑曲线

            for (int i = 0; i < points.Count; i++)
            {
                // 4. 将 Label 添加到自定义标签集合中
                option.XAxis.CustomLabels.AddLabel(points[i].Label);

                // 5. 对应 Demo：Add(double x, double y)
                series.Add(i, Convert.ToDouble(points[i].Quantity));
            }

            // 6. Y 轴小数位数设置
            option.YAxis.AxisLabel.DecimalPlaces = 0;

            // 7. 自动缩放 Y 轴，防止 1-2 个数据时刻度太挤
            option.YAxis.Scale = true;

            // 8. 渲染
            uiLineChart1.SetOption(option);
            uiLineChart1.Refresh();
        }
    }
}
