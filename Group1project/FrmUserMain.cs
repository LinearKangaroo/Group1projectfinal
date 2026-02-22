using Group1project.Adminchildform;
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
        public FrmUserMain()
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
            var Dashboard = uiNavMenu1.CreateNode(AddPage(new FrmUdash(), 1001));
            uiNavMenu1.SetNodeSymbol(Dashboard, 61668, 24);

            var Inventory = uiNavMenu1.CreateNode(AddPage(new FrmUproduct(), 1002));
            uiNavMenu1.SetNodeSymbol(Inventory, 558149, 24);

            var Sale = uiNavMenu1.CreateNode(AddPage(new FrmUsale(), 1003));
            uiNavMenu1.SetNodeSymbol(Sale, 361788, 24);

            uiNavMenu1.SelectPage(1001);
        }

        private UIPage AddPage(UIPage page, int pageIndex)
        {
            if(page == null)
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
