using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Point : Shape
    {
        public int X { get; set; } = 0;
        public int Y { get; set; } = 0;
        public Point() : base() { }
        public Point(int X, int Y) : base()
        { 
            this.X = X;
            this.Y = Y;
        }
    }
}
