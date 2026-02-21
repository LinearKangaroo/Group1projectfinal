using System;
using Group1project.project.BLL;
using Sunny.UI;

namespace Group1project
{
    public partial class Frmlogin : UIForm
    {
        private readonly LoginService _loginService = new LoginService();

        public Frmlogin()
        {
            InitializeComponent();
            btnLogin.Click += BtnLogin_Click;
            btnClear.Click += BtnClear_Click;
            txtPassword.KeyDown += TxtPassword_KeyDown;
            rdoadmin.Checked = true;
        }

        private void TxtPassword_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AttemptLogin();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void BtnLogin_Click(object? sender, EventArgs e)
        {
            AttemptLogin();
        }

        private void BtnClear_Click(object? sender, EventArgs e)
        {
            txtUsername.Text = string.Empty;
            txtPassword.Text = string.Empty;
            rdoadmin.Checked = true;
            txtUsername.Focus();
        }

        private void AttemptLogin()
        {
            var selectedRole = rdoadmin.Checked ? "Admin" : rdouser.Checked ? "User" : string.Empty;

            var result = _loginService.ValidateLogin(txtUsername.Text, txtPassword.Text, selectedRole);
            if (!result.IsSuccess)
            {
                UIMessageBox.ShowError(result.Message);
                return;
            }

            UIForm mainForm = string.Equals(result.Role, "Admin", StringComparison.OrdinalIgnoreCase)
                ? new FrmAdminMain()
                : new FrmUserMain();

            Hide();
            mainForm.Show();
        }
    }
}
