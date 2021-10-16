using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Advanced_Programming_Assignment
{
     //class to define commands and facilitate appropriate feature expansion.
    class Command
    {
        private System.Windows.Forms.TextBox txtCmdLine;

        public Command(System.Windows.Forms.TextBox txtCmdLine)
        {
            this.txtCmdLine = txtCmdLine;
        }

        public string txtCmd
        {
            get => txtCmdLine.Text;
        }

        private void DrawRectangle(PaintEventArgs e, int x, int y, int width, int length, Color colour, int penSize = 3)
        {
            Pen blackPen = new Pen(colour, penSize);
            RectangleF clipbound = e.Graphics.ClipBounds;

            e.Graphics.DrawRectangle(blackPen, clipbound.X + penSize - 1, y + penSize + 12, width, length);
        }

    }
}
