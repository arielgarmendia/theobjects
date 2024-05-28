using System;
using System.Collections.Generic;
using System.Text;

namespace theObjects.WebAPI.Proxy.ViewModels
{
    public class Shape
    {
        public Guid ID { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public Shape() 
        {
            Area = 0;
            Perimeter = 0;
        }
    }
}
