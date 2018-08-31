using System;
using System.Windows.Forms;
using Lyh.Controls.WindowsForms.FormHelpers;
using Lyh.Controls.WindowsForms.Properties;

namespace Lyh.Controls.WindowsForms.BaseForms
{
    public partial class ServerForm : Form
    {
        public ServerForm()
        {
            InitializeComponent();
        }

        private void ShowNotifyIcon(bool show)
        {
            Visible = !show;
            ShowInTaskbar = !show;
            notifyIcon.Visible = show;
            notifyIcon.ShowBalloonTip(3000);
            Visible = !show;
            if (Visible) Activate();
        }

        private void tsmiExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK == MessageBoxHelper.Confirm(Resources.ConfirmExit))
            {
                Application.Exit();
            }
        }

        private void tsmiAbout_Click(object sender, EventArgs e)
        {

        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ShowNotifyIcon(false);
            }
        }

        private void ServerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                ShowNotifyIcon(true);
            }
        }
    }
}
