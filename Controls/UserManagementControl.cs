using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;

namespace FlightBookingSystem.Controls
{
    public partial class UserManagementControl : UserControl
    {
        private readonly User _currentUser;
        private readonly UserService _userService;
        private DataTable _usersTable;

        public UserManagementControl(User currentUser, IUserRepository userRepo)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _userService = new UserService(userRepo);

            InitializeGrid();
            LoadUsers();
            SetupPermissions();
            SetupProfileData();
        }

        private void InitializeGrid()
        {
            usersGrid.Columns.Clear();
            _usersTable = new DataTable();

            _usersTable.Columns.Add("ID", typeof(int));
            _usersTable.Columns.Add("Username", typeof(string));
            _usersTable.Columns.Add("FirstName", typeof(string));
            _usersTable.Columns.Add("LastName", typeof(string));
            _usersTable.Columns.Add("Role", typeof(string));
            _usersTable.Columns.Add("Balance", typeof(decimal));
            _usersTable.Columns.Add("LastLogin", typeof(DateTime));
            _usersTable.Columns.Add("IsLocked", typeof(bool));

            usersGrid.DataSource = _usersTable;
            usersGrid.AutoGenerateColumns = false;
            usersGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            usersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            usersGrid.RowHeadersVisible = false;
        }

        private void LoadUsers()
        {
            try
            {
                Cursor.Current = Cursors.WaitCursor;
                _usersTable.Rows.Clear();
                var users = _userService.GetAllUsers();

                if (users == null || !users.Any())
                {
                    MessageBox.Show("No users found.", "Information",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                foreach (var user in users)
                {
                    _usersTable.Rows.Add(
                        user.Id,
                        user.Username,
                        user.FirstName ?? string.Empty,
                        user.LastName ?? string.Empty,
                        user.UserRole.ToString(),
                        user.Balance,
                        user.LastLogin ?? DateTime.MinValue,
                        user.IsLocked
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                Cursor.Current = Cursors.Default;
            }
        }

        private void SetupProfileData()
        {
            lblName.Text = $"{_currentUser.FirstName} {_currentUser.LastName}";
            lblUsername.Text = $"{_currentUser.Username}";
            lblMemberSince.Text = $"Member since: {_currentUser.DateCreated:MMMM yyyy}";
            lblBalance.Text = $"{_currentUser.Balance:C}";
        }

        private void SetupPermissions()
        {
            bool isAdmin = _currentUser.UserRole == User.Role.Admin;
            addButton.Enabled = isAdmin;
            deleteButton.Enabled = isAdmin;
            lockUnlockButton.Enabled = isAdmin;
            roleChangeButton.Enabled = isAdmin;
        }

        private void usersGrid_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                editButton_Click(sender, e);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            var addUserControl = new AddUserControl();
            Form form = new Form
            {
                Text = "Add New User",
                Size = new System.Drawing.Size(450, 450),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            addUserControl.Dock = DockStyle.Fill;
            form.Controls.Add(addUserControl);

            addUserControl.UserAdded += (s, newUser) =>
            {
                try
                {
                    _userService.AddUser(newUser, _currentUser.Id);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                    LoadUsers();
                    MessageBox.Show("User added successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding user: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            addUserControl.Cancelled += (s, args) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            int selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            if (selectedId == _currentUser.Id)
            {
                MessageBox.Show("You cannot edit your own account here.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            User userToEdit = _userService.GetUserById(selectedId);
            if (userToEdit == null) return;

            EditUserControl editControl = new EditUserControl(userToEdit);
            Form form = new Form
            {
                Text = "Edit User",
                Size = new System.Drawing.Size(450, 450),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            editControl.Dock = DockStyle.Fill;
            form.Controls.Add(editControl);

            editControl.UserUpdated += (s, updatedUser) =>
            {
                try
                {
                    _userService.UpdateUser(updatedUser);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                    LoadUsers();
                    MessageBox.Show("User updated successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating user: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            editControl.Cancelled += (s, args) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            int selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            string username = usersGrid.SelectedRows[0].Cells["Username"].Value.ToString();

            var result = MessageBox.Show($"Are you sure you want to delete user {username}?",
                "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                try
                {
                    _userService.DeleteUser(selectedId);
                    LoadUsers();
                    MessageBox.Show("User deleted successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting user: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lockUnlockButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            var selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            var isLocked = (bool)usersGrid.SelectedRows[0].Cells["IsLocked"].Value;

            try
            {
                _userService.LockUnlockUser(selectedId, !isLocked);
                LoadUsers();
                MessageBox.Show($"User {(isLocked ? "unlocked" : "locked")} successfully!",
                    "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void topUpButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            int selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            decimal currentBalance = (decimal)usersGrid.SelectedRows[0].Cells["Balance"].Value;

            TopUpControl topUpControl = new TopUpControl(currentBalance);
            Form form = new Form
            {
                Text = "Top Up Balance",
                Size = new System.Drawing.Size(350, 250),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            topUpControl.Dock = DockStyle.Fill;
            form.Controls.Add(topUpControl);

            topUpControl.TopUpConfirmed += (s, amount) =>
            {
                try
                {
                    bool success = _userService.UpdateUserBalance(selectedId, amount);

                    if (success)
                    {
                        User updatedUser = _userService.GetUserById(selectedId);

                        if (_currentUser.Id == selectedId)
                        {
                            _currentUser.Balance = updatedUser.Balance;
                        }

                        form.DialogResult = DialogResult.OK;
                        form.Close();
                        LoadUsers();
                        MessageBox.Show("Balance updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Failed to update balance.", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            topUpControl.Cancelled += (s, args) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void roleChangeButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            int selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            User.Role currentRole = (User.Role)Enum.Parse(typeof(User.Role),
                usersGrid.SelectedRows[0].Cells["Role"].Value.ToString());

            ChangeRoleControl roleControl = new ChangeRoleControl(currentRole);
            Form form = new Form
            {
                Text = "Change User Role",
                Size = new System.Drawing.Size(350, 200),
                StartPosition = FormStartPosition.CenterParent,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false
            };

            roleControl.Dock = DockStyle.Fill;
            form.Controls.Add(roleControl);

            roleControl.RoleChanged += (s, newRole) =>
            {
                try
                {
                    _userService.ChangeUserRole(selectedId, newRole);
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                    LoadUsers();
                    MessageBox.Show("Role changed successfully!", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            };

            roleControl.Cancelled += (s, args) =>
            {
                form.DialogResult = DialogResult.Cancel;
                form.Close();
            };

            if (form.ShowDialog() == DialogResult.OK)
            {
                LoadUsers();
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}