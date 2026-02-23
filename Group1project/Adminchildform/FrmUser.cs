using Group1project.editForm;
using Group1project.Model;
using Group1project.project.BLL;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Group1project.Adminchildform
{
    public partial class FrmUser : UIPage
    {
        private readonly UserBLL _userBll = new UserBLL();
        private List<UserModel> _allUsers = new List<UserModel>();

        public FrmUser()
        {
            InitializeComponent();

            Load += FrmUser_Load;
            btnSearch.Click += BtnSearch_Click;
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            txtuser.ButtonClick += Txtuser_ButtonClick;
            txtuser.TextChanged += Txtuser_TextChanged;
        }

        private void FrmUser_Load(object? sender, EventArgs e)
        {
            LoadUsers();
        }

        private void LoadUsers()
        {
            _allUsers = _userBll.GetAllUsers();
            BindGrid(_allUsers);
        }

        private void BindGrid(List<UserModel> users)
        {
            dgvuser.AutoGenerateColumns = true;
            dgvuser.DataSource = null;
            dgvuser.DataSource = users;
        }

        private void BtnSearch_Click(object? sender, EventArgs e)
        {
            SearchUsers();
        }

        private void Txtuser_ButtonClick(object? sender, EventArgs e)
        {
            txtuser.Text = "";
            btnSearch.PerformClick();
        }


        private void Txtuser_TextChanged(object? sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtuser.Text))
            {
                LoadUsers();
            }
        }

        private void SearchUsers()
        {
            string keyword = txtuser.Text?.Trim() ?? string.Empty;

            if (string.IsNullOrWhiteSpace(keyword))
            {
                LoadUsers();
                return;
            }

            _allUsers = _userBll.GetAllUsers();
            List<UserModel> filteredUsers = _userBll.SearchUsersByUsername(_allUsers, keyword);

            BindGrid(filteredUsers);
            UIMessageTip.Show($"Found {filteredUsers.Count} user(s).");
        }

        private void BtnAdd_Click(object? sender, EventArgs e)
        {
            var editForm = new Fuseredit();
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!UIMessageBox.ShowAsk("Confirm adding this user?"))
            {
                return;
            }

            UserModel newUser = editForm.UserData;
            int rows = _userBll.AddUser(newUser);

            if (rows > 0)
            {
                UIMessageTip.ShowOk("User added successfully.");
                LoadUsers();
                return;
            }

            UIMessageBox.ShowError("Failed to add user.");
        }

        private void BtnEdit_Click(object? sender, EventArgs e)
        {
            if (dgvuser.CurrentRow?.DataBoundItem is not UserModel selectedUser)
            {
                UIMessageTip.ShowWarning("Please select a user to edit.");
                return;
            }

            var editForm = new Fuseredit(selectedUser);
            if (editForm.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            if (!UIMessageBox.ShowAsk("Confirm updating this user?"))
            {
                return;
            }

            UserModel updatedUser = editForm.UserData;
            updatedUser.userId = selectedUser.userId;

            int rows = _userBll.UpdateUser(updatedUser, selectedUser.create_time);
            if (rows > 0)
            {
                UIMessageTip.ShowOk("User updated successfully.");
                LoadUsers();
                return;
            }

            UIMessageBox.ShowError("Failed to update user.");
        }
    }
}
