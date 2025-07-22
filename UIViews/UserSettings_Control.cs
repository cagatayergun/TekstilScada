// UI/Views/UserSettings_Control.cs
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using TekstilScada.Models;
using TekstilScada.Repositories;

namespace TekstilScada.UI.Views
{
    public partial class UserSettings_Control : UserControl
    {
        private readonly UserRepository _repository;
        private List<User> _users;
        private List<Role> _allRoles;
        private User _selectedUser;

        public UserSettings_Control()
        {
            InitializeComponent();
            _repository = new UserRepository();
        }

        private void UserSettings_Control_Load(object sender, EventArgs e)
        {
            LoadAllRoles();
            RefreshUserList();
        }

        private void LoadAllRoles()
        {
            _allRoles = _repository.GetAllRoles();
            clbRoles.DataSource = _allRoles;
            clbRoles.DisplayMember = "RoleName";
            clbRoles.ValueMember = "Id";
        }

        private void RefreshUserList()
        {
            _users = _repository.GetAllUsers();
            dgvUsers.DataSource = null;
            dgvUsers.DataSource = _users;
            if (dgvUsers.Columns["Id"] != null) dgvUsers.Columns["Id"].Visible = false;
            if (dgvUsers.Columns["Roles"] != null) dgvUsers.Columns["Roles"].Visible = false;
        }

        private void dgvUsers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                _selectedUser = dgvUsers.SelectedRows[0].DataBoundItem as User;
                if (_selectedUser != null)
                {
                    PopulateFields(_selectedUser);
                }
            }
        }

        private void PopulateFields(User user)
        {
            txtUsername.Text = user.Username;
            txtFullName.Text = user.FullName;
            chkIsActive.Checked = user.IsActive;
            txtPassword.Text = ""; // Şifre alanını güvenlik için boş bırak

            // Kullanıcının rollerini işaretle
            var userRoles = _repository.GetUserRoles(user.Id);
            for (int i = 0; i < clbRoles.Items.Count; i++)
            {
                var role = clbRoles.Items[i] as Role;
                if (userRoles.Any(ur => ur.Id == role.Id))
                {
                    clbRoles.SetItemChecked(i, true);
                }
                else
                {
                    clbRoles.SetItemChecked(i, false);
                }
            }
        }

        private void ClearFields()
        {
            _selectedUser = null;
            dgvUsers.ClearSelection();
            txtUsername.Text = "";
            txtFullName.Text = "";
            txtPassword.Text = "";
            chkIsActive.Checked = true;
            for (int i = 0; i < clbRoles.Items.Count; i++)
            {
                clbRoles.SetItemChecked(i, false);
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearFields();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUsername.Text))
            {
                MessageBox.Show("Kullanıcı adı zorunludur.", "Eksik Bilgi");
                return;
            }

            var selectedRoleIds = clbRoles.CheckedItems.OfType<Role>().Select(r => r.Id).ToList();

            try
            {
                if (_selectedUser == null) // Yeni Kayıt
                {
                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        MessageBox.Show("Yeni kullanıcı için şifre zorunludur.", "Eksik Bilgi");
                        return;
                    }
                    var newUser = new User { Username = txtUsername.Text, FullName = txtFullName.Text, IsActive = chkIsActive.Checked };
                    _repository.AddUser(newUser, txtPassword.Text, selectedRoleIds);
                }
                else // Güncelleme
                {
                    _selectedUser.Username = txtUsername.Text;
                    _selectedUser.FullName = txtFullName.Text;
                    _selectedUser.IsActive = chkIsActive.Checked;
                    _repository.UpdateUser(_selectedUser, selectedRoleIds, txtPassword.Text);
                }
                RefreshUserList();
                ClearFields();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Kayıt sırasında hata: {ex.Message}", "Hata");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (_selectedUser == null) return;
            var result = MessageBox.Show($"'{_selectedUser.Username}' kullanıcısını silmek istediğinizden emin misiniz?", "Onay", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                try
                {
                    _repository.DeleteUser(_selectedUser.Id);
                    RefreshUserList();
                    ClearFields();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Silme sırasında hata: {ex.Message}", "Hata");
                }
            }
        }
    }
}