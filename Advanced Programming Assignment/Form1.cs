﻿using System;
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


        //Keep Layout Aligned and Neat on repaint.
        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            this.SetAndFillClip(e);
        }


        //sets graphics clipsize.
        private void SetAndFillClip(PaintEventArgs e)
        {

            // Set the Clip property to a new region.
            e.Graphics.Clip = new Region(new Rectangle(this.textBox1.Width+50, 13, this.Width-540, this.Height-80));

            // Fill the region.
            e.Graphics.FillRegion(Brushes.LightSalmon, e.Graphics.Clip);

        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
