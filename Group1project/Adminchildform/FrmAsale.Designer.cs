namespace Group1project.Adminchildform
{
    partial class FrmAsale
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            uiPanel1 = new Sunny.UI.UIPanel();
            btnclear = new Sunny.UI.UISymbolButton();
            txtuser = new Sunny.UI.UITextBox();
            txtinvoice = new Sunny.UI.UITextBox();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            uiLabel1 = new Sunny.UI.UILabel();
            uiMarkLabel5 = new Sunny.UI.UIMarkLabel();
            uiDatePicker2 = new Sunny.UI.UIDatePicker();
            uiDatePicker1 = new Sunny.UI.UIDatePicker();
            uiPagination1 = new Sunny.UI.UIPagination();
            dgvsale = new Sunny.UI.UIDataGridView();
            txtcustomer = new Sunny.UI.UITextBox();
            btnexport = new Sunny.UI.UISymbolButton();
            uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvsale).BeginInit();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(btnexport);
            uiPanel1.Controls.Add(txtcustomer);
            uiPanel1.Controls.Add(btnclear);
            uiPanel1.Controls.Add(txtuser);
            uiPanel1.Controls.Add(txtinvoice);
            uiPanel1.Controls.Add(btnAdd);
            uiPanel1.Controls.Add(btnSearch);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.Controls.Add(uiMarkLabel5);
            uiPanel1.Controls.Add(uiDatePicker2);
            uiPanel1.Controls.Add(uiDatePicker1);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(0, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(859, 119);
            uiPanel1.TabIndex = 7;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnclear
            // 
            btnclear.Font = new Font("Microsoft Sans Serif", 12F);
            btnclear.Location = new Point(576, 54);
            btnclear.MinimumSize = new Size(1, 1);
            btnclear.Name = "btnclear";
            btnclear.Size = new Size(121, 34);
            btnclear.Symbol = 557676;
            btnclear.TabIndex = 22;
            btnclear.Text = "Clear";
            btnclear.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // txtuser
            // 
            txtuser.ButtonSymbol = 361453;
            txtuser.ButtonSymbolOffset = new Point(0, 1);
            txtuser.Font = new Font("Microsoft Sans Serif", 12F);
            txtuser.Location = new Point(200, 12);
            txtuser.Margin = new Padding(4, 5, 4, 5);
            txtuser.MinimumSize = new Size(1, 16);
            txtuser.Name = "txtuser";
            txtuser.Padding = new Padding(5);
            txtuser.ShowButton = true;
            txtuser.ShowText = false;
            txtuser.Size = new Size(188, 34);
            txtuser.TabIndex = 21;
            txtuser.TextAlignment = ContentAlignment.MiddleLeft;
            txtuser.Watermark = "username";
            // 
            // txtinvoice
            // 
            txtinvoice.ButtonSymbol = 361453;
            txtinvoice.ButtonSymbolOffset = new Point(0, 1);
            txtinvoice.Font = new Font("Microsoft Sans Serif", 12F);
            txtinvoice.Location = new Point(13, 12);
            txtinvoice.Margin = new Padding(4, 5, 4, 5);
            txtinvoice.MinimumSize = new Size(1, 16);
            txtinvoice.Name = "txtinvoice";
            txtinvoice.Padding = new Padding(5);
            txtinvoice.ShowButton = true;
            txtinvoice.ShowText = false;
            txtinvoice.Size = new Size(179, 34);
            txtinvoice.TabIndex = 20;
            txtinvoice.TextAlignment = ContentAlignment.MiddleLeft;
            txtinvoice.Watermark = "Invoice ID";
            // 
            // btnAdd
            // 
            btnAdd.FillColor = Color.Red;
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            btnAdd.Location = new Point(716, 12);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(121, 78);
            btnAdd.Symbol = 61543;
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Sale";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.Location = new Point(449, 53);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 34);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Search";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(246, 56);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(36, 29);
            uiLabel1.TabIndex = 9;
            uiLabel1.Text = "to";
            // 
            // uiMarkLabel5
            // 
            uiMarkLabel5.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel5.Location = new Point(13, 56);
            uiMarkLabel5.Name = "uiMarkLabel5";
            uiMarkLabel5.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel5.Size = new Size(75, 32);
            uiMarkLabel5.TabIndex = 7;
            uiMarkLabel5.Text = "Date";
            // 
            // uiDatePicker2
            // 
            uiDatePicker2.DateCultureInfo = new System.Globalization.CultureInfo("");
            uiDatePicker2.FillColor = Color.White;
            uiDatePicker2.Font = new Font("Microsoft Sans Serif", 12F);
            uiDatePicker2.Location = new Point(289, 57);
            uiDatePicker2.Margin = new Padding(4, 5, 4, 5);
            uiDatePicker2.MaxLength = 10;
            uiDatePicker2.MinimumSize = new Size(63, 0);
            uiDatePicker2.Name = "uiDatePicker2";
            uiDatePicker2.Padding = new Padding(0, 0, 30, 2);
            uiDatePicker2.Size = new Size(149, 31);
            uiDatePicker2.SymbolDropDown = 61555;
            uiDatePicker2.SymbolNormal = 61555;
            uiDatePicker2.SymbolSize = 24;
            uiDatePicker2.TabIndex = 1;
            uiDatePicker2.Text = "2026-02-19";
            uiDatePicker2.TextAlignment = ContentAlignment.MiddleLeft;
            uiDatePicker2.Value = new DateTime(2026, 2, 19, 17, 11, 6, 82);
            uiDatePicker2.Watermark = "";
            // 
            // uiDatePicker1
            // 
            uiDatePicker1.DateCultureInfo = new System.Globalization.CultureInfo("");
            uiDatePicker1.FillColor = Color.White;
            uiDatePicker1.Font = new Font("Microsoft Sans Serif", 12F);
            uiDatePicker1.Location = new Point(95, 56);
            uiDatePicker1.Margin = new Padding(4, 5, 4, 5);
            uiDatePicker1.MaxLength = 10;
            uiDatePicker1.MinimumSize = new Size(63, 0);
            uiDatePicker1.Name = "uiDatePicker1";
            uiDatePicker1.Padding = new Padding(0, 0, 30, 2);
            uiDatePicker1.Size = new Size(144, 31);
            uiDatePicker1.SymbolDropDown = 61555;
            uiDatePicker1.SymbolNormal = 61555;
            uiDatePicker1.SymbolSize = 24;
            uiDatePicker1.TabIndex = 0;
            uiDatePicker1.Text = "2026-02-19";
            uiDatePicker1.TextAlignment = ContentAlignment.MiddleLeft;
            uiDatePicker1.Value = new DateTime(2026, 2, 19, 17, 11, 6, 82);
            uiDatePicker1.Watermark = "";
            // 
            // uiPagination1
            // 
            uiPagination1.ButtonFillSelectedColor = Color.FromArgb(64, 128, 204);
            uiPagination1.ButtonStyleInherited = false;
            uiPagination1.Dock = DockStyle.Bottom;
            uiPagination1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPagination1.Location = new Point(0, 523);
            uiPagination1.Margin = new Padding(4, 5, 4, 5);
            uiPagination1.MinimumSize = new Size(1, 1);
            uiPagination1.Name = "uiPagination1";
            uiPagination1.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPagination1.ShowText = false;
            uiPagination1.Size = new Size(859, 42);
            uiPagination1.TabIndex = 8;
            uiPagination1.Text = "uiPagination1";
            uiPagination1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // dgvsale
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgvsale.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvsale.BackgroundColor = Color.White;
            dgvsale.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvsale.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvsale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvsale.DefaultCellStyle = dataGridViewCellStyle8;
            dgvsale.Dock = DockStyle.Fill;
            dgvsale.EnableHeadersVisualStyles = false;
            dgvsale.Font = new Font("Microsoft Sans Serif", 12F);
            dgvsale.GridColor = Color.FromArgb(80, 160, 255);
            dgvsale.Location = new Point(0, 154);
            dgvsale.Name = "dgvsale";
            dgvsale.ReadOnly = true;
            dgvsale.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvsale.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvsale.RowHeadersWidth = 57;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F);
            dgvsale.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvsale.SelectedIndex = -1;
            dgvsale.Size = new Size(859, 369);
            dgvsale.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvsale.TabIndex = 9;
            // 
            // txtcustomer
            // 
            txtcustomer.ButtonSymbol = 361453;
            txtcustomer.ButtonSymbolOffset = new Point(0, 1);
            txtcustomer.Font = new Font("Microsoft Sans Serif", 12F);
            txtcustomer.Location = new Point(396, 12);
            txtcustomer.Margin = new Padding(4, 5, 4, 5);
            txtcustomer.MinimumSize = new Size(1, 16);
            txtcustomer.Name = "txtcustomer";
            txtcustomer.Padding = new Padding(5);
            txtcustomer.ShowButton = true;
            txtcustomer.ShowText = false;
            txtcustomer.Size = new Size(174, 34);
            txtcustomer.TabIndex = 22;
            txtcustomer.TextAlignment = ContentAlignment.MiddleLeft;
            txtcustomer.Watermark = "customer";
            // 
            // btnexport
            // 
            btnexport.Font = new Font("Microsoft Sans Serif", 12F);
            btnexport.Location = new Point(577, 11);
            btnexport.MinimumSize = new Size(1, 1);
            btnexport.Name = "btnexport";
            btnexport.Size = new Size(120, 34);
            btnexport.Symbol = 362830;
            btnexport.TabIndex = 23;
            btnexport.Text = "Export";
            btnexport.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // FrmAsale
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(859, 565);
            Controls.Add(dgvsale);
            Controls.Add(uiPagination1);
            Controls.Add(uiPanel1);
            Name = "FrmAsale";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 361788;
            Text = "Transaction";
            uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvsale).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIMarkLabel uiMarkLabel5;
        private Sunny.UI.UIDatePicker uiDatePicker2;
        private Sunny.UI.UIDatePicker uiDatePicker1;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UITextBox txtinvoice;
        private Sunny.UI.UITextBox txtuser;
        private Sunny.UI.UISymbolButton btnclear;
        private Sunny.UI.UIPagination uiPagination1;
        private Sunny.UI.UIDataGridView dgvsale;
        private Sunny.UI.UITextBox txtcustomer;
        private Sunny.UI.UISymbolButton btnexport;
    }
}