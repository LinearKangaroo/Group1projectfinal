using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace Group1project
{
    public partial class FrmUserMain : UIForm
    {
        // keep created pages to avoid duplicate tabs
        private readonly Dictionary<string, UIPage> _pages = new Dictionary<string, UIPage>();

        public FrmUserMain()
        {
            InitializeComponent();

            //关联窗体承载多页面框架的容器UITabControl
            //窗体上如果只有一个UITabControl，也会自动关联，超过一个需要手动关联
            this.MainTabControl = uiTabControl1;
            uiNavMenu1.TabControl = uiTabControl1;
            // initialize navigation menu and right-side nav bar nodes
            InitializeNavMenu();
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
            var product = new TreeNode("Inventory");
            var sales = new TreeNode("Sales");

            uiNavMenu1.Nodes.Add(dash);
            uiNavMenu1.Nodes.Add(product);
            uiNavMenu1.Nodes.Add(sales);
        }

        private void UiNavMenu1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            var key = e.Node?.Text;
            if (string.IsNullOrEmpty(key)) return;
            switch (key)
            {
                case "Dashboard":
                    OpenPage(key, new Adminchildform.FrmUdash());
                    break;
                case "Inventory":
                    OpenPage(key, new Adminchildform.FrmAproduct());
                    break;
                case "Sales":
                    OpenPage(key, new Adminchildform.FrmAsale());
                    break;
                default:
                    break;
            }
        }

        // handler for reflected MenuItemClick event from Sunny.UI.UINavBar
        // expected signature: void MenuItemClick(string text, int menuIndex, int pageIndex)
        private void UiNavMenu1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            // open page based on node text
            switch (e.Node.Text)
            {
                case "Dashboard":
                    OpenPage("Dashboard", new Adminchildform.FrmUdash());
                    break;
                case "Inventory":
                    OpenPage("Inventory", new Adminchildform.FrmAproduct());
                    break;
                case "Sales":
                    OpenPage("Sales", new Adminchildform.FrmAsale());
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

        private void btnlogout_Click(object sender, EventArgs e)
        {
            Form logout = new Frmlogin();
            logout.Show();
            this.Close();
        }
    }
}
