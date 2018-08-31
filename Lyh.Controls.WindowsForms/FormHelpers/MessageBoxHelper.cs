using System.Windows.Forms;

namespace Lyh.Controls.WindowsForms.FormHelpers
{
    public class MessageBoxHelper
    {
        public static DialogResult Alert(string msg)
        {
            return Alert(msg, string.Empty);
        }

        public static DialogResult Alert(string msg, string title)
        {
            return MessageBox.Show(msg, title,
                MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk,
                MessageBoxDefaultButton.Button1);
        }

        public static DialogResult Confirm(string msg)
        {
            return Confirm(msg, string.Empty);
        }

        public static DialogResult Confirm(string msg, string title)
        {
            return MessageBox.Show(msg, title,
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2);
        }
    }
}