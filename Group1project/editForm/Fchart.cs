using Group1project.Model;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System;
using System.Collections;
using System.Collections.Generic;
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
            option.Title = new UITitle { Text = title };

            // 确保清除旧数据
            option.XAxis.Data.Clear();
            option.Series.Clear();

            UILineSeries series = new UILineSeries("Sellout");

            // 3.9.2 版本的关键：使用双参数 Add
            for (int i = 0; i < points.Count; i++)
            {
                // 添加底部日期/品牌标签
                option.XAxis.Data.Add(points[i].Label);

                // 添加数据点：索引为 i，值为数量
                series.Add(i, Convert.ToDouble(points[i].Quantity));
            }

            option.AddSeries(series);

            // 优化：如果数值较小（如你截图中的 1 或 2），开启缩放防止刻度重叠
            option.YAxis.Scale = true;

            uiLineChart1.SetOption(option);
            uiLineChart1.Refresh();
        }
    }
}
