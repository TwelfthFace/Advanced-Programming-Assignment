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
            this.Width = 1000;
            this.Height = 850;
        }


        //keep layout aligned and neat on Repaint
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            this.SetAndFillClip(e);
            this.DrawRectangle(e, 0, 0, 400, 300, Color.Blue);
        }

        private void DrawRectangle(PaintEventArgs e, int x, int y, int width, int length, Color colour, int penSize = 3)
        {
            Pen blackPen = new Pen(colour, penSize);
            RectangleF clipbound = e.Graphics.ClipBounds;

            e.Graphics.DrawRectangle(blackPen, clipbound.X + penSize, y + penSize+12, width, length);
        }

        //sets graphics clipsize
        private void SetAndFillClip(PaintEventArgs e)
        {

            // Set the Clip property to a new region.
            e.Graphics.Clip = new Region(new Rectangle(this.textBox1.Width+50, 13, this.Width-540, this.Height-80));

            // Fill the region.
            e.Graphics.FillRegion(Brushes.LightSalmon, e.Graphics.Clip);

        }

        //force repaint on resize
        private void Form1_Resize(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
