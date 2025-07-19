using System;
using System.Data;
using System.Windows.Forms;
using FlightBookingSystem.DAL;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FlightBookingSystem.Forms;
using FlightBookingSystem.UserMgmtForms;

namespace FlightBookingSystem.Controls
{
    public partial class UserManagementControl : UserControl
    {
        private readonly User _currentUser;
        private readonly UserService _userService;
        private DataTable _usersTable;

        // Add the missing label declarations
        private Label lblName;
        private Label lblUsername;
        private Label lblMemberSince;
        private Label lblBalance;

        public UserManagementControl(User currentUser, IUserRepository userRepo)
        {
            InitializeComponent();
            _currentUser = currentUser;
            _userService = new UserService(userRepo); // Initialize the user service with repository
            _usersTable = new DataTable(); // Initialize the data table

            // Initialize the labels
            lblName = new Label();
            lblUsername = new Label();
            lblMemberSince = new Label();
            lblBalance = new Label();

            SetupProfileData();
            InitializeGrid();
            LoadUsers();
            SetupPermissions();
        }

        private void InitializeGrid()
        {
            usersGrid.Columns.Clear();

            usersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ID",
                HeaderText = "ID",
                Name = "ID",
                ReadOnly = true
            });

            usersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Username",
                HeaderText = "Username",
                Name = "Username",
                ReadOnly = true
            });

            // Add similar columns for FirstName, LastName, Role, Balance
            usersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "FirstName",
                HeaderText = "First Name",
                Name = "FirstName",
                ReadOnly = true
            });

            usersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LastName",
                HeaderText = "Last Name",
                Name = "LastName",
                ReadOnly = true
            });

            usersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Role",
                HeaderText = "Role",
                Name = "Role",
                ReadOnly = true
            });

            usersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Balance",
                HeaderText = "Balance",
                Name = "Balance",
                ReadOnly = true
            });

            usersGrid.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "LastLogin",
                HeaderText = "Last Login",
                Name = "LastLogin",
                ReadOnly = true,
                DefaultCellStyle = new DataGridViewCellStyle()
                {
                    Format = "g"
                }
            });

            usersGrid.Columns.Add(new DataGridViewCheckBoxColumn()
            {
                DataPropertyName = "IsLocked",
                HeaderText = "Locked",
                Name = "IsLocked",
                ReadOnly = true
            });

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
                usersGrid.DataSource = _usersTable;
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
            lblUsername.Text = $"Username: {_currentUser.Username}";
            lblMemberSince.Text = $"Member since: {_currentUser.DateCreated:MMMM yyyy}";
            lblBalance.Text = $"Balance: {_currentUser.Balance:C}";

            // Add the labels to the control if they're not already added
            if (!this.Controls.Contains(lblName))
            {
                lblName.Location = new System.Drawing.Point(20, 20);
                this.Controls.Add(lblName);
            }
            if (!this.Controls.Contains(lblUsername))
            {
                lblUsername.Location = new System.Drawing.Point(20, 50);
                this.Controls.Add(lblUsername);
            }
            if (!this.Controls.Contains(lblMemberSince))
            {
                lblMemberSince.Location = new System.Drawing.Point(20, 80);
                this.Controls.Add(lblMemberSince);
            }
            if (!this.Controls.Contains(lblBalance))
            {
                lblBalance.Location = new System.Drawing.Point(20, 110);
                this.Controls.Add(lblBalance);
            }
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
            using (var addForm = new AddUserForm(_currentUser))
            {
                if (addForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _userService.AddUser(addForm.NewUser, _currentUser.Id);
                        LoadUsers();
                        MessageBox.Show("User added successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error adding user: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            var selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            if (selectedId == _currentUser.Id)
            {
                MessageBox.Show("You cannot edit your own account here.", "Warning",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var userToEdit = _userService.GetUserById(selectedId);

            if (userToEdit == null) return;

            using (var editForm = new EditUserForm(userToEdit))
            {
                if (editForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _userService.UpdateUser(editForm.UpdatedUser);
                        LoadUsers();
                        MessageBox.Show("User updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating user: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            var selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            var username = usersGrid.SelectedRows[0].Cells["Username"].Value.ToString();

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

            var selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            var username = usersGrid.SelectedRows[0].Cells["Username"].Value.ToString();
            var currentBalance = (decimal)usersGrid.SelectedRows[0].Cells["Balance"].Value;

            using (var topUpForm = new TopUpForm(currentBalance))
            {
                if (topUpForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _userService.UpdateUserBalance(selectedId, topUpForm.TopUpAmount);
                        LoadUsers();
                        MessageBox.Show("Balance updated successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void roleChangeButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count == 0) return;

            var selectedId = (int)usersGrid.SelectedRows[0].Cells["ID"].Value;
            var currentRole = (User.Role)Enum.Parse(typeof(User.Role),
                usersGrid.SelectedRows[0].Cells["Role"].Value.ToString());

            using (var roleForm = new ChangeRoleForm(currentRole))
            {
                if (roleForm.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        _userService.ChangeUserRole(selectedId, roleForm.NewRole);
                        LoadUsers();
                        MessageBox.Show("Role changed successfully!", "Success",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadUsers();
        }
    }
}