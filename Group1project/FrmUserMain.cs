using Group1project.Adminchildform;
using Group1project.editForm;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Group1project
{
    public partial class FrmUserMain : UIForm
    {
        private readonly UserBLL _userBll = new UserBLL();
        private bool _isLoggingOut;
        public FrmUserMain()
        {
            InitializeComponent();
            this.Load += FrmUserMain_Load;
            btnlogout.Click += BtnLogout_Click;
            btnsetting.Click += BtnSetting_Click;
            btnprofile.Click += BtnProfile_Click;
            this.FormClosing += FrmUserMain_FormClosing;
        }

        private void FrmUserMain_Load(object sender, EventArgs e)
        {
            uiNavMenu1.TabControl = uiTabControl1;
            uiNavMenu1.ShowTips = true;

            // 带图标菜单
            var Dashboard = uiNavMenu1.CreateNode(AddPage(new FrmUdash(), 1001));
            uiNavMenu1.SetNodeSymbol(Dashboard, 61668, 24);

            var Inventory = uiNavMenu1.CreateNode(AddPage(new FrmUproduct(), 1002));
            uiNavMenu1.SetNodeSymbol(Inventory, 558149, 24);

            var Sale = uiNavMenu1.CreateNode(AddPage(new FrmAsale(), 1003));
            uiNavMenu1.SetNodeSymbol(Sale, 361788, 24);

            uiNavMenu1.SelectPage(1001);
        }

        private UIPage AddPage(UIPage page, int pageIndex)
        {
            if(page == null)
            {
                return null;
            }
            page.PageIndex = pageIndex; 
            page.Dock = DockStyle.Fill; 
            uiTabControl1.AddPage(page); 
            return page;
        }

        private void BtnProfile_Click(object? sender, EventArgs e)
        {
            if (!CurrentUserContext.IsLoggedIn)
            {
                UIMessageBox.ShowWarning("You are currently not logged in. Please log in again and try again.");
                return;
            }

            var user = _userBll.GetUserById(CurrentUserContext.UserId);
            if (user is null)
            {
                UIMessageBox.ShowError("The current user information cannot be read.");
                return;
            }

            var editForm = new Fuseredit(user, true);
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            string currentPassword = string.Empty;
            if (!this.ShowInputPasswordDialog(ref currentPassword))
            {
                return;
            }

            if (!_userBll.VerifyCurrentPassword(CurrentUserContext.UserId, currentPassword))
            {
                UIMessageBox.ShowWarning("The password is incorrect. The information has not been saved.");
                return;
            }

            var profileData = editForm.UserData;
            profileData.userId = user.userId;

            int rows = _userBll.UpdateUserProfile(profileData);
            if (rows > 0)
            {
                UIMessageTip.ShowOk("Personal information update successful!");
                return;
            }

            UIMessageBox.ShowError("The save failed. Please try again later.");
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            _isLoggingOut = true;
            CloseAskString = string.Empty;
            CurrentUserContext.Clear();
            var loginForm = new Frmlogin();
            loginForm.Show();
            this.Close();
        }

        private void BtnSetting_Click(object sender, EventArgs e)
        {
            var settingsForm = new Fsetting();
            settingsForm.ShowDialog();
        }

        private void FrmUserMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!_isLoggingOut)
            {
                Application.Exit();
            }
        }
    }
}
