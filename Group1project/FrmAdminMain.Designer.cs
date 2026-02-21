namespace Group1project
{
    partial class FrmAdminMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdminMain));
            uiNavBar1 = new Sunny.UI.UINavBar();
            uiNavMenu1 = new Sunny.UI.UINavMenu();
            uiTabControl1 = new Sunny.UI.UITabControl();
            uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            uiNavBar1.SuspendLayout();
            SuspendLayout();
            // 
            // uiNavBar1
            // 
            uiNavBar1.BackColor = Color.White;
            uiNavBar1.Controls.Add(uiSmoothLabel1);
            uiNavBar1.Dock = DockStyle.Top;
            uiNavBar1.DropMenuFont = new Font("Microsoft Sans Serif", 12F);
            uiNavBar1.Font = new Font("Microsoft Sans Serif", 12F);
            uiNavBar1.Location = new Point(0, 35);
            uiNavBar1.MenuStyle = Sunny.UI.UIMenuStyle.Custom;
            uiNavBar1.Name = "uiNavBar1";
            uiNavBar1.Size = new Size(1132, 59);
            uiNavBar1.TabIndex = 1;
            uiNavBar1.Text = "uiNavBar1";
            // 
            // uiNavMenu1
            // 
            uiNavMenu1.BorderStyle = BorderStyle.None;
            uiNavMenu1.Dock = DockStyle.Left;
            uiNavMenu1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            uiNavMenu1.Font = new Font("SimSun", 12F);
            uiNavMenu1.FullRowSelect = true;
            uiNavMenu1.HotTracking = true;
            uiNavMenu1.ItemHeight = 50;
            uiNavMenu1.Location = new Point(0, 94);
            uiNavMenu1.Name = "uiNavMenu1";
            uiNavMenu1.ShowLines = false;
            uiNavMenu1.ShowPlusMinus = false;
            uiNavMenu1.ShowRootLines = false;
            uiNavMenu1.Size = new Size(178, 752);
            uiNavMenu1.TabIndex = 3;
            uiNavMenu1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiTabControl1
            // 
            uiTabControl1.Dock = DockStyle.Fill;
            uiTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            uiTabControl1.Font = new Font("Microsoft Sans Serif", 12F);
            uiTabControl1.Frame = this;
            uiTabControl1.ItemSize = new Size(0, 1);
            uiTabControl1.Location = new Point(178, 94);
            uiTabControl1.MainPage = "";
            uiTabControl1.Name = "uiTabControl1";
            uiTabControl1.SelectedIndex = 0;
            uiTabControl1.Size = new Size(954, 752);
            uiTabControl1.SizeMode = TabSizeMode.Fixed;
            uiTabControl1.TabIndex = 4;
            uiTabControl1.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
            uiTabControl1.TabVisible = false;
            uiTabControl1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiSmoothLabel1
            // 
            uiSmoothLabel1.Font = new Font("Microsoft Sans Serif", 18.2686558F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uiSmoothLabel1.Location = new Point(3, 6);
            uiSmoothLabel1.Name = "uiSmoothLabel1";
            uiSmoothLabel1.Size = new Size(566, 50);
            uiSmoothLabel1.TabIndex = 0;
            uiSmoothLabel1.Text = "Sales and Inventory Analysis System";
            // 
            // FrmAdminMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1132, 846);
            Controls.Add(uiTabControl1);
            Controls.Add(uiNavMenu1);
            Controls.Add(uiNavBar1);
            ExtendBox = true;
            IconImage = (Image)resources.GetObject("$this.IconImage");
            MainTabControl = uiTabControl1;
            Name = "FrmAdminMain";
            Text = "Admin";
            ZoomScaleRect = new Rectangle(21, 21, 800, 450);
            uiNavBar1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Sunny.UI.UINavBar uiNavBar1;
        private Sunny.UI.UINavMenu uiNavMenu1;
        private Sunny.UI.UITabControl uiTabControl1;
        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
    }
}