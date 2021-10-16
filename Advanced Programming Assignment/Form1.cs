using System;
using System.Drawing;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public partial class Form1 : Form
    {
        Graphics g = null;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            g.Clip = new Region(new Rectangle(txtBoxScript.Width + 50, 13, (Width - 530), Height - 71));

        }

        private void btnGo_MouseClick(object sender, MouseEventArgs e)
        {
            Command cmd = new Command(txtCmdLine, this.g);
            cmd.Parser();
        }

    }
}
