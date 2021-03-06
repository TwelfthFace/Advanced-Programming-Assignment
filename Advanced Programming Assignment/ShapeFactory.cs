using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace Advanced_Programming_Assignment
{
    class ShapeFactory
    {
        public Shape getShape(String shape)
        {
            shape = shape.ToLower().Trim();
            switch (shape)
            {
                case "rectangle":
                    return new Rectangle();
                case "circle":
                    return new Circle();
                case "triangle":
                    return new Triangle();
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
