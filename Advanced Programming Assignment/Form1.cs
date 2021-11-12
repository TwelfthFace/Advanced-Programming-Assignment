using System;
using System.Drawing;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public partial class Form1 : Form
    {
        public Graphics g = null;
        public Command cmd = null;
        public Script script = null;

        public Form1()
        {
            InitializeComponent();
            this.g = CreateGraphics();
            this.g.Clip = new Region(new System.Drawing.Rectangle(txtBoxScript.Width + 50, 13, (this.Width - 530), this.Height - 71));
            this.cmd = new Command(txtCmdLine, lstBoxRanCommands, this.g);
            this.script = new Script(lstBoxRanCommands, this.g);
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
                        //this.Invalidate();
                        cmd.parser(txtCmdLine.Text);
                        txtCmdLine.Text = "";
                    } else {
                        if (txtCmdLine.Text != string.Empty)
                        {
                            cmd.parser(txtCmdLine.Text);
                            //txtCmdLine.Text = "";
                        }
                    }
                }
        }

        private void btnRunScript_Click(object sender, EventArgs e)
        {
            script.parser(txtBoxScript.Text);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
