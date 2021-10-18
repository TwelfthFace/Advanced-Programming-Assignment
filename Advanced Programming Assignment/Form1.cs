using System;
using System.Drawing;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public partial class Form1 : Form
    {
        private Graphics g = null;
        private Command cmd = null;

        public Form1()
        {
            InitializeComponent();
            g = CreateGraphics();
            g.Clip = new Region(new Rectangle(txtBoxScript.Width + 50, 13, (Width - 530), Height - 71));
            this.cmd = new Command(txtCmdLine, this.g)
        }

        private void btnGo_MouseClick(object sender, MouseEventArgs e)
        {
            
                if (txtCmdLine.Text.Equals("clear"))
                {
                    this.Invalidate();
                    txtCmdLine.Text = "";
                } else {
                    if (txtCmdLine.Text.Equals("reset"))
                    {
                        this.Invalidate();
                        cmd.parser(lstBoxRanCommands);
                        txtCmdLine.Text = "";
                    } else {
                        if (txtCmdLine.Text != string.Empty)
                        {
                            cmd.parser(lstBoxRanCommands);
                            txtCmdLine.Text = "";
                        }
                    }
                }
        }
    }
}
