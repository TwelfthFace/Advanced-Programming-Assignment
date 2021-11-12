using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public partial class Form1 : Form
    {
        public Graphics g = null;
        public Command cmd = null;
        public Script script = null;
        protected OpenFileDialog ofd = new OpenFileDialog();
        protected SaveFileDialog sfd = new SaveFileDialog();

        public Form1()
        {
            InitializeComponent();
            this.g = CreateGraphics();
            this.g.Clip = new Region(new System.Drawing.Rectangle(txtBoxScript.Width + 50, 39, (this.Width - 530), this.Height - 71));
            this.cmd = new Command(txtCmdLine, lstBoxRanCommands, this.g);
            this.script = new Script(lstBoxRanCommands, this.g);
            this.ofd.Filter = "txt files (*.txt)|*.txt";
            this.sfd.Filter = "txt files (*.txt)|*.txt";
        }

        //handles single line commands
        private void btnGo_MouseClick(object sender, MouseEventArgs e)
        {
            if (txtCmdLine.Text.Equals("run"))
            {
                script.parser(txtBoxScript.Text);
                return;
            }

            if (txtCmdLine.Text.Equals("clear"))
            {
                this.Invalidate();
                txtCmdLine.Text = "";
            } else {
                if (txtCmdLine.Text.Equals("reset"))
                {
                    this.Invalidate();
                    cmd.parser(txtCmdLine.Text);
                    txtCmdLine.Text = "";
                    return;
                } else {
                    if (txtCmdLine.Text != string.Empty)
                    {
                        cmd.parser(txtCmdLine.Text);
                        txtCmdLine.Text = "";
                        return;
                    }
                }
            }
        }

        //handles multiline scripts
        private void btnRunScript_Click(object sender, EventArgs e)
        {
            if(!txtBoxScript.Text.Equals(""))
                script.parser(txtBoxScript.Text);
        }

        //opens a text file and loads it into the txtBoxScript element
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (string line in System.IO.File.ReadLines(ofd.FileName))
                {
                    txtBoxScript.Text += line + "\r\n";
                }
            }
        }

        //saves the txtBoxScript text into a file
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, txtBoxScript.Text);
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
