using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Advanced_Programming_Assignment
{
    class Triangle : Shape
    {
        protected PointF[] points = {};

        // default points plotted to be an equilateral triangle.
        public Triangle() : base()
        {
            PointF[] points = {
                //top point
                new Point((this.x + 55) + this.x, 20 + this.y),
                //left point
                new Point((this.x + 10) + this.x, (100) + this.y),
                //right point
                new Point((this.x + 100) + this.x, 100 + this.y)
            };
            this.points = points;
        }

        //draw function that draws the shape.
        public override void draw(Graphics graphicsContext)
        {
            if (!fill)
            {
                graphicsContext.DrawPolygon(pen, points);
            }
            else
            {
                graphicsContext.FillPolygon(brush, points);
            }
        }

        //this function sets the colour, position, and optionally penwidth.
        public override void set(Color colour, int x, int y, float penWidth = 3.0f, params int[] list)
        {
            base.set(colour, x, y, penWidth);
            if (list.Length == 3) {
                //top
                this.points[0] = new Point(((this.x + this.y) + this.x / 2) + list[0], this.y);
                //left
                this.points[1] = new Point((this.x + this.y) + this.x + list[1], this.y + this.x + list[1]);
                //right
                this.points[2] = new Point(this.x + list[2], this.x + this.y + list[2]);
            }
            else
            {
                if (list.Length == 1)
                {
                    //top
                    this.points[0] = new Point(((this.x + this.y) + this.x / 2) + list[0], this.y);
                    //left
                    this.points[1] = new Point((this.x + this.y) + this.x  + list[0], this.y + this.x + list[0]);
                    //right
                    this.points[2] = new Point(this.x + list[0], this.x + this.y + list[0]);
                }
            }
        }
    }
}
