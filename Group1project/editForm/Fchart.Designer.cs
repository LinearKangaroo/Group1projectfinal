namespace Group1project.editForm
{
    partial class Fchart
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
            uiPanel1 = new Sunny.UI.UIPanel();
            cbomonth = new Sunny.UI.UIComboBox();
            cboyear = new Sunny.UI.UIComboBox();
            uiLineChart1 = new Sunny.UI.UILineChart();
            pnlBtm.SuspendLayout();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 742);
            pnlBtm.Size = new Size(1598, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(1470, 12);
            // 
            // btnOK
            // 
            btnOK.Location = new Point(1355, 12);
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(cbomonth);
            uiPanel1.Controls.Add(cboyear);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(1, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(1598, 71);
            uiPanel1.TabIndex = 3;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // cbomonth
            // 
            cbomonth.DataSource = null;
            cbomonth.FillColor = Color.White;
            cbomonth.Font = new Font("Microsoft Sans Serif", 12F);
            cbomonth.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cbomonth.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cbomonth.Location = new Point(201, 16);
            cbomonth.Margin = new Padding(4, 5, 4, 5);
            cbomonth.MinimumSize = new Size(63, 0);
            cbomonth.Name = "cbomonth";
            cbomonth.Padding = new Padding(0, 0, 30, 2);
            cbomonth.Size = new Size(172, 39);
            cbomonth.SymbolSize = 24;
            cbomonth.TabIndex = 1;
            cbomonth.TextAlignment = ContentAlignment.MiddleLeft;
            cbomonth.Watermark = "Month";
            // 
            // cboyear
            // 
            cboyear.DataSource = null;
            cboyear.FillColor = Color.White;
            cboyear.Font = new Font("Microsoft Sans Serif", 12F);
            cboyear.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboyear.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboyear.Location = new Point(21, 16);
            cboyear.Margin = new Padding(4, 5, 4, 5);
            cboyear.MinimumSize = new Size(63, 0);
            cboyear.Name = "cboyear";
            cboyear.Padding = new Padding(0, 0, 30, 2);
            cboyear.Size = new Size(172, 39);
            cboyear.SymbolSize = 24;
            cboyear.TabIndex = 0;
            cboyear.TextAlignment = ContentAlignment.MiddleLeft;
            cboyear.Watermark = "Year";
            // 
            // uiLineChart1
            // 
            uiLineChart1.Dock = DockStyle.Fill;
            uiLineChart1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLineChart1.LegendFont = new Font("Microsoft Sans Serif", 9F);
            uiLineChart1.Location = new Point(1, 106);
            uiLineChart1.MinimumSize = new Size(1, 1);
            uiLineChart1.MouseDownType = Sunny.UI.UILineChartMouseDownType.Zoom;
            uiLineChart1.Name = "uiLineChart1";
            uiLineChart1.Size = new Size(1598, 636);
            uiLineChart1.SubFont = new Font("Microsoft Sans Serif", 9F);
            uiLineChart1.TabIndex = 4;
            // 
            // Fchart
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1600, 800);
            Controls.Add(uiLineChart1);
            Controls.Add(uiPanel1);
            Name = "Fchart";
            Text = "Analytic Chart";
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiPanel1, 0);
            Controls.SetChildIndex(uiLineChart1, 0);
            pnlBtm.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIComboBox cbomonth;
        private Sunny.UI.UIComboBox cboyear;
        private Sunny.UI.UILineChart uiLineChart1;
    }
}