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
            uiLineChart1 = new Sunny.UI.UILineChart();
            pnlBtm.SuspendLayout();
            SuspendLayout();
            // 
            // pnlBtm
            // 
            pnlBtm.Location = new Point(1, 509);
            pnlBtm.Size = new Size(1003, 55);
            // 
            // btnCancel
            // 
            btnCancel.Location = new Point(875, 12);
            // 
            // btnOK
            // 
            btnOK.Location = new Point(760, 12);
            // 
            // uiLineChart1
            // 
            uiLineChart1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLineChart1.LegendFont = new Font("Microsoft Sans Serif", 9F);
            uiLineChart1.Location = new Point(26, 58);
            uiLineChart1.MinimumSize = new Size(1, 1);
            uiLineChart1.MouseDownType = Sunny.UI.UILineChartMouseDownType.Zoom;
            uiLineChart1.Name = "uiLineChart1";
            uiLineChart1.Size = new Size(975, 443);
            uiLineChart1.SubFont = new Font("Microsoft Sans Serif", 9F);
            uiLineChart1.TabIndex = 2;
            uiLineChart1.Text = "uiLineChart1";
            // 
            // Fchart
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1005, 567);
            Controls.Add(uiLineChart1);
            Name = "Fchart";
            Text = "Analytic Chart";
            Controls.SetChildIndex(pnlBtm, 0);
            Controls.SetChildIndex(uiLineChart1, 0);
            pnlBtm.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UILineChart uiLineChart1;
    }
}