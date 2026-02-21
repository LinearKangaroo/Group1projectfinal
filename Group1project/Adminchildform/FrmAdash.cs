using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace Group1project.Adminchildform
{
    public partial class FrmAdash : UIPage
    {
        public FrmAdash()
        {
            InitializeComponent();
            //LoadData();
        }

        /*private void LoadData()
        {
            try
            {
                var salesSvc = new project.BLL.SalesService();
                var prodSvc = new project.BLL.ProductService();

                // Sellout today (total quantity sold)
                var sellout = salesSvc.GetTodaySellOut();
                lblso.Text = sellout.ToString();

                // Total stock
                var stock = prodSvc.GetTotalStock();
                lblstock.Text = stock.ToString();

                // DOS = current stock / average daily sales of last 7 days (for all products combined)
                // compute average daily sales total for last 7 days
                var avgDaily = salesSvc.GetAverageDailySalesLast7DaysTotal();
                var dosText = "-";
                if (avgDaily > 0)
                {
                    var dos = stock / avgDaily;
                    dosText = Math.Round(dos, 2) + " days";
                }
                lblDos.Text = dosText;

                // Total amount today
                var amount = salesSvc.GetTodayAmount();
                lblamount.Text = amount.ToString("C");

                // Best sell today
                var best = salesSvc.GetTodayBestSell();
                lblhotsell.Text = string.IsNullOrEmpty(best) ? "-" : best;
            }
            catch (Exception ex)
            {
                // simple fallback: show errors in labels
                lblso.Text = "0";
                lblstock.Text = "0";
                lblDos.Text = "-";
                lblamount.Text = "0";
                lblhotsell.Text = "-";
                // optionally log exception
                Console.WriteLine(ex.ToString());
            }
        }*/
    }
}
