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
            dt.Columns.Add("Last Login");

            dt.Rows.Add(1, "admin", "admin@example.com", "Administrator", "2023-05-15 14:30");
            dt.Rows.Add(2, "user1", "user1@example.com", "Customer", "2023-05-14 09:15");
            dt.Rows.Add(3, "user2", "user2@example.com", "Customer", "2023-05-13 16:45");

            usersGrid.DataSource = dt;
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Add user functionality would be implemented here", "Add User", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (usersGrid.SelectedRows.Count > 0)
            {
                MessageBox.Show($"Edit user {usersGrid.SelectedRows[0].Cells["Username"].Value}", "Edit User", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}