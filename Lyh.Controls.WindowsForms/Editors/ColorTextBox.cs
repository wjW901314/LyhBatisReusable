using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lyh.Controls.WindowsForms.Editors
{
    public partial class ColorTextBox : RichTextBox
    {
        public ColorTextBox()
        {
            InitializeComponent();
        }

        public ColorTextBox(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        public virtual void AppendText(string text, Color color)
        {
            AppendText(text);
            var start = TextLength - text.Length;
            if (start > -1) Select(start, text.Length);
            SelectionColor = color;
            SelectionStart = TextLength;
            Focus();
        }
    }
}