using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace MoleAssist
{
    public partial class Form2 : Form
    {
        private Point offset;
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;

            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.ShowInTaskbar = false;
        }
        private void Form2_MouseDoubleClick(object sender, EventArgs e)
        {
            this.Visible = false;
            Form_Main form = (Form_Main)this.Owner;
            form.Location = new Point(0, 0);
            form.ShowInTaskbar = true;
        }
    }
}
