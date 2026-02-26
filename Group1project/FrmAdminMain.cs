using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using Group1project.Adminchildform;
using Group1project.project.BLL;

namespace Group1project
{
    public partial class FrmAdminMain : UIForm
    {
        public FrmAdminMain()
        {
            InitializeComponent();
            this.Load += FrmUserMain_Load;
            btnlogout.Click += BtnLogout_Click;
            btnsetting.Click += BtnSetting_Click;
        }

        private void FrmUserMain_Load(object sender, EventArgs e)
        {
            uiNavMenu1.TabControl = uiTabControl1;
            uiNavMenu1.ShowTips = true; // 显示小红点

            // 带图标菜单
            var Dashboard = uiNavMenu1.CreateNode(AddPage(new FrmAdash(), 1001));
            uiNavMenu1.SetNodeSymbol(Dashboard, 61668, 24);

            var UserManagement = uiNavMenu1.CreateNode(AddPage(new FrmUser(), 1002));
            uiNavMenu1.SetNodeSymbol(UserManagement, 61447, 24);

            var Product = uiNavMenu1.CreateNode(AddPage(new FrmAproduct(), 1003));
            uiNavMenu1.SetNodeSymbol(Product, 558149, 24);

            var IMEI = uiNavMenu1.CreateNode(AddPage(new FrmAIMEI(), 1004));
            uiNavMenu1.SetNodeSymbol(IMEI, 557721, 24);

            var Transaction = uiNavMenu1.CreateNode(AddPage(new FrmAsale(), 1005));
            uiNavMenu1.SetNodeSymbol(Transaction, 361788, 24);

            var Analytics = uiNavMenu1.CreateNode(AddPage(new FrmAanalysis(), 1006));
            uiNavMenu1.SetNodeSymbol(Analytics, 57580, 24);

            uiNavMenu1.SelectPage(1001);
        }

        private UIPage AddPage(UIPage page, int pageIndex)
        {
            if (page == null)
            {
                return null;
            }
            page.PageIndex = pageIndex; // 绑定唯一索引（和菜单联动）
            page.Dock = DockStyle.Fill; // 页面铺满容器
            uiTabControl1.AddPage(page); // 加入UITabControl
            return page;
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
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
    }
}
