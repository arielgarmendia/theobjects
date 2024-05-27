using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace theObjects.Database.Model.Data
{
    public class Point
    {
        [Key]
        public Guid ID { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
        public virtual ICollection<Rectangle> Rectangles { get; set; }
        public virtual ICollection<Square> Squares { get; set; }
        public virtual ICollection<Circle> Circles { get; set; }
        public virtual ICollection<Line> StartLines { get; set; }
        public virtual ICollection<Line> EndLines { get; set; }
    }
}
