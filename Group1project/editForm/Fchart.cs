using Group1project.Model;
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
        public Fchart()
        {
            InitializeComponent();
            btnOK.Visible = false;
            btnCancel.Text = "Close";
        }

        public void BindSalesTrend(List<SalesTrendPointModel> points, TrendRange range)
        {
            // 用反射兼容不同 SunnyUI 版本，避免 UILineSeries / AddData / Add 等 API 差异导致编译或运行报错
            string title = range switch
            {
                TrendRange.Week => "Last 7 days sellout",
                TrendRange.Month => "Daily sellout this month",
                _ => "Monthly sellout this year"
            };

            try
            {
                Type? optionType = Type.GetType("Sunny.UI.UILineOption, SunnyUI");
                Type? seriesType = Type.GetType("Sunny.UI.UILineSeries, SunnyUI");
                if (optionType == null || seriesType == null)
                {
                    return;
                }

                object? option = Activator.CreateInstance(optionType);
                object? series = Activator.CreateInstance(seriesType);
                if (option == null || series == null)
                {
                    return;
                }

                SetNestedProperty(option, "Title.Text", title);
                SetNestedProperty(option, "YAxis.AxisLabel.DecimalPlaces", 0);
                SetProperty(series, "Name", "Sellout");

                object? xAxisData = GetNestedProperty(option, "XAxis.Data");
                foreach (SalesTrendPointModel point in points)
                {
                    AddToCollection(xAxisData, point.Label);
                    if (!InvokeAddData(series, point.Quantity))
                    {
                        AddToCollection(series, point.Quantity);
                    }
                }

                object? optionSeries = GetProperty(option, "Series");
                ClearCollection(optionSeries);
                AddToCollection(optionSeries, series);

                MethodInfo? setOption = uiLineChart1.GetType().GetMethod("SetOption", new[] { optionType });
                if (setOption != null)
                {
                    setOption.Invoke(uiLineChart1, new[] { option });
                }
            }
            catch
            {
                // 保持页面可用，不抛出到 UI 线程
            }
        }

        private static object? GetProperty(object obj, string name)
        {
            PropertyInfo? p = obj.GetType().GetProperty(name);
            return p?.GetValue(obj);
        }

        private static void SetProperty(object obj, string name, object? value)
        {
            PropertyInfo? p = obj.GetType().GetProperty(name);
            if (p != null && p.CanWrite)
            {
                p.SetValue(obj, value);
            }
        }

        private static object? GetNestedProperty(object obj, string path)
        {
            object? current = obj;
            foreach (string part in path.Split('.'))
            {
                if (current == null)
                {
                    return null;
                }

                PropertyInfo? p = current.GetType().GetProperty(part);
                current = p?.GetValue(current);
            }

            return current;
        }

        private static void SetNestedProperty(object obj, string path, object? value)
        {
            string[] parts = path.Split('.');
            object? current = obj;
            for (int i = 0; i < parts.Length - 1; i++)
            {
                if (current == null)
                {
                    return;
                }

                PropertyInfo? p = current.GetType().GetProperty(parts[i]);
                current = p?.GetValue(current);
            }

            if (current == null)
            {
                return;
            }

            PropertyInfo? last = current.GetType().GetProperty(parts[^1]);
            if (last != null && last.CanWrite)
            {
                last.SetValue(current, value);
            }
        }

        private static bool InvokeAddData(object series, int value)
        {
            MethodInfo? addData = series.GetType().GetMethod("AddData", new[] { typeof(int) })
                                  ?? series.GetType().GetMethod("AddData", new[] { typeof(double) });
            if (addData == null)
            {
                return false;
            }

            ParameterInfo[] ps = addData.GetParameters();
            if (ps.Length == 1 && ps[0].ParameterType == typeof(double))
            {
                addData.Invoke(series, new object[] { Convert.ToDouble(value) });
            }
            else
            {
                addData.Invoke(series, new object[] { value });
            }

            return true;
        }

        private static void ClearCollection(object? collection)
        {
            if (collection == null)
            {
                return;
            }

            MethodInfo? clear = collection.GetType().GetMethod("Clear", Type.EmptyTypes);
            clear?.Invoke(collection, null);
        }

        private static void AddToCollection(object? collection, object? item)
        {
            if (collection == null)
            {
                return;
            }

            MethodInfo? add = collection.GetType().GetMethod("Add");
            if (add != null)
            {
                add.Invoke(collection, new[] { item });
                return;
            }

            if (collection is IList list)
            {
                list.Add(item);
            }
        }
    }
}
