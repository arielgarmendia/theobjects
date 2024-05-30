using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Circle : Shape
    {
        public Point Position { get; set; }
        public double Diameter { get; set; } = 0;
        public Circle() : base() { }
        public Circle(int X, int Y, double Diameter) : base()
        { 
            this.Diameter = Diameter;

            this.Position = new Point(X, Y);
            this.Position.X = X;
            this.Position.Y = Y;
        }
    }
}
