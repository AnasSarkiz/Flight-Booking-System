using System;
using System.Data;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class UserManagementControl : UserControl
    {
        public UserManagementControl()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void LoadSampleData()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Username");
            dt.Columns.Add("Email");
            dt.Columns.Add("Role");
            dt.Columns.Add("Balance", typeof(decimal));
            dt.Columns.Add("Last Login");

            dt.Rows.Add(1, "admin", "admin@example.com", "Administrator", 0.00m, "2023-05-15 14:30");
            dt.Rows.Add(2, "user1", "user1@example.com", "Customer", 150.00m, "2023-05-14 09:15");
            dt.Rows.Add(3, "user2", "user2@example.com", "Customer", 75.50m, "2023-05-13 16:45");

            usersGrid.DataSource = dt;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            using (var addUserForm = new AddEditUserForm())
            {
                if (addUserForm.ShowDialog() == DialogResult.OK)
                {
                    // In a real application, add the new user to the database
                    MessageBox.Show("User added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count > 0)
            {
                var selectedUser = usersGrid.SelectedRows[0];
                using (var editUserForm = new AddEditUserForm(
                    selectedUser.Cells["Username"].Value.ToString(),
                    selectedUser.Cells["Email"].Value.ToString(),
                    selectedUser.Cells["Role"].Value.ToString(),
                    Convert.ToDecimal(selectedUser.Cells["Balance"].Value)))
                {
                    if (editUserForm.ShowDialog() == DialogResult.OK)
                    {
                        // In a real application, update the user in the database
                        MessageBox.Show("User updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to edit", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show($"Are you sure you want to delete user {usersGrid.SelectedRows[0].Cells["Username"].Value}?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    MessageBox.Show("User deleted (simulated)", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to delete", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void topUpButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count > 0)
            {
                var selectedRow = usersGrid.SelectedRows[0];
                if (selectedRow.Cells["Role"].Value.ToString() == "Administrator")
                {
                    MessageBox.Show("Cannot top up administrator accounts", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (var topUpForm = new TopUpForm(selectedRow.Cells["Username"].Value.ToString(), 
                                                    Convert.ToDecimal(selectedRow.Cells["Balance"].Value)))
                {
                    if (topUpForm.ShowDialog() == DialogResult.OK)
                    {
                        // In a real application, update the balance in the database
                        selectedRow.Cells["Balance"].Value = topUpForm.NewBalance;
                        MessageBox.Show("Balance updated successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a user to top up", "No Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}