using System;
using System.Drawing;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //this.Width = 1000;
            //this.Height = 913;
        }

        //keep layout aligned and neat on Repaint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.SetAndFillClip(e);


            //new Command(txtCmdLine).DrawRectangle(e, 0, 0, 400, 300, Color.Blue);
        }

        //sets graphics clipsize
        private void SetAndFillClip(PaintEventArgs e)
        {

            // Set the Clip property to a new region.
            e.Graphics.Clip = new Region(new Rectangle(this.txtBoxScript.Width+50, 13, this.Width-530, this.Height-71));

            // Fill the region.
            e.Graphics.FillRegion(Brushes.LightSalmon, e.Graphics.Clip);

        }

        //force repaint on resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Command cmd = new Command(this.txtCmdLine);

        }
    }
}
