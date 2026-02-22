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
            uiSmoothLabel1 = new Sunny.UI.UISmoothLabel();
            uiPanel1 = new Sunny.UI.UIPanel();
            btnlogout = new Sunny.UI.UIButton();
            btnsetting = new Sunny.UI.UIButton();
            uiNavMenu1 = new Sunny.UI.UINavMenu();
            uiTabControl1 = new Sunny.UI.UITabControl();
            uiPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // uiSmoothLabel1
            // 
            uiSmoothLabel1.Font = new Font("Microsoft Sans Serif", 18.2686558F, FontStyle.Regular, GraphicsUnit.Point, 0);
            uiSmoothLabel1.Location = new Point(3, 20);
            uiSmoothLabel1.Name = "uiSmoothLabel1";
            uiSmoothLabel1.Size = new Size(566, 50);
            uiSmoothLabel1.TabIndex = 0;
            uiSmoothLabel1.Text = "Sales and Inventory Analysis System";
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(btnlogout);
            uiPanel1.Controls.Add(btnsetting);
            uiPanel1.Controls.Add(uiSmoothLabel1);
            uiPanel1.Dock = DockStyle.Top;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(0, 35);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(1132, 80);
            uiPanel1.TabIndex = 4;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnlogout
            // 
            btnlogout.Font = new Font("Microsoft Sans Serif", 12F);
            btnlogout.Location = new Point(990, 21);
            btnlogout.MinimumSize = new Size(1, 1);
            btnlogout.Name = "btnlogout";
            btnlogout.Size = new Size(126, 40);
            btnlogout.TabIndex = 2;
            btnlogout.Text = "Logout";
            btnlogout.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnsetting
            // 
            btnsetting.Font = new Font("Microsoft Sans Serif", 12F);
            btnsetting.Location = new Point(858, 21);
            btnsetting.MinimumSize = new Size(1, 1);
            btnsetting.Name = "btnsetting";
            btnsetting.Size = new Size(126, 40);
            btnsetting.TabIndex = 1;
            btnsetting.Text = "Setting";
            btnsetting.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiNavMenu1
            // 
            uiNavMenu1.BorderStyle = BorderStyle.None;
            uiNavMenu1.Dock = DockStyle.Left;
            uiNavMenu1.DrawMode = TreeViewDrawMode.OwnerDrawAll;
            uiNavMenu1.Font = new Font("Microsoft Sans Serif", 12F);
            uiNavMenu1.FullRowSelect = true;
            uiNavMenu1.HotTracking = true;
            uiNavMenu1.ItemHeight = 50;
            uiNavMenu1.Location = new Point(0, 115);
            uiNavMenu1.Name = "uiNavMenu1";
            uiNavMenu1.ShowLines = false;
            uiNavMenu1.ShowPlusMinus = false;
            uiNavMenu1.ShowRootLines = false;
            uiNavMenu1.Size = new Size(211, 731);
            uiNavMenu1.TabIndex = 5;
            uiNavMenu1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiTabControl1
            // 
            uiTabControl1.Dock = DockStyle.Fill;
            uiTabControl1.DrawMode = TabDrawMode.OwnerDrawFixed;
            uiTabControl1.Font = new Font("Microsoft Sans Serif", 12F);
            uiTabControl1.Frame = this;
            uiTabControl1.ItemSize = new Size(0, 1);
            uiTabControl1.Location = new Point(211, 115);
            uiTabControl1.MainPage = "";
            uiTabControl1.Name = "uiTabControl1";
            uiTabControl1.SelectedIndex = 0;
            uiTabControl1.Size = new Size(921, 731);
            uiTabControl1.SizeMode = TabSizeMode.Fixed;
            uiTabControl1.TabIndex = 6;
            uiTabControl1.TabUnSelectedForeColor = Color.FromArgb(240, 240, 240);
            uiTabControl1.TabVisible = false;
            uiTabControl1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // FrmAdminMain
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1132, 846);
            Controls.Add(uiTabControl1);
            Controls.Add(uiNavMenu1);
            Controls.Add(uiPanel1);
            ExtendBox = true;
            IconImage = (Image)resources.GetObject("$this.IconImage");
            MainTabControl = uiTabControl1;
            Name = "FrmAdminMain";
            Text = "Admin";
            ZoomScaleRect = new Rectangle(21, 21, 800, 450);
            uiPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISmoothLabel uiSmoothLabel1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIButton btnlogout;
        private Sunny.UI.UIButton btnsetting;
        private Sunny.UI.UINavMenu uiNavMenu1;
        private Sunny.UI.UITabControl uiTabControl1;
    }
}