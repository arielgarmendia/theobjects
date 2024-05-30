using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Square : Shape
    {
        public Point Position { get; set; }
        public double Side { get; set; } = 0;
        public Square() : base() { }
        public Square(int X, int Y, double Side) : base()
        { 
            this.Side = Side;

            this.Position = new Point(X, Y);
            this.Position.X = X;
            this.Position.Y = Y;
        }
    }
}
