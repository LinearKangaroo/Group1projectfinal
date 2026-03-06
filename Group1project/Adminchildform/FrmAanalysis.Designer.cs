namespace Group1project.Adminchildform
{
    partial class FrmAanalysis
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
            uiDatePicker1 = new Sunny.UI.UIDatePicker();
            uiDatePicker2 = new Sunny.UI.UIDatePicker();
            uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            uiMarkLabel3 = new Sunny.UI.UIMarkLabel();
            uiPanel1 = new Sunny.UI.UIPanel();
            cboorder = new Sunny.UI.UIComboBox();
            cboview = new Sunny.UI.UIComboBox();
            cbosort = new Sunny.UI.UIComboBox();
            uiGroupBox1 = new Sunny.UI.UIGroupBox();
            this.btnyear = new Sunny.UI.UIButton();
            this.btnmonth = new Sunny.UI.UIButton();
            btnweek = new Sunny.UI.UIButton();
            uiMarkLabel8 = new Sunny.UI.UIMarkLabel();
            uiMarkLabel7 = new Sunny.UI.UIMarkLabel();
            btnSearch = new Sunny.UI.UISymbolButton();
            btnclear = new Sunny.UI.UISymbolButton();
            uiLabel1 = new Sunny.UI.UILabel();
            uiMarkLabel5 = new Sunny.UI.UIMarkLabel();
            cbotvbrand = new Sunny.UI.UIComboTreeView();
            uiDataGridViewFooter1 = new Sunny.UI.UIDataGridViewFooter();
            dgvanal = new Sunny.UI.UIDataGridView();
            uiPanel1.SuspendLayout();
            uiGroupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvanal).BeginInit();
            SuspendLayout();
            // 
            // uiDatePicker1
            // 
            uiDatePicker1.DateCultureInfo = new System.Globalization.CultureInfo("");
            uiDatePicker1.FillColor = Color.White;
            uiDatePicker1.Font = new Font("Microsoft Sans Serif", 12F);
            uiDatePicker1.Location = new Point(98, 119);
            uiDatePicker1.Margin = new Padding(4, 5, 4, 5);
            uiDatePicker1.MaxLength = 10;
            uiDatePicker1.MinimumSize = new Size(63, 0);
            uiDatePicker1.Name = "uiDatePicker1";
            uiDatePicker1.Padding = new Padding(0, 0, 30, 2);
            uiDatePicker1.Size = new Size(147, 31);
            uiDatePicker1.SymbolDropDown = 61555;
            uiDatePicker1.SymbolNormal = 61555;
            uiDatePicker1.SymbolSize = 24;
            uiDatePicker1.TabIndex = 0;
            uiDatePicker1.Text = "2026-02-19";
            uiDatePicker1.TextAlignment = ContentAlignment.MiddleLeft;
            uiDatePicker1.Value = new DateTime(2026, 2, 19, 17, 11, 6, 82);
            uiDatePicker1.Watermark = "";
            // 
            // uiDatePicker2
            // 
            uiDatePicker2.DateCultureInfo = new System.Globalization.CultureInfo("");
            uiDatePicker2.FillColor = Color.White;
            uiDatePicker2.Font = new Font("Microsoft Sans Serif", 12F);
            uiDatePicker2.Location = new Point(295, 120);
            uiDatePicker2.Margin = new Padding(4, 5, 4, 5);
            uiDatePicker2.MaxLength = 10;
            uiDatePicker2.MinimumSize = new Size(63, 0);
            uiDatePicker2.Name = "uiDatePicker2";
            uiDatePicker2.Padding = new Padding(0, 0, 30, 2);
            uiDatePicker2.Size = new Size(153, 31);
            uiDatePicker2.SymbolDropDown = 61555;
            uiDatePicker2.SymbolNormal = 61555;
            uiDatePicker2.SymbolSize = 24;
            uiDatePicker2.TabIndex = 1;
            uiDatePicker2.Text = "2026-02-19";
            uiDatePicker2.TextAlignment = ContentAlignment.MiddleLeft;
            uiDatePicker2.Value = new DateTime(2026, 2, 19, 17, 11, 6, 82);
            uiDatePicker2.Watermark = "";
            // 
            // uiMarkLabel1
            // 
            uiMarkLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel1.Location = new Point(14, 16);
            uiMarkLabel1.Name = "uiMarkLabel1";
            uiMarkLabel1.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel1.Size = new Size(113, 32);
            uiMarkLabel1.TabIndex = 2;
            uiMarkLabel1.Text = "Brand";
            // 
            // uiMarkLabel3
            // 
            uiMarkLabel3.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel3.Location = new Point(335, 18);
            uiMarkLabel3.Name = "uiMarkLabel3";
            uiMarkLabel3.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel3.Size = new Size(113, 32);
            uiMarkLabel3.TabIndex = 4;
            uiMarkLabel3.Text = "View by";
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(cboorder);
            uiPanel1.Controls.Add(cboview);
            uiPanel1.Controls.Add(cbosort);
            uiPanel1.Controls.Add(uiGroupBox1);
            uiPanel1.Controls.Add(uiMarkLabel8);
            uiPanel1.Controls.Add(uiMarkLabel7);
            uiPanel1.Controls.Add(btnSearch);
            uiPanel1.Controls.Add(btnclear);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.Controls.Add(uiMarkLabel5);
            uiPanel1.Controls.Add(cbotvbrand);
            uiPanel1.Controls.Add(uiDatePicker2);
            uiPanel1.Controls.Add(uiMarkLabel3);
            uiPanel1.Controls.Add(uiDatePicker1);
            uiPanel1.Controls.Add(uiMarkLabel1);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(0, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(1006, 170);
            uiPanel1.TabIndex = 5;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cboorder
            // 
            cboorder.DataSource = null;
            cboorder.FillColor = Color.White;
            cboorder.Font = new Font("Microsoft Sans Serif", 12F);
            cboorder.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboorder.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboorder.Location = new Point(473, 61);
            cboorder.Margin = new Padding(4, 5, 4, 5);
            cboorder.MinimumSize = new Size(63, 0);
            cboorder.Name = "cboorder";
            cboorder.Padding = new Padding(0, 0, 30, 2);
            cboorder.Size = new Size(177, 37);
            cboorder.SymbolSize = 24;
            cboorder.TabIndex = 23;
            cboorder.TextAlignment = ContentAlignment.MiddleLeft;
            cboorder.Watermark = "";
            // 
            // cboview
            // 
            cboview.DataSource = null;
            cboview.FillColor = Color.White;
            cboview.Font = new Font("Microsoft Sans Serif", 12F);
            cboview.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboview.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboview.Location = new Point(472, 18);
            cboview.Margin = new Padding(4, 5, 4, 5);
            cboview.MinimumSize = new Size(63, 0);
            cboview.Name = "cboview";
            cboview.Padding = new Padding(0, 0, 30, 2);
            cboview.Size = new Size(177, 37);
            cboview.SymbolSize = 24;
            cboview.TabIndex = 23;
            cboview.TextAlignment = ContentAlignment.MiddleLeft;
            cboview.Watermark = "";
            // 
            // cbosort
            // 
            cbosort.DataSource = null;
            cbosort.FillColor = Color.White;
            cbosort.Font = new Font("Microsoft Sans Serif", 12F);
            cbosort.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbosort.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbosort.Location = new Point(128, 66);
            cbosort.Margin = new Padding(4, 5, 4, 5);
            cbosort.MinimumSize = new Size(63, 0);
            cbosort.Name = "cbosort";
            cbosort.Padding = new Padding(0, 0, 30, 2);
            cbosort.Size = new Size(177, 37);
            cbosort.SymbolSize = 24;
            cbosort.TabIndex = 22;
            cbosort.TextAlignment = ContentAlignment.MiddleLeft;
            cbosort.Watermark = "";
            // 
            // uiGroupBox1
            // 
            uiGroupBox1.Controls.Add(this.btnyear);
            uiGroupBox1.Controls.Add(this.btnmonth);
            uiGroupBox1.Controls.Add(btnweek);
            uiGroupBox1.Font = new Font("Microsoft Sans Serif", 12F);
            uiGroupBox1.Location = new Point(692, 5);
            uiGroupBox1.Margin = new Padding(4, 5, 4, 5);
            uiGroupBox1.MinimumSize = new Size(1, 1);
            uiGroupBox1.Name = "uiGroupBox1";
            uiGroupBox1.Padding = new Padding(0, 32, 0, 0);
            uiGroupBox1.Size = new Size(189, 160);
            uiGroupBox1.TabIndex = 21;
            uiGroupBox1.Text = "Sales Volume";
            uiGroupBox1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // btnyear
            // 
            this.btnyear.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnyear.Location = new Point(18, 115);
            this.btnyear.MinimumSize = new Size(1, 1);
            this.btnyear.Name = "btnyear";
            this.btnyear.Size = new Size(121, 36);
            this.btnyear.TabIndex = 2;
            this.btnyear.Text = "This year";
            this.btnyear.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnmonth
            // 
            this.btnmonth.Font = new Font("Microsoft Sans Serif", 12F);
            this.btnmonth.Location = new Point(18, 73);
            this.btnmonth.MinimumSize = new Size(1, 1);
            this.btnmonth.Name = "btnmonth";
            this.btnmonth.Size = new Size(121, 36);
            this.btnmonth.TabIndex = 1;
            this.btnmonth.Text = "This month";
            this.btnmonth.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnweek
            // 
            btnweek.Font = new Font("Microsoft Sans Serif", 12F);
            btnweek.Location = new Point(18, 35);
            btnweek.MinimumSize = new Size(1, 1);
            btnweek.Name = "btnweek";
            btnweek.Size = new Size(121, 36);
            btnweek.TabIndex = 0;
            btnweek.Text = "This week";
            btnweek.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiMarkLabel8
            // 
            uiMarkLabel8.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel8.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel8.Location = new Point(332, 66);
            uiMarkLabel8.Name = "uiMarkLabel8";
            uiMarkLabel8.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel8.Size = new Size(134, 32);
            uiMarkLabel8.TabIndex = 19;
            uiMarkLabel8.Text = "Order";
            // 
            // uiMarkLabel7
            // 
            uiMarkLabel7.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel7.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel7.Location = new Point(14, 66);
            uiMarkLabel7.Name = "uiMarkLabel7";
            uiMarkLabel7.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel7.Size = new Size(113, 32);
            uiMarkLabel7.TabIndex = 18;
            uiMarkLabel7.Text = "Sort by";
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.Location = new Point(455, 119);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(114, 34);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 17;
            btnSearch.Text = "Search";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnclear
            // 
            btnclear.Font = new Font("Microsoft Sans Serif", 12F);
            btnclear.Location = new Point(588, 119);
            btnclear.MinimumSize = new Size(1, 1);
            btnclear.Name = "btnclear";
            btnclear.Size = new Size(97, 34);
            btnclear.Symbol = 557676;
            btnclear.TabIndex = 10;
            btnclear.Text = "Clear";
            btnclear.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(252, 121);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(36, 29);
            uiLabel1.TabIndex = 9;
            uiLabel1.Text = "to";
            // 
            // uiMarkLabel5
            // 
            uiMarkLabel5.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel5.Location = new Point(16, 119);
            uiMarkLabel5.Name = "uiMarkLabel5";
            uiMarkLabel5.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel5.Size = new Size(75, 32);
            uiMarkLabel5.TabIndex = 7;
            uiMarkLabel5.Text = "Date";
            // 
            // cbotvbrand
            // 
            cbotvbrand.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cbotvbrand.FillColor = Color.White;
            cbotvbrand.Font = new Font("Microsoft Sans Serif", 12F);
            cbotvbrand.Location = new Point(128, 18);
            cbotvbrand.Margin = new Padding(4, 5, 4, 5);
            cbotvbrand.MinimumSize = new Size(63, 0);
            cbotvbrand.Name = "cbotvbrand";
            cbotvbrand.Padding = new Padding(0, 0, 30, 2);
            cbotvbrand.Size = new Size(182, 35);
            cbotvbrand.SymbolSize = 24;
            cbotvbrand.TabIndex = 5;
            cbotvbrand.TextAlignment = ContentAlignment.MiddleLeft;
            cbotvbrand.Watermark = "";
            // 
            // uiDataGridViewFooter1
            // 
            uiDataGridViewFooter1.DataGridView = null;
            uiDataGridViewFooter1.Dock = DockStyle.Bottom;
            uiDataGridViewFooter1.Font = new Font("Microsoft Sans Serif", 12F);
            uiDataGridViewFooter1.Location = new Point(0, 534);
            uiDataGridViewFooter1.MinimumSize = new Size(1, 1);
            uiDataGridViewFooter1.Name = "uiDataGridViewFooter1";
            uiDataGridViewFooter1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            uiDataGridViewFooter1.Size = new Size(1006, 41);
            uiDataGridViewFooter1.TabIndex = 6;
            uiDataGridViewFooter1.Text = "uiDataGridViewFooter1";
            // 
            // dgvanal
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgvanal.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvanal.BackgroundColor = Color.White;
            dgvanal.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvanal.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvanal.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvanal.DefaultCellStyle = dataGridViewCellStyle8;
            dgvanal.Dock = DockStyle.Fill;
            dgvanal.EnableHeadersVisualStyles = false;
            dgvanal.Font = new Font("Microsoft Sans Serif", 12F);
            dgvanal.GridColor = Color.FromArgb(80, 160, 255);
            dgvanal.Location = new Point(0, 205);
            dgvanal.Name = "dgvanal";
            dgvanal.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvanal.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvanal.RowHeadersWidth = 57;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F);
            dgvanal.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvanal.SelectedIndex = -1;
            dgvanal.Size = new Size(1006, 329);
            dgvanal.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvanal.TabIndex = 7;
            // 
            // FrmAanalysis
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1006, 575);
            Controls.Add(dgvanal);
            Controls.Add(uiDataGridViewFooter1);
            Controls.Add(uiPanel1);
            Name = "FrmAanalysis";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 557931;
            Text = "Analysis";
            uiPanel1.ResumeLayout(false);
            uiGroupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvanal).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIDatePicker uiDatePicker1;
        private Sunny.UI.UIDatePicker uiDatePicker2;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Sunny.UI.UIMarkLabel uiMarkLabel3;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIComboTreeView cbotvbrand;
        private Sunny.UI.UIMarkLabel uiMarkLabel5;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UISymbolButton btnclear;
        private Sunny.UI.UIDataGridView uiDataGridView1;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UIMarkLabel uiMarkLabel8;
        private Sunny.UI.UIMarkLabel uiMarkLabel7;
        private Sunny.UI.UIGroupBox uiGroupBox1;
        private Sunny.UI.UIButton uiButton3;
        private Sunny.UI.UIButton uiButton2;
        private Sunny.UI.UIButton btnweek;
        private Sunny.UI.UIComboBox cboorder;
        private Sunny.UI.UIComboBox cboview;
        private Sunny.UI.UIComboBox cbosort;
        private Sunny.UI.UIDataGridViewFooter uiDataGridViewFooter1;
        private Sunny.UI.UIDataGridView dgvanal;
    }
}