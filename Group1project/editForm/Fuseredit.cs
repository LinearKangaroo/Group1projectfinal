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
        private readonly bool _profileEditMode;
        public UserModel UserData { get; private set; } = new UserModel();

        public Fuseredit()
        {
            InitializeComponent();
            InitState();
            btnOK.Click += BtnOK_Click;
        }

        public Fuseredit(UserModel user, bool profileEditMode = false) : this()
        {
            _profileEditMode = profileEditMode;
            LoadUser(user);

            if (_profileEditMode)
            {
                ApplyProfileEditMode();
            }
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

        private void ApplyProfileEditMode()
        {
            txtusername.ReadOnly = true;
            rdoenable.Enabled = false;
            rdodisable.Enabled = false;
            rdoadmin.Enabled = false;
            rdouser.Enabled = false;
            cboposition.Enabled = false;
            Text = "Profile";
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
            UserData = user;
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
                userId = UserData.userId,
                create_time = UserData.create_time,
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
