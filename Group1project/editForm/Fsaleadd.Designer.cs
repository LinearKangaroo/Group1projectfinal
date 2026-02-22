namespace Group1project.editForm
{
    partial class Fsaleadd
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
            uiPanel1 = new Sunny.UI.UIPanel();
            btnAdd = new Sunny.UI.UISymbolButton();
            cbopayment = new Sunny.UI.UIComboBox();
            uiLabel5 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            uiLabel3 = new Sunny.UI.UILabel();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            txtimei = new Sunny.UI.UITextBox();
            txtsales = new Sunny.UI.UITextBox();
            txtdate = new Sunny.UI.UITextBox();
            txtinvoice = new Sunny.UI.UITextBox();
            uiMarkLabel1 = new Sunny.UI.UIMarkLabel();
            uiMarkLabel2 = new Sunny.UI.UIMarkLabel();
            uiDataGridViewFooter1 = new Sunny.UI.UIDataGridViewFooter();
            uiDataGridView1 = new Sunny.UI.UIDataGridView();
            pnlBtm.SuspendLayout();
            uiPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).BeginInit();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Controls.Add(uiMarkLabel2);
            pnlBtm.Controls.Add(uiMarkLabel1);
            pnlBtm.Location = new Point(1, 619);
            pnlBtm.Size = new Size(948, 55);
            pnlBtm.Controls.SetChildIndex(uiMarkLabel1, 0);
            pnlBtm.Controls.SetChildIndex(btnOK, 0);
            pnlBtm.Controls.SetChildIndex(btnCancel, 0);
            pnlBtm.Controls.SetChildIndex(uiMarkLabel2, 0);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(820, 12);
            btnCancel.Size = new Size(101, 35);
            btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(705, 12);
            btnOK.Size = new Size(127, 35);
            btnOK.Text = "Confirm";
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(btnAdd);
            uiPanel1.Controls.Add(cbopayment);
            uiPanel1.Controls.Add(uiLabel5);
            uiPanel1.Controls.Add(uiLabel4);
            uiPanel1.Controls.Add(uiLabel3);
            uiPanel1.Controls.Add(uiLabel2);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.Controls.Add(txtimei);
            uiPanel1.Controls.Add(txtsales);
            uiPanel1.Controls.Add(txtdate);
            uiPanel1.Controls.Add(txtinvoice);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(1, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(948, 186);
            uiPanel1.TabIndex = 2;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnAdd
            // 
            btnAdd.Font = new Font("Microsoft Sans Serif", 12F);
            btnAdd.Location = new Point(773, 140);
            btnAdd.MinimumSize = new Size(1, 1);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(121, 34);
            btnAdd.Symbol = 61543;
            btnAdd.TabIndex = 18;
            btnAdd.Text = "Add";
            btnAdd.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // cbopayment
            // 
            cbopayment.DataSource = null;
            cbopayment.FillColor = Color.White;
            cbopayment.Font = new Font("Microsoft Sans Serif", 12F);
            cbopayment.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbopayment.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbopayment.Location = new Point(721, 84);
            cbopayment.Margin = new Padding(4, 5, 4, 5);
            cbopayment.MinimumSize = new Size(63, 0);
            cbopayment.Name = "cbopayment";
            cbopayment.Padding = new Padding(0, 0, 30, 2);
            cbopayment.Size = new Size(173, 37);
            cbopayment.SymbolSize = 24;
            cbopayment.TabIndex = 9;
            cbopayment.TextAlignment = ContentAlignment.MiddleLeft;
            cbopayment.Watermark = "";
            // 
            // uiLabel5
            // 
            uiLabel5.BackColor = Color.Transparent;
            uiLabel5.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel5.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel5.Location = new Point(606, 86);
            uiLabel5.Name = "uiLabel5";
            uiLabel5.Size = new Size(108, 28);
            uiLabel5.TabIndex = 8;
            uiLabel5.Text = "Payment";
            // 
            // uiLabel4
            // 
            uiLabel4.BackColor = Color.Transparent;
            uiLabel4.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(3, 86);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(85, 28);
            uiLabel4.TabIndex = 7;
            uiLabel4.Text = "IMEI";
            // 
            // uiLabel3
            // 
            uiLabel3.BackColor = Color.Transparent;
            uiLabel3.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel3.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel3.Location = new Point(606, 23);
            uiLabel3.Name = "uiLabel3";
            uiLabel3.Size = new Size(85, 28);
            uiLabel3.TabIndex = 6;
            uiLabel3.Text = "Sales";
            // 
            // uiLabel2
            // 
            uiLabel2.BackColor = Color.Transparent;
            uiLabel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(314, 23);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(77, 28);
            uiLabel2.TabIndex = 5;
            uiLabel2.Text = "Date";
            // 
            // uiLabel1
            // 
            uiLabel1.BackColor = Color.Transparent;
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(3, 23);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(103, 28);
            uiLabel1.TabIndex = 4;
            uiLabel1.Text = "Invoice";
            // 
            // txtimei
            // 
            txtimei.Font = new Font("Microsoft Sans Serif", 12F);
            txtimei.Location = new Point(106, 86);
            txtimei.Margin = new Padding(4, 5, 4, 5);
            txtimei.MinimumSize = new Size(1, 16);
            txtimei.Name = "txtimei";
            txtimei.Padding = new Padding(5);
            txtimei.ShowText = false;
            txtimei.Size = new Size(493, 88);
            txtimei.TabIndex = 3;
            txtimei.TextAlignment = ContentAlignment.MiddleLeft;
            txtimei.Watermark = "";
            // 
            // txtsales
            // 
            txtsales.Font = new Font("Microsoft Sans Serif", 12F);
            txtsales.Location = new Point(698, 21);
            txtsales.Margin = new Padding(4, 5, 4, 5);
            txtsales.MinimumSize = new Size(1, 16);
            txtsales.Name = "txtsales";
            txtsales.Padding = new Padding(5);
            txtsales.ShowText = false;
            txtsales.Size = new Size(201, 35);
            txtsales.TabIndex = 3;
            txtsales.TextAlignment = ContentAlignment.MiddleLeft;
            txtsales.Watermark = "";
            // 
            // txtdate
            // 
            txtdate.Font = new Font("Microsoft Sans Serif", 12F);
            txtdate.Location = new Point(398, 21);
            txtdate.Margin = new Padding(4, 5, 4, 5);
            txtdate.MinimumSize = new Size(1, 16);
            txtdate.Name = "txtdate";
            txtdate.Padding = new Padding(5);
            txtdate.ShowText = false;
            txtdate.Size = new Size(201, 35);
            txtdate.TabIndex = 3;
            txtdate.TextAlignment = ContentAlignment.MiddleLeft;
            txtdate.Watermark = "";
            // 
            // txtinvoice
            // 
            txtinvoice.Font = new Font("Microsoft Sans Serif", 12F);
            txtinvoice.Location = new Point(106, 21);
            txtinvoice.Margin = new Padding(4, 5, 4, 5);
            txtinvoice.MinimumSize = new Size(1, 16);
            txtinvoice.Name = "txtinvoice";
            txtinvoice.Padding = new Padding(5);
            txtinvoice.ShowText = false;
            txtinvoice.Size = new Size(201, 35);
            txtinvoice.TabIndex = 0;
            txtinvoice.TextAlignment = ContentAlignment.MiddleLeft;
            txtinvoice.Watermark = "";
            // 
            // uiMarkLabel1
            // 
            uiMarkLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel1.Location = new Point(36, 12);
            uiMarkLabel1.Name = "uiMarkLabel1";
            uiMarkLabel1.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel1.Size = new Size(150, 34);
            uiMarkLabel1.TabIndex = 2;
            uiMarkLabel1.Text = "items";
            // 
            // uiMarkLabel2
            // 
            uiMarkLabel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiMarkLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiMarkLabel2.Location = new Point(217, 12);
            uiMarkLabel2.Name = "uiMarkLabel2";
            uiMarkLabel2.Padding = new Padding(5, 0, 0, 0);
            uiMarkLabel2.Size = new Size(211, 34);
            uiMarkLabel2.TabIndex = 3;
            uiMarkLabel2.Text = "Total Amount";
            // 
            // uiDataGridViewFooter1
            // 
            uiDataGridViewFooter1.DataGridView = null;
            uiDataGridViewFooter1.Dock = DockStyle.Bottom;
            uiDataGridViewFooter1.Font = new Font("Microsoft Sans Serif", 12F);
            uiDataGridViewFooter1.Location = new Point(1, 583);
            uiDataGridViewFooter1.MinimumSize = new Size(1, 1);
            uiDataGridViewFooter1.Name = "uiDataGridViewFooter1";
            uiDataGridViewFooter1.RadiusSides = Sunny.UI.UICornerRadiusSides.None;
            uiDataGridViewFooter1.Size = new Size(948, 36);
            uiDataGridViewFooter1.TabIndex = 4;
            uiDataGridViewFooter1.Text = "uiDataGridViewFooter1";
            // 
            // uiDataGridView1
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            uiDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            uiDataGridView1.BackgroundColor = Color.White;
            uiDataGridView1.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            uiDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            uiDataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            uiDataGridView1.DefaultCellStyle = dataGridViewCellStyle3;
            uiDataGridView1.Dock = DockStyle.Fill;
            uiDataGridView1.EnableHeadersVisualStyles = false;
            uiDataGridView1.Font = new Font("Microsoft Sans Serif", 12F);
            uiDataGridView1.GridColor = Color.FromArgb(80, 160, 255);
            uiDataGridView1.Location = new Point(1, 221);
            uiDataGridView1.Name = "uiDataGridView1";
            uiDataGridView1.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            uiDataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            uiDataGridView1.RowHeadersWidth = 57;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            uiDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle5;
            uiDataGridView1.SelectedIndex = -1;
            uiDataGridView1.Size = new Size(948, 362);
            uiDataGridView1.StripeOddColor = Color.FromArgb(235, 243, 255);
            uiDataGridView1.TabIndex = 5;
            // 
            // Fsaleadd
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(950, 677);
            Controls.Add(uiDataGridView1);
            Controls.Add(uiDataGridViewFooter1);
            Controls.Add(uiPanel1);
            Name = "Fsaleadd";
            Text = "Sales Transaction";
            Controls.SetChildIndex(uiPanel1, 0);
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiDataGridViewFooter1, 0);
            Controls.SetChildIndex(uiDataGridView1, 0);
            pnlBtm.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)uiDataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UITextBox txtinvoice;
        private Sunny.UI.UILabel uiLabel5;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UILabel uiLabel3;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtimei;
        private Sunny.UI.UITextBox txtsales;
        private Sunny.UI.UITextBox txtdate;
        private Sunny.UI.UIComboBox cbopayment;
        private Sunny.UI.UIMarkLabel uiMarkLabel2;
        private Sunny.UI.UIMarkLabel uiMarkLabel1;
        private Sunny.UI.UISymbolButton btnAdd;
        private Sunny.UI.UIDataGridViewFooter uiDataGridViewFooter1;
        private Sunny.UI.UIDataGridView uiDataGridView1;
    }
}