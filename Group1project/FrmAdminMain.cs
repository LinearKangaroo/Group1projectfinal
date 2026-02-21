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
        // right-side nav handled via uiNavBar1 nodes (CreateNode) when available
        private readonly Dictionary<int, Func<UIPage>> _rightNavPageMap = new Dictionary<int, Func<UIPage>>();
        public FrmAdminMain()
        {
            InitializeComponent();

            //关联窗体承载多页面框架的容器UITabControl
            //窗体上如果只有一个UITabControl，也会自动关联，超过一个需要手动关联
            this.MainTabControl = uiTabControl1;
            uiNavMenu1.TabControl = uiTabControl1;
            // initialize navigation menu and right-side nav bar nodes
            InitializeNavMenu();
            InitializeNavBarNodes();
            // handle nav menu clicks and selection
            uiNavMenu1.NodeMouseClick += UiNavMenu1_NodeMouseClick;
            uiNavMenu1.AfterSelect += UiNavMenu1_AfterSelect;

            // open dashboard after form shown
            this.Shown += (s, e) =>
            {
                if (uiNavMenu1.Nodes.Count > 0)
                {
                    uiNavMenu1.SelectedNode = uiNavMenu1.Nodes[0];
                    OpenPage("Dashboard", new Adminchildform.FrmAdash());
                }
            };

            // right-side nodes are docked; no manual reposition required

        }   

        private void InitializeNavMenu()
        {
            uiNavMenu1.Nodes.Clear();

            // create nodes
            var dash = new TreeNode("Dashboard");
            var user = new TreeNode("User");
            var product = new TreeNode("Product");
            var imei = new TreeNode("IMEI info");
            var sales = new TreeNode("Sales");
            var analysis = new TreeNode("Analysis");

            uiNavMenu1.Nodes.Add(dash);
            uiNavMenu1.Nodes.Add(user);
            uiNavMenu1.Nodes.Add(product);
            uiNavMenu1.Nodes.Add(imei);
            uiNavMenu1.Nodes.Add(sales);
            uiNavMenu1.Nodes.Add(analysis);
        }

        private void InitializeNavBarNodes()
        {
            // Try to use Sunny.UI.UINavBar.CreateNode and TabControl.AddPage if available (reflection)
            var navBarType = uiNavBar1.GetType();

            // prepare right-side nodes mapping (use page indices starting at 2001)
            _rightNavPageMap.Clear();
            _rightNavPageMap[2001] = () => new Adminchildform.FrmAdash(); // Profile -> placeholder
            _rightNavPageMap[2002] = () => new Adminchildform.FrmAanalysis(); // Settings -> placeholder

            try
            {
                var createNode = navBarType.GetMethod("CreateNode", new Type[] { typeof(string), typeof(int) });
                if (createNode != null)
                {
                    createNode.Invoke(uiNavBar1, new object[] { "Profile", 2001 });
                    createNode.Invoke(uiNavBar1, new object[] { "Settings", 2002 });
                    createNode.Invoke(uiNavBar1, new object[] { "Logout", 2003 });
                }

                // try to subscribe to MenuItemClick event (signature: string text, int menuIndex, int pageIndex)
                var eventInfo = navBarType.GetEvent("MenuItemClick");
                if (eventInfo == null)
                {
                    eventInfo = navBarType.GetEvent("MenuItemClickEvent");
                }
                if (eventInfo != null)
                {
                    var handler = Delegate.CreateDelegate(eventInfo.EventHandlerType, this, nameof(NavBar_MenuItemClick));
                    eventInfo.AddEventHandler(uiNavBar1, handler);
                }
            }
            catch
            {
                // ignore -- fallback: nothing to do, nav bar will remain default
            }
        }

        // right-side nav uses a TreeView; no reposition helper needed

        private void UiNavMenu1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var key = e.Node?.Text;
            if (string.IsNullOrEmpty(key)) return;
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
                case "IMEI info":
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

        // handler for reflected MenuItemClick event from Sunny.UI.UINavBar
        // expected signature: void MenuItemClick(string text, int menuIndex, int pageIndex)
        private void NavBar_MenuItemClick(string text, int menuIndex, int pageIndex)
        {
            // pageIndex maps to our _rightNavPageMap
            if (pageIndex == 2003)
            {
                BtnLogout_Click(this, EventArgs.Empty);
                return;
            }

            if (_rightNavPageMap.TryGetValue(pageIndex, out var pageFactory))
            {
                OpenPage(text, pageFactory());
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
                case "IMEI info":
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
            try
            {
                // If UITabControl supports AddPage(UIPage) use it
                var addMethod = uiTabControl1.GetType().GetMethod("AddPage", new Type[] { typeof(UIPage) });
                if (addMethod != null)
                {
                    addMethod.Invoke(uiTabControl1, new object[] { page });
                }
                else
                {
                    var tab = new TabPage { Text = title };
                    page.Dock = DockStyle.Fill;
                    tab.Controls.Add(page);
                    uiTabControl1.TabPages.Add(tab);
                    uiTabControl1.SelectedTab = tab;
                }
            }
            catch
            {
                var tab = new TabPage { Text = title };
                page.Dock = DockStyle.Fill;
                tab.Controls.Add(page);
                uiTabControl1.TabPages.Add(tab);
                uiTabControl1.SelectedTab = tab;
            }
            _pages[title] = page;
        }
    }
}
