using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Lyh.Controls.WindowsForms.DrawIt
{
    public partial class DrawChar : UserControl
    {
        private int[] order;

        public int[] Order
        {
            get { return order; }
            set { order = value; }
        }

        private string character;

        public string Character
        {
            get { return character; }
            set { character = value; }
        }

        private Font charFont;

        public Font CharFont
        {
            get { return charFont; }
            set
            {
                if (value == null || value == charFont) return;
                charFont = value;
            }
        }

        public DrawChar()
        {
            InitializeComponent();
        }

        public void Draw()
        {
            var grap = CreateGraphics();
            DrawHelper.DrawStep(grap, charFont, character, order);
        }
    }
}
