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
            txtstatus = new Sunny.UI.UITextBox();
            txtimei = new Sunny.UI.UITextBox();
            uiLabel2 = new Sunny.UI.UILabel();
            uiLabel1 = new Sunny.UI.UILabel();
            txtskucode = new Sunny.UI.UITextBox();
            uiLabel4 = new Sunny.UI.UILabel();
            btnimport = new Sunny.UI.UISymbolButton();
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
            btnOK.Location = new Point(227, 12);
            btnOK.Size = new Size(125, 35);
            btnOK.Text = "Confrim";
            // 
            // txtstatus
            // 
            txtstatus.Font = new Font("Microsoft Sans Serif", 12F);
            txtstatus.Location = new Point(187, 106);
            txtstatus.Margin = new Padding(4, 5, 4, 5);
            txtstatus.MinimumSize = new Size(1, 16);
            txtstatus.Name = "txtstatus";
            txtstatus.Padding = new Padding(5);
            txtstatus.ShowText = false;
            txtstatus.Size = new Size(254, 35);
            txtstatus.TabIndex = 12;
            txtstatus.TextAlignment = ContentAlignment.MiddleLeft;
            txtstatus.Watermark = "";
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
            uiLabel2.Location = new Point(41, 113);
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
            // txtskucode
            // 
            txtskucode.Font = new Font("Microsoft Sans Serif", 12F);
            txtskucode.Location = new Point(187, 151);
            txtskucode.Margin = new Padding(4, 5, 4, 5);
            txtskucode.MinimumSize = new Size(1, 16);
            txtskucode.Name = "txtskucode";
            txtskucode.Padding = new Padding(5);
            txtskucode.ShowText = false;
            txtskucode.Size = new Size(254, 35);
            txtskucode.TabIndex = 15;
            txtskucode.TextAlignment = ContentAlignment.MiddleLeft;
            txtskucode.Watermark = "";
            // 
            // uiLabel4
            // 
            uiLabel4.Font = new Font("Microsoft Sans Serif", 12F);
            uiLabel4.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel4.Location = new Point(41, 149);
            uiLabel4.Name = "uiLabel4";
            uiLabel4.Size = new Size(126, 39);
            uiLabel4.TabIndex = 13;
            uiLabel4.Text = "SKUcode";
            // 
            // btnimport
            // 
            btnimport.Font = new Font("Microsoft Sans Serif", 12F);
            btnimport.Location = new Point(272, 194);
            btnimport.MinimumSize = new Size(1, 1);
            btnimport.Name = "btnimport";
            btnimport.Size = new Size(169, 34);
            btnimport.Symbol = 61717;
            btnimport.TabIndex = 16;
            btnimport.Text = "Import";
            btnimport.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // Fimei
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(496, 297);
            Controls.Add(btnimport);
            Controls.Add(txtskucode);
            Controls.Add(uiLabel4);
            Controls.Add(txtstatus);
            Controls.Add(txtimei);
            Controls.Add(uiLabel2);
            Controls.Add(uiLabel1);
            Name = "Fimei";
            Text = "IMEI";
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLabel1, 0);
            Controls.SetChildIndex(uiLabel2, 0);
            Controls.SetChildIndex(txtimei, 0);
            Controls.SetChildIndex(txtstatus, 0);
            Controls.SetChildIndex(uiLabel4, 0);
            Controls.SetChildIndex(txtskucode, 0);
            Controls.SetChildIndex(btnimport, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UITextBox txtstatus;
        private Sunny.UI.UITextBox txtimei;
        private Sunny.UI.UILabel uiLabel2;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UITextBox txtskucode;
        private Sunny.UI.UILabel uiLabel4;
        private Sunny.UI.UISymbolButton btnimport;
    }
}