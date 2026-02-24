namespace Group1project.Adminchildform
{
    partial class FrmUser
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
            btnSearch = new Sunny.UI.UISymbolButton();
            btnAdd = new Sunny.UI.UISymbolButton();
            btnEdit = new Sunny.UI.UISymbolButton();
            txtuser = new Sunny.UI.UITextBox();
            uiPanel1 = new Sunny.UI.UIPanel();
            dgvuser = new Sunny.UI.UIDataGridView();
            uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvuser).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Font = new Font("Microsoft Sans Serif", 12F);
            btnSearch.Location = new Point(394, 44);
            btnSearch.MinimumSize = new Size(1, 1);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(121, 34);
            btnSearch.Symbol = 61442;
            btnSearch.TabIndex = 11;
            btnSearch.Text = "Search";
            btnSearch.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            btnAdd.Location = new Point(533, 44);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(121, 34);
            btnAdd.Symbol = 61543;
            btnAdd.TabIndex = 12;
            btnAdd.Text = "Add";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnEdit
            // 
            btnEdit.Font = new Font("Microsoft Sans Serif", 12F);
            btnEdit.Location = new Point(679, 44);
            btnEdit.MinimumSize = new Size(1, 1);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(121, 34);
            btnEdit.Symbol = 61508;
            btnEdit.TabIndex = 13;
            btnEdit.Text = "Edit";
            btnEdit.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // txtuser
            // 
            txtuser.ButtonSymbol = 361453;
            txtuser.ButtonSymbolOffset = new Point(0, 1);
            txtuser.Font = new Font("Microsoft Sans Serif", 12F);
            txtuser.Location = new Point(20, 44);
            txtuser.Margin = new Padding(4, 5, 4, 5);
            txtuser.MinimumSize = new Size(1, 16);
            txtuser.Name = "txtuser";
            txtuser.Padding = new Padding(5);
            txtuser.ShowButton = true;
            txtuser.ShowText = false;
            txtuser.Size = new Size(349, 34);
            txtuser.TabIndex = 14;
            txtuser.TextAlignment = ContentAlignment.MiddleLeft;
            txtuser.Watermark = "Username";
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(txtuser);
            uiPanel1.Controls.Add(btnEdit);
            uiPanel1.Controls.Add(btnSearch);
            uiPanel1.Controls.Add(btnAdd);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(0, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(840, 101);
            uiPanel1.TabIndex = 15;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // dgvuser
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            dgvuser.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvuser.BackgroundColor = Color.White;
            dgvuser.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvuser.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvuser.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            dgvuser.DefaultCellStyle = dataGridViewCellStyle3;
            dgvuser.Dock = DockStyle.Fill;
            dgvuser.EnableHeadersVisualStyles = false;
            dgvuser.Font = new Font("Microsoft Sans Serif", 12F);
            dgvuser.GridColor = Color.FromArgb(80, 160, 255);
            dgvuser.Location = new Point(0, 136);
            dgvuser.Name = "dgvuser";
            dgvuser.ReadOnly = true;
            dgvuser.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            dgvuser.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            dgvuser.RowHeadersWidth = 57;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            dgvuser.RowsDefaultCellStyle = dataGridViewCellStyle5;
            dgvuser.SelectedIndex = -1;
            dgvuser.Size = new Size(840, 331);
            dgvuser.StripeOddColor = Color.FromArgb(235, 243, 255);
            dgvuser.TabIndex = 16;
            // 
            // FrmUser
            // 
            AllowShowTitle = true;
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(840, 467);
            Controls.Add(dgvuser);
            Controls.Add(uiPanel1);
            Name = "FrmUser";
            Padding = new Padding(0, 35, 0, 0);
            ShowTitle = true;
            Symbol = 61447;
            Text = "User";
            uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvuser).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UISymbolButton btnSearch;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UISymbolButton btnEdit;
        private Sunny.UI.UITextBox txtuser;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIDataGridView dgvuser;
    }
}