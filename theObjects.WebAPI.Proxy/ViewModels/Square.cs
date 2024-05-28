using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Square : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Side { get; set; } = 0;
        public Square() : base() { }
        public Square(int X, int Y, double Side) : base()
        { 
            this.X = X;
            this.Y = Y;
            this.Side = Side;
        }
    }
}
