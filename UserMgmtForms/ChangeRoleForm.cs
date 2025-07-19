using FlightBookingSystem.Models;
using System;
using System.Windows.Forms;

namespace FlightBookingSystem.Forms
{
    public partial class ChangeRoleForm : Form
    {
        public User.Role NewRole { get; private set; }

        public ChangeRoleForm(User.Role currentRole)
        {
            InitializeComponent();
            roleComboBox.DataSource = Enum.GetValues(typeof(User.Role));
            roleComboBox.SelectedItem = currentRole;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            NewRole = (User.Role)roleComboBox.SelectedItem;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}