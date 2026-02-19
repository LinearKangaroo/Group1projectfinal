using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;
using Group1project.Adminchildform;

namespace Group1project
{
    public partial class FrmAdminMain : UIForm
    {
        // keep created pages to avoid duplicate tabs
        private readonly Dictionary<string, UIPage> _pages = new Dictionary<string, UIPage>();
        private readonly List<Sunny.UI.UIButton> _navBarButtons = new List<Sunny.UI.UIButton>();
        public FrmAdminMain()
        {
            InitializeComponent();

            //关联窗体承载多页面框架的容器UITabControl
            //窗体上如果只有一个UITabControl，也会自动关联，超过一个需要手动关联
            this.MainTabControl = uiTabControl1;
            uiNavMenu1.TabControl = uiTabControl1;
            // initialize navigation menu and right-side nav bar buttons
            InitializeNavMenu();
            InitializeNavBarButtons();
            // handle nav menu clicks
            uiNavMenu1.NodeMouseClick += UiNavMenu1_NodeMouseClick;

            // reposition right-side buttons when navbar is resized
            uiNavBar1.SizeChanged += (s, e) => RepositionNavBarButtons();

        }   

        private void InitializeNavMenu()
        {
            uiNavMenu1.Nodes.Clear();

            // create nodes
            var dash = new TreeNode("Dashboard");
            var user = new TreeNode("User");
            var product = new TreeNode("Product");
            var imei = new TreeNode("IMEI information");
            var sales = new TreeNode("Sales");
            var analysis = new TreeNode("Analysis");

            uiNavMenu1.Nodes.Add(dash);
            uiNavMenu1.Nodes.Add(user);
            uiNavMenu1.Nodes.Add(product);
            uiNavMenu1.Nodes.Add(imei);
            uiNavMenu1.Nodes.Add(sales);
            uiNavMenu1.Nodes.Add(analysis);
        }

        private void InitializeNavBarButtons()
        {
            // remove existing runtime buttons
            foreach (var b in _navBarButtons) uiNavBar1.Controls.Remove(b);
            _navBarButtons.Clear();

            // create profile, settings, logout buttons
            var btnProfile = new Sunny.UI.UIButton { Text = "Profile", AutoSize = true };
            var btnSettings = new Sunny.UI.UIButton { Text = "Settings", AutoSize = true };
            var btnLogout = new Sunny.UI.UIButton { Text = "Logout", AutoSize = true };

            btnProfile.Click += (s, e) => OpenPage("Profile", new Adminchildform.FrmAdash());
            btnSettings.Click += (s, e) => OpenPage("Settings", new Adminchildform.FrmAanalysis());
            btnLogout.Click += BtnLogout_Click;

            _navBarButtons.Add(btnProfile);
            _navBarButtons.Add(btnSettings);
            _navBarButtons.Add(btnLogout);

            foreach (var b in _navBarButtons)
            {
                b.Parent = uiNavBar1;
                uiNavBar1.Controls.Add(b);
            }

            RepositionNavBarButtons();
        }

        private void RepositionNavBarButtons()
        {
            // place buttons aligned to the right with spacing
            int spacing = 8;
            int x = uiNavBar1.Width - spacing;
            for (int i = _navBarButtons.Count - 1; i >= 0; i--)
            {
                var b = _navBarButtons[i];
                b.Location = new Point(x - b.Width, (uiNavBar1.Height - b.Height) / 2);
                x = b.Left - spacing;
            }
        }

        private void BtnLogout_Click(object sender, EventArgs e)
        {
            // show login form and close this main form
            UIForm login = new Frmlogin();
            login.Show();
            this.Close();
        }

        private void UiNavMenu1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            var key = e.Node.Text;
            switch (key)
            {
                case "Dashboard":
                    OpenPage(key, new Adminchildform.FrmAdash());
                    break;
                case "User":
                    OpenPage(key, new Adminchildform.FrmUser());
                    break;
                case "Product":
                    OpenPage(key, new Adminchildform.FrmAproduct());
                    break;
                case "IMEI information":
                    OpenPage(key, new Adminchildform.FrmAIMEI());
                    break;
                case "Sales":
                    OpenPage(key, new Adminchildform.FrmAsale());
                    break;
                case "Analysis":
                    OpenPage(key, new Adminchildform.FrmAanalysis());
                    break;
                default:
                    break;
            }
        }

        private void OpenPage(string title, UIPage page)
        {
            if (_pages.ContainsKey(title))
            {
                // select existing tab by text
                for (int i = 0; i < uiTabControl1.TabPages.Count; i++)
                {
                    var tp = uiTabControl1.TabPages[i];
                    if (tp.Text == title)
                    {
                        uiTabControl1.SelectedIndex = i;
                        return;
                    }
                }
            }

            // create a new page and add to tab control
            var tab = new TabPage { Text = title };
            page.Dock = DockStyle.Fill;
            tab.Controls.Add(page);
            uiTabControl1.TabPages.Add(tab);
            uiTabControl1.SelectedTab = tab;
            _pages[title] = page;
        }
    }
}
