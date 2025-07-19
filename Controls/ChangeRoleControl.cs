using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Controls
{
    public partial class ChangeRoleControl : UserControl
    {
        public event EventHandler<User.Role> RoleChanged;
        public event EventHandler Cancelled;

        public User.Role NewRole { get; private set; }

        public ChangeRoleControl(User.Role currentRole)
        {
            InitializeComponent();
            roleComboBox.DataSource = Enum.GetValues(typeof(User.Role));
            roleComboBox.SelectedItem = currentRole;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewRole = (User.Role)roleComboBox.SelectedItem;
            RoleChanged?.Invoke(this, NewRole);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Cancelled?.Invoke(this, EventArgs.Empty);
        }
    }
}