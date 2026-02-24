namespace Group1project.editForm
{
    partial class Fimei
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
            txtimei = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            uiLabel4 = new Sunny.UI.UILabel();
            cbostatus = new Sunny.UI.UIComboBox();
            cboskucode = new Sunny.UI.UIComboDataGridView();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 239);
            pnlBtm.Size = new Size(494, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(366, 12);
            btnCancel.Text = "Cancel";
            // 
            // btnOK
            // 
            btnOK.Location = new Point(251, 12);
            btnOK.Size = new Size(125, 35);
            btnOK.Text = "Confrim";
            // 
            // txtimei
            // 
            txtimei.Font = new Font("Microsoft Sans Serif", 12F);
            txtimei.Location = new Point(187, 61);
            txtimei.Margin = new Padding(4, 5, 4, 5);
            txtimei.MinimumSize = new Size(1, 16);
            txtimei.Name = "txtimei";
            txtimei.Padding = new Padding(5);
            txtimei.ShowText = false;
            txtimei.Size = new Size(254, 35);
            txtimei.TabIndex = 11;
            txtimei.TextAlignment = ContentAlignment.MiddleLeft;
            txtimei.Watermark = "";
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(41, 109);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(126, 39);
            uiLabel2.TabIndex = 10;
            uiLabel2.Text = "Status";
            // 
            // uiLabel1
            // 
            uiLabel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(41, 59);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(126, 39);
            uiLabel1.TabIndex = 9;
            uiLabel1.Text = "IMEI";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(41, 165);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(126, 39);
            uiLabel4.TabIndex = 13;
            uiLabel4.Text = "SKUcode";
            // 
            // cbostatus
            // 
            cbostatus.DataSource = null;
            cbostatus.FillColor = Color.White;
            cbostatus.Font = new Font("Microsoft Sans Serif", 12F);
            cbostatus.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbostatus.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbostatus.Location = new Point(187, 109);
            cbostatus.Margin = new Padding(4, 5, 4, 5);
            cbostatus.MinimumSize = new Size(63, 0);
            cbostatus.Name = "cbostatus";
            cbostatus.Padding = new Padding(0, 0, 30, 2);
            cbostatus.Size = new Size(255, 34);
            cbostatus.SymbolSize = 24;
            cbostatus.TabIndex = 17;
            cbostatus.TextAlignment = ContentAlignment.MiddleLeft;
            cbostatus.Watermark = "";
            // 
            // cboskucode
            // 
            cboskucode.DropDownStyle = Sunny.UI.UIDropDownStyle.DropDownList;
            cboskucode.FillColor = Color.White;
            cboskucode.Font = new Font("Microsoft Sans Serif", 12F);
            cboskucode.Location = new Point(187, 165);
            cboskucode.Margin = new Padding(4, 5, 4, 5);
            cboskucode.MinimumSize = new Size(63, 0);
            cboskucode.Name = "cboskucode";
            cboskucode.Padding = new Padding(0, 0, 30, 2);
            cboskucode.Size = new Size(255, 39);
            cboskucode.SymbolSize = 24;
            cboskucode.TabIndex = 18;
            cboskucode.TextAlignment = ContentAlignment.MiddleLeft;
            cboskucode.Watermark = "";
            // 
            // Fimei
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(496, 297);
            Controls.Add(cboskucode);
            Controls.Add(cbostatus);
            Controls.Add(uiLabel4);
            Controls.Add(txtimei);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Name = "Fimei";
            Text = "IMEI Edit";
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(txtimei, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(cbostatus, 0);
            Controls.SetChildIndex(cboskucode, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UITextBox txtimei;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UIComboBox cbostatus;
        private Sunny.UI.UIComboDataGridView cboskucode;
    }
}