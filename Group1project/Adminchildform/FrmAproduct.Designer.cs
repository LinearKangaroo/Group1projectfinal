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
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle9 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle10 = new DataGridViewCellStyle();
            txtproduct = new Sunny.UI.UITextBox();
            btnEdit = new Sunny.UI.UISymbolButton();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnSearch = new Sunny.UI.UISymbolButton();
            dgvproduct = new Sunny.UI.UIDataGridView();
            ((System.ComponentModel.ISupportInitialize)dgvproduct).BeginInit();
            SuspendLayout();
            // 
            // txtproduct
            // 
            txtproduct.ButtonSymbol = 361453;
            txtproduct.ButtonSymbolOffset = new Point(0, 1);
            txtproduct.Font = new Font("Microsoft Sans Serif", 12F);
            txtproduct.Location = new Point(19, 415);
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
            btnEdit.Location = new Point(692, 415);
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
            btnAdd.Location = new Point(548, 415);
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
            btnSearch.Location = new Point(404, 415);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 34);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 16;
            btnSearch.Text = "Search";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // dgvproduct
            // 
            dataGridViewCellStyle6.BackColor = Color.FromArgb(235, 243, 255);
            dgvproduct.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle6;
            dgvproduct.BackgroundColor = Color.White;
            dgvproduct.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle7.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle7.ForeColor = Color.White;
            dataGridViewCellStyle7.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = DataGridViewTriState.True;
            dgvproduct.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            dgvproduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = SystemColors.Window;
            dataGridViewCellStyle8.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle8.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle8.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = DataGridViewTriState.False;
            dgvproduct.DefaultCellStyle = dataGridViewCellStyle8;
            dgvproduct.Dock = DockStyle.Top;
            dgvproduct.EnableHeadersVisualStyles = false;
            dgvproduct.Font = new Font("Microsoft Sans Serif", 12F);
            dgvproduct.GridColor = Color.FromArgb(80, 160, 255);
            dgvproduct.Location = new Point(0, 35);
            dgvproduct.Name = "dgvproduct";
            dgvproduct.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle9.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle9.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle9.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle9.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle9.SelectionForeColor = Color.White;
            dataGridViewCellStyle9.WrapMode = DataGridViewTriState.True;
            dgvproduct.RowHeadersDefaultCellStyle = dataGridViewCellStyle9;
            dgvproduct.RowHeadersWidth = 57;
            dataGridViewCellStyle10.BackColor = Color.White;
            dataGridViewCellStyle10.Font = new Font("Microsoft Sans Serif", 12F);
            dgvproduct.RowsDefaultCellStyle = dataGridViewCellStyle10;
            dgvproduct.SelectedIndex = -1;
            dgvproduct.Size = new Size(836, 360);
            dgvproduct.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvproduct.TabIndex = 15;
            // 
            // FrmAproduct
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(836, 474);
            Controls.Add(txtproduct);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(btnSearch);
            Controls.Add(dgvproduct);
            Name = "FrmAproduct";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 558149;
            Text = "Product Management";
            ((System.ComponentModel.ISupportInitialize)dgvproduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox txtproduct;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UIDataGridView dgvproduct;
    }
}