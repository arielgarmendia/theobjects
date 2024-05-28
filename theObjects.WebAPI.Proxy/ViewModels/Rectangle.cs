using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Rectangle : Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public double Width { get; set; } = 0;
        public double Lenght { get; set; } = 0;
        public Rectangle() : base() { }
        public Rectangle(int X, int Y, double Width, double Lenght) : base()
        { 
            this.X = X;
            this.Y = Y;
            this.Lenght = Lenght;
            this.Width = Width;
        }
    }
}
