using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using FlightBookingSystem.Models;
using FlightBookingSystem.Services;
using FontAwesome.Sharp;

namespace FlightBookingSystem.Controls
{
    public partial class MessagesControl : UserControl
    {
        private readonly IContactService _contactService;
        private List<ContactMessage> _currentMessages = new List<ContactMessage>();

        public MessagesControl(IContactService contactService)
        {
            InitializeComponent();
            _contactService = contactService;

            this.BackColor = Color.White;
            flowLayoutPanel.BackColor = Color.White;
            titleLabel.ForeColor = Color.FromArgb(0, 168, 255);
            statusLabel.ForeColor = Color.FromArgb(5, 15, 40); 
            LoadMessages();
        }

        private async void LoadMessages()
        {
            try
            {
                loadingLabel.Visible = true;
                flowLayoutPanel.Controls.Clear();

                IEnumerable<ContactMessage> messages = await _contactService.GetAllMessagesAsync();
                _currentMessages = messages.ToList();
                BuildMessageCards();
                UpdateStatusLabel();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading messages: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                loadingLabel.Visible = false;
            }
        }

        private void BuildMessageCards()
        {
            flowLayoutPanel.Controls.Clear();

            foreach (ContactMessage message in _currentMessages)
            {
                Panel card = CreateMessageCard(message);
                flowLayoutPanel.Controls.Add(card);
            }
        }

        private Panel CreateMessageCard(ContactMessage message)
        {
            Dictionary<string, string> parsedContent = ParseMessageContent(message.Message);

            Panel card = new Panel
            {
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.FromArgb(240, 248, 255), 
                Margin = new Padding(10),
                Width = flowLayoutPanel.ClientSize.Width - 25,
                MinimumSize = new Size(flowLayoutPanel.ClientSize.Width - 25, 50),
                AutoSize = true,
            };

            TableLayoutPanel mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 1,
                RowCount = 3,
                AutoSize = true
            };

            Panel headerPanel = new Panel { Dock = DockStyle.Fill, AutoSize = true };

            IconPictureBox statusIcon = new IconPictureBox
            {
                IconChar = message.IsRead ? IconChar.CheckCircle : IconChar.Envelope,
                IconColor = message.IsRead ? Color.DarkBlue : Color.DarkBlue,
                Size = new Size(24, 24),
                Location = new Point(10, 10)
            };

            Label usernameLabel = new Label
            {
                Text = $"{message.Username} - {message.CreatedAt:g}",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(40, 10),
                AutoSize = true
            };

            Label statusLabel = new Label
            {
                Text = message.IsRead ? "Read" : "Unread",
                ForeColor = message.IsRead ? Color.DarkBlue : Color.DarkBlue,
                Location = new Point(40, 35),
                AutoSize = true
            };

            headerPanel.Controls.Add(statusIcon);
            headerPanel.Controls.Add(usernameLabel);
            headerPanel.Controls.Add(statusLabel);

            Panel contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                Visible = false,
                Padding = new Padding(10, 5, 10, 10)
            };

            TableLayoutPanel contentLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 2,
            };
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 30F));
            contentLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 70F));

            AddField(contentLayout, "Name", parsedContent, "Name", 0);
            AddField(contentLayout, "Email", parsedContent, "Email", 1);
            AddField(contentLayout, "Type", parsedContent, "Message Type", 2);
            AddField(contentLayout, "Message", parsedContent, "Message", 3);

            contentPanel.Controls.Add(contentLayout);

            Panel actionPanel = new Panel
            {
                Dock = DockStyle.Fill,
                AutoSize = true,
                Padding = new Padding(10, 5, 10, 10)
            };

            Button toggleButton = new Button
            {
                Text = "Show Message",
                AutoSize = true,
                FlatStyle = FlatStyle.Flat,
                BackColor = Color.Transparent,
                ForeColor = Color.FromArgb(5, 15, 40), 
                FlatAppearance = { BorderColor = Color.FromArgb(5, 15, 40) } 
            };

            toggleButton.Click += (sender, e) =>
            {
                contentPanel.Visible = !contentPanel.Visible;
                contentPanel.Height = contentPanel.Visible ? contentPanel.Height +20 : contentPanel.Height;
                toggleButton.Text = contentPanel.Visible ? "Hide Message" : "Show Message";
            };

            if (!message.IsRead)
            {
                Button markReadButton = new Button
                {
                    Text = "Mark as Read",
                    BackColor = Color.FromArgb(0, 168, 255), 
                    ForeColor = Color.White,
                    FlatStyle = FlatStyle.Flat,
                    FlatAppearance = { BorderColor = Color.FromArgb(0, 140, 220) }, 
                    AutoSize = true,
                    Margin = new Padding(10, 0, 0, 0),
                    Tag = message.Id
                };

                markReadButton.Click += async (sender, e) =>
                {
                    int id = (int)((Button)sender).Tag;
                    bool success = await _contactService.MarkMessageAsReadAsync(id);
                    if (success)
                    {
                        ContactMessage msg = _currentMessages.FirstOrDefault(m => m.Id == id);
                        if (msg != null)
                        {
                            msg.IsRead = true;
                            card.BackColor = Color.White;
                            statusIcon.IconChar = IconChar.CheckCircle;
                            statusIcon.IconColor = Color.Green;
                            statusLabel.Text = "Read";
                            statusLabel.ForeColor = Color.Green;
                            markReadButton.Visible = false;
                            UpdateStatusLabel();
                        }
                    }
                };

                actionPanel.Controls.Add(markReadButton);
            }

            actionPanel.Controls.Add(toggleButton);
            actionPanel.Controls.SetChildIndex(toggleButton, 0);

            mainLayout.Controls.Add(headerPanel, 0, 0);
            mainLayout.Controls.Add(contentPanel, 0, 1);
            mainLayout.Controls.Add(actionPanel, 0, 2);

            card.Controls.Add(mainLayout);
            return card;
        }

        private void AddField(TableLayoutPanel layout, string label,
                  Dictionary<string, string> content,
                  string key, int row)
        {
            Label lbl = new Label
            {
                Text = $"{label}:",
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 5, 0, 0),
                ForeColor = Color.FromArgb(5, 15, 40) 
            };
            layout.Controls.Add(lbl, 0, row);

            Label value = new Label
            {
                Text = content.ContainsKey(key) ? content[key] : "N/A",
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 5, 0, 0),
                ForeColor = Color.FromArgb(50, 50, 50) 
            };
            layout.Controls.Add(value, 1, row);
        }

        private Dictionary<string, string> ParseMessageContent(string content)
        {
            Dictionary<string, string> result = new Dictionary<string, string>();

            if (!string.IsNullOrEmpty(content))
            {
                string[] lines = content.Split('\n');
                foreach (string line in lines)
                {
                    int colonIndex = line.IndexOf(':');
                    if (colonIndex > 0)
                    {
                        string key = line.Substring(0, colonIndex).Trim();
                        string value = line.Substring(colonIndex + 1).Trim();
                        if (!result.ContainsKey(key))
                        {
                            result[key] = value;
                        }
                    }
                }
            }

            return result;
        }

        private void UpdateStatusLabel()
        {
            int unreadCount = _currentMessages.Count(m => !m.IsRead);
            statusLabel.Text = $"Showing {_currentMessages.Count} messages ({unreadCount} unread)";
        }

        private void refreshButton_Click(object sender, EventArgs e)
        {
            LoadMessages();
        }
    }
}