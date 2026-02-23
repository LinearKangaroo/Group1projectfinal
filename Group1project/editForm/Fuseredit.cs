using Group1project.Model;
using Group1project.project.DAL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Group1project.editForm
{
    
    public partial class Fuseredit : UIEditForm
    {
        public UserModel UserData { get; private set; } = new UserModel();

        public Fuseredit()
        {
            InitializeComponent();
            InitState();
            btnOK.Click += BtnOK_Click;
        }

        public Fuseredit(UserModel user) : this()
        {
            LoadUser(user);
        }

        private void InitState()
        {
            rdoenable.Checked = true;
            rdouser.Checked = true;
            if (cboposition.Items.Count > 0)
            {
                cboposition.SelectedIndex = 0;
            }
        }

        private void LoadUser(UserModel user)
        {
            txtusername.Text = user.username;
            txtpassword.Text = user.password;
            txtphone.Text = user.phone;
            txtemail.Text = user.email;

            rdoenable.Checked = user.status;
            rdodisable.Checked = !user.status;

            rdoadmin.Checked = string.Equals(user.role, "Admin", StringComparison.OrdinalIgnoreCase);
            rdouser.Checked = !rdoadmin.Checked;

            if (!string.IsNullOrWhiteSpace(user.position))
            {
                cboposition.Text = user.position;
            }
        }

        private void BtnOK_Click(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtusername.Text) || string.IsNullOrWhiteSpace(txtpassword.Text))
            {
                UIMessageTip.ShowWarning("Username and password are required.");
                DialogResult = DialogResult.None;
                return;
            }

            UserData = new UserModel
            {
                username = txtusername.Text.Trim(),
                password = txtpassword.Text.Trim(),
                phone = txtphone.Text.Trim(),
                email = txtemail.Text.Trim(),
                status = rdoenable.Checked,
                role = rdoadmin.Checked ? "Admin" : "User",
                position = cboposition.Text.Trim()
            };
        }
    }
}
