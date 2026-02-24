namespace Group1project.Adminchildform
{
    partial class FrmAproduct
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
            txtproduct = new Sunny.UI.UITextBox();
            btnEdit = new Sunny.UI.UISymbolButton();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            uiPanel1 = new Sunny.UI.UIPanel();
            dgvproduct = new Sunny.UI.UIDataGridView();
            uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvproduct).BeginInit();
            SuspendLayout();
            // 
            // txtproduct
            // 
            txtproduct.ButtonSymbol = 361453;
            txtproduct.ButtonSymbolOffset = new Point(0, 1);
            txtproduct.Font = new Font("Microsoft Sans Serif", 12F);
            txtproduct.Location = new Point(29, 31);
            txtproduct.Margin = new Padding(4, 5, 4, 5);
            txtproduct.MinimumSize = new Size(1, 16);
            txtproduct.Name = "txtproduct";
            txtproduct.Padding = new Padding(5);
            txtproduct.ShowButton = true;
            txtproduct.ShowText = false;
            txtproduct.Size = new Size(349, 34);
            txtproduct.TabIndex = 19;
            txtproduct.TextAlignment = ContentAlignment.MiddleLeft;
            txtproduct.Watermark = "SKUname";
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Microsoft Sans Serif", 12F);
            btnEdit.Location = new Point(687, 31);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(121, 34);
            btnEdit.Symbol = 61508;
            btnEdit.TabIndex = 18;
            btnEdit.Text = "Edit";
            btnEdit.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            btnAdd.Location = new Point(543, 31);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(121, 34);
            btnAdd.Symbol = 61543;
            btnAdd.TabIndex = 17;
            btnAdd.Text = "Add";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.Location = new Point(399, 31);
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
            uiPanel1.Controls.Add(txtproduct);
            uiPanel1.Controls.Add(btnEdit);
            uiPanel1.Controls.Add(btnSearch);
            uiPanel1.Controls.Add(btnAdd);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(0, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(836, 93);
            uiPanel1.TabIndex = 20;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // dgvproduct
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvproduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvproduct.BackgroundColor = Color.White;
            dgvproduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvproduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvproduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvproduct.DefaultCellStyle = dataGridViewCellStyle3;
            dgvproduct.Dock = DockStyle.Fill;
            dgvproduct.EnableHeadersVisualStyles = false;
            dgvproduct.Font = new Font("Microsoft Sans Serif", 12F);
            dgvproduct.GridColor = Color.FromArgb(80, 160, 255);
            dgvproduct.Location = new Point(0, 128);
            dgvproduct.Name = "dgvproduct";
            dgvproduct.ReadOnly = true;
            dgvproduct.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvproduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvproduct.RowHeadersWidth = 57;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgvproduct.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvproduct.SelectedIndex = -1;
            dgvproduct.Size = new Size(836, 346);
            dgvproduct.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvproduct.TabIndex = 21;
            // 
            // FrmAproduct
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(836, 474);
            Controls.Add(dgvproduct);
            Controls.Add(uiPanel1);
            Name = "FrmAproduct";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 558149;
            Text = "Product";
            uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvproduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox txtproduct;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIDataGridView dgvproduct;
    }
}