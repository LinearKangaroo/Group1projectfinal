using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
namespace Group1project.Adminchildform
{
    public partial class FrmAanalysis : UIPage
    {
        private DataTable dataTable;

        public FrmAanalysis()
        {
            InitializeComponent();

            dataTable = new DataTable("DataTable");
            dataTable.Columns.Add("SKUname", typeof(string));
            dataTable.Columns.Add("Sellout", typeof(int));
            dataTable.Columns.Add("stock", typeof(int));
            dataTable.Columns.Add("DOS", typeof(int));
            uiDataGridView1.DataSource = dataTable;

            //不自动生成列
            uiDataGridView1.AutoGenerateColumns = false;
        }
    }
}
