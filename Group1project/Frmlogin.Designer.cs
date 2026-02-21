namespace Group1project
{
    partial class Frmlogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Frmlogin));
            uiPanel1 = new Sunny.UI.UIPanel();
            uiLine1 = new Sunny.UI.UILine();
            btnClear = new Sunny.UI.UISymbolButton();
            btnLogin = new Sunny.UI.UISymbolButton();
            txtPassword = new Sunny.UI.UITextBox();
            txtUsername = new Sunny.UI.UITextBox();
            uiRadioButtonGroup1 = new Sunny.UI.UIRadioButtonGroup();
            rdouser = new Sunny.UI.UIRadioButton();
            rdoadmin = new Sunny.UI.UIRadioButton();
            pictureBox1 = new PictureBox();
            uiPanel1.SuspendLayout();
            uiRadioButtonGroup1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // uiPanel1
            // 
            uiPanel1.Controls.Add(uiLine1);
            uiPanel1.Controls.Add(btnClear);
            uiPanel1.Controls.Add(btnLogin);
            uiPanel1.Controls.Add(txtPassword);
            uiPanel1.Controls.Add(txtUsername);
            uiPanel1.Controls.Add(uiRadioButtonGroup1);
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel1.Location = new Point(427, 50);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.Size = new Size(323, 373);
            uiPanel1.TabIndex = 0;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLine1
            // 
            uiLine1.BackColor = Color.Transparent;
            uiLine1.Font = new Font("Microsoft Sans Serif", 12F);
            uiLine1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLine1.Location = new Point(18, 16);
            uiLine1.MinimumSize = new Size(1, 1);
            uiLine1.Name = "uiLine1";
            uiLine1.Size = new Size(286, 35);
            uiLine1.TabIndex = 6;
            uiLine1.Text = "Login to System";
            // 
            // btnClear
            // 
            btnClear.FillColor = Color.FromArgb(230, 80, 80);
            btnClear.FillColor2 = Color.FromArgb(230, 80, 80);
            btnClear.FillHoverColor = Color.FromArgb(235, 115, 115);
            btnClear.FillPressColor = Color.FromArgb(184, 64, 64);
            btnClear.FillSelectedColor = Color.FromArgb(184, 64, 64);
            btnClear.Font = new Font("Microsoft Sans Serif", 12F);
            btnClear.LightColor = Color.FromArgb(253, 243, 243);
            btnClear.Location = new Point(185, 307);
            btnClear.MinimumSize = new Size(1, 1);
            btnClear.Name = "btnClear";
            btnClear.RectColor = Color.FromArgb(230, 80, 80);
            btnClear.RectHoverColor = Color.FromArgb(235, 115, 115);
            btnClear.RectPressColor = Color.FromArgb(184, 64, 64);
            btnClear.RectSelectedColor = Color.FromArgb(184, 64, 64);
            btnClear.Size = new Size(119, 47);
            btnClear.Style = Sunny.UI.UIStyle.Custom;
            btnClear.Symbol = 361453;
            btnClear.TabIndex = 5;
            btnClear.Text = "Clear";
            btnClear.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnLogin
            // 
            btnLogin.FillColor = Color.FromArgb(110, 190, 40);
            btnLogin.FillColor2 = Color.FromArgb(110, 190, 40);
            btnLogin.FillHoverColor = Color.FromArgb(139, 203, 83);
            btnLogin.FillPressColor = Color.FromArgb(88, 152, 32);
            btnLogin.FillSelectedColor = Color.FromArgb(88, 152, 32);
            btnLogin.Font = new Font("Microsoft Sans Serif", 12F);
            btnLogin.LightColor = Color.FromArgb(245, 251, 241);
            btnLogin.Location = new Point(28, 307);
            btnLogin.MinimumSize = new Size(1, 1);
            btnLogin.Name = "btnLogin";
            btnLogin.RectColor = Color.FromArgb(110, 190, 40);
            btnLogin.RectHoverColor = Color.FromArgb(139, 203, 83);
            btnLogin.RectPressColor = Color.FromArgb(88, 152, 32);
            btnLogin.RectSelectedColor = Color.FromArgb(88, 152, 32);
            btnLogin.Size = new Size(119, 47);
            btnLogin.Style = Sunny.UI.UIStyle.Custom;
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Login";
            btnLogin.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft Sans Serif", 12F);
            txtPassword.Location = new Point(27, 226);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.MinimumSize = new Size(1, 16);
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(5);
            txtPassword.PasswordChar = '*';
            txtPassword.ShowText = false;
            txtPassword.Size = new Size(277, 45);
            txtPassword.Symbol = 361475;
            txtPassword.TabIndex = 3;
            txtPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtPassword.Watermark = "Password";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 12F);
            txtUsername.Location = new Point(27, 158);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.MinimumSize = new Size(1, 16);
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(5);
            txtUsername.ShowText = false;
            txtUsername.Size = new Size(277, 45);
            txtUsername.Symbol = 361447;
            txtUsername.TabIndex = 1;
            txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
            txtUsername.Watermark = "Username";
            // 
            // uiRadioButtonGroup1
            // 
            uiRadioButtonGroup1.Controls.Add(rdouser);
            uiRadioButtonGroup1.Controls.Add(rdoadmin);
            uiRadioButtonGroup1.Font = new Font("Microsoft Sans Serif", 12F);
            uiRadioButtonGroup1.Location = new Point(23, 66);
            uiRadioButtonGroup1.Margin = new Padding(4, 5, 4, 5);
            uiRadioButtonGroup1.MinimumSize = new Size(1, 1);
            uiRadioButtonGroup1.Name = "uiRadioButtonGroup1";
            uiRadioButtonGroup1.Padding = new Padding(0, 32, 0, 0);
            uiRadioButtonGroup1.Size = new Size(281, 70);
            uiRadioButtonGroup1.TabIndex = 0;
            uiRadioButtonGroup1.Text = "Role";
            uiRadioButtonGroup1.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // rdouser
            // 
            rdouser.Font = new Font("Microsoft Sans Serif", 12F);
            rdouser.Location = new Point(144, 35);
            rdouser.MinimumSize = new Size(1, 1);
            rdouser.Name = "rdouser";
            rdouser.Size = new Size(90, 28);
            rdouser.TabIndex = 1;
            rdouser.Text = "User";
            // 
            // rdoadmin
            // 
            rdoadmin.Font = new Font("Microsoft Sans Serif", 12F);
            rdoadmin.Location = new Point(13, 35);
            rdoadmin.MinimumSize = new Size(1, 1);
            rdoadmin.Name = "rdoadmin";
            rdoadmin.Size = new Size(111, 28);
            rdoadmin.TabIndex = 0;
            rdoadmin.Text = "Admin";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(53, 80);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(303, 294);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // Frmlogin
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(800, 450);
            Controls.Add(pictureBox1);
            Controls.Add(uiPanel1);
            IconImage = (Image)resources.GetObject("$this.IconImage");
            Name = "Frmlogin";
            Text = "Sales and Inventory analysis system";
            ZoomScaleRect = new Rectangle(21, 21, 800, 450);
            uiPanel1.ResumeLayout(false);
            uiRadioButtonGroup1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIRadioButtonGroup uiRadioButtonGroup1;
        private Sunny.UI.UIRadioButton rdouser;
        private Sunny.UI.UIRadioButton rdoadmin;
        private Sunny.UI.UITextBox txtUsername;
        private Sunny.UI.UITextBox txtPassword;
        private Sunny.UI.UISymbolButton btnClear;
        private Sunny.UI.UISymbolButton btnLogin;
        private Sunny.UI.UILine uiLine1;
        private PictureBox pictureBox1;
    }
}
