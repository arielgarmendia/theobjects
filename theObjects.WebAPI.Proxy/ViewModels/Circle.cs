using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Circle : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Diameter { get; set; } = 0;
        public Circle() : base() { }
        public Circle(int X, int Y, double Diameter) : base()
        { 
            this.X = X;
            this.Y = Y;
            this.Diameter = Diameter;
        }
    }
}
