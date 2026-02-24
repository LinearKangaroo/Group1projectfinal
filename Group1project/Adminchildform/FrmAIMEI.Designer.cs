namespace Group1project.Adminchildform
{
    partial class FrmAIMEI
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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            txtimei = new Sunny.UI.UITextBox();
            btnEdit = new Sunny.UI.UISymbolButton();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            uiPanel1 = new Sunny.UI.UIPanel();
            uiPagination1 = new Sunny.UI.UIPagination();
            uiDataGridViewFooter1 = new Sunny.UI.UIDataGridViewFooter();
            dgvimei = new Sunny.UI.UIDataGridView();
            btnimport = new Sunny.UI.UISymbolButton();
            uiSymbolButton2 = new Sunny.UI.UISymbolButton();
            uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvimei).BeginInit();
            SuspendLayout();
            // 
            // txtimei
            // 
            txtimei.ButtonSymbol = 361453;
            txtimei.ButtonSymbolOffset = new Point(0, 1);
            txtimei.Font = new Font("Microsoft Sans Serif", 12F);
            txtimei.Location = new Point(14, 18);
            txtimei.Margin = new Padding(4, 5, 4, 5);
            txtimei.MinimumSize = new Size(1, 16);
            txtimei.Name = "txtimei";
            txtimei.Padding = new Padding(5);
            txtimei.ShowButton = true;
            txtimei.ShowText = false;
            txtimei.Size = new Size(246, 34);
            txtimei.TabIndex = 19;
            txtimei.TextAlignment = ContentAlignment.MiddleLeft;
            txtimei.Watermark = "IMEI";
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Microsoft Sans Serif", 12F);
            btnEdit.Location = new Point(519, 18);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(97, 34);
            btnEdit.Symbol = 61508;
            btnEdit.TabIndex = 18;
            btnEdit.Text = "Edit";
            btnEdit.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            btnAdd.Location = new Point(416, 18);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(93, 34);
            btnAdd.Symbol = 61543;
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.Location = new Point(278, 18);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 34);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiSymbolButton2);
            uiPanel1.Controls.Add(btnimport);
            uiPanel1.Controls.Add(txtimei);
            uiPanel1.Controls.Add(btnSearch);
            uiPanel1.Controls.Add(btnEdit);
            uiPanel1.Controls.Add(btnAdd);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(0, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(912, 74);
            uiPanel1.TabIndex = 20;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiPagination1
            // 
            uiPagination1.ButtonFillSelectedColor = Color.FromArgb(64, 128, 204);
            uiPagination1.Dock = DockStyle.Bottom;
            uiPagination1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPagination1.Location = new Point(0, 451);
            uiPagination1.Margin = new Padding(4, 5, 4, 5);
            uiPagination1.MinimumSize = new Size(1, 1);
            uiPagination1.Name = "uiPagination1";
            uiPagination1.RectSides = ToolStripStatusLabelBorderSides.None;
            uiPagination1.ShowText = false;
            uiPagination1.Size = new Size(912, 41);
            uiPagination1.TabIndex = 21;
            uiPagination1.Text = "uiPagination1";
            uiPagination1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiDataGridViewFooter1
            // 
            uiDataGridViewFooter1.DataGridView = null;
            uiDataGridViewFooter1.Dock = DockStyle.Bottom;
            uiDataGridViewFooter1.Font = new Font("Microsoft Sans Serif", 12F);
            uiDataGridViewFooter1.Location = new Point(0, 412);
            uiDataGridViewFooter1.MinimumSize = new Size(1, 1);
            uiDataGridViewFooter1.Name = "uiDataGridViewFooter1";
            uiDataGridViewFooter1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            uiDataGridViewFooter1.Size = new Size(912, 39);
            uiDataGridViewFooter1.TabIndex = 22;
            uiDataGridViewFooter1.Text = "uiDataGridViewFooter1";
            // 
            // dgvimei
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvimei.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvimei.BackgroundColor = Color.White;
            dgvimei.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvimei.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvimei.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvimei.DefaultCellStyle = dataGridViewCellStyle3;
            dgvimei.Dock = DockStyle.Fill;
            dgvimei.EnableHeadersVisualStyles = false;
            dgvimei.Font = new Font("Microsoft Sans Serif", 12F);
            dgvimei.GridColor = Color.FromArgb(80, 160, 255);
            dgvimei.Location = new Point(0, 109);
            dgvimei.Name = "dgvimei";
            dgvimei.ReadOnly = true;
            dgvimei.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvimei.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvimei.RowHeadersWidth = 57;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgvimei.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvimei.SelectedIndex = -1;
            dgvimei.Size = new Size(912, 303);
            dgvimei.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvimei.TabIndex = 23;
            // 
            // btnimport
            // 
            btnimport.Font = new Font("Microsoft Sans Serif", 12F);
            btnimport.Location = new Point(638, 18);
            btnimport.MinimumSize = new Size(1, 1);
            btnimport.Name = "btnimport";
            btnimport.Size = new Size(121, 34);
            btnimport.Symbol = 362831;
            btnimport.TabIndex = 20;
            btnimport.Text = "Import";
            btnimport.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiSymbolButton2
            // 
            uiSymbolButton2.Font = new Font("Microsoft Sans Serif", 12F);
            uiSymbolButton2.Location = new Point(777, 18);
            uiSymbolButton2.MinimumSize = new Size(1, 1);
            uiSymbolButton2.Name = "uiSymbolButton2";
            uiSymbolButton2.Size = new Size(121, 34);
            uiSymbolButton2.Symbol = 362830;
            uiSymbolButton2.TabIndex = 21;
            uiSymbolButton2.Text = "Export";
            uiSymbolButton2.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // FrmAIMEI
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(912, 492);
            Controls.Add(dgvimei);
            Controls.Add(uiDataGridViewFooter1);
            Controls.Add(uiPagination1);
            Controls.Add(uiPanel1);
            Name = "FrmAIMEI";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 557721;
            Text = "IMEI Info";
            uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvimei).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox txtimei;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIPagination uiPagination1;
        private Sunny.UI.UIDataGridViewFooter uiDataGridViewFooter1;
        private Sunny.UI.UIDataGridView dgvimei;
        private Sunny.UI.UISymbolButton uiSymbolButton2;
        private Sunny.UI.UISymbolButton btnimport;
    }
}