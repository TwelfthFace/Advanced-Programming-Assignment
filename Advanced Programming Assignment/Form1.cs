using System;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public partial class Form1 : Form
    {
        public Canvas canvas = null;
        public Graphics g = null;
        public Command cmd = null;
        public Script script = null;
        protected OpenFileDialog ofd = new OpenFileDialog();
        protected SaveFileDialog sfd = new SaveFileDialog();

        public Form1()
        {
            InitializeComponent();
            this.canvas = new Canvas();
            this.g = canvas.getGraphicsContext();
            this.cmd = new Command(txtCmdLine, lstBoxRanCommands, this.canvas);
            this.script = new Script(lstBoxRanCommands, this.canvas);
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
            else {
                if (txtCmdLine.Text != string.Empty)
                {
                    cmd.parser(txtCmdLine.Text);
                    Refresh();
                    txtCmdLine.Text = "";
                    return;
                }
            }
            
        }

        //handles multiline scripts
        private void btnRunScript_Click(object sender, EventArgs e)
        {
            if(!txtBoxScript.Text.Equals(""))
                script.parser(txtBoxScript.Text);
            Refresh();
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

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(canvas.getBitmap(), 0, 0);
        }
    }
}
