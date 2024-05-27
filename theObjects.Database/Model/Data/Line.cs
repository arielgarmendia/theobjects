using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace theObjects.Database.Model.Data
{
    public class Line
    {
        [Key]
        public Guid ID { get; set; }
        public Point StartPosition { get; set; }
        public Point EndPosition { get; set; }
        public double Area { get; set; }
        public double Perimeter { get; set; }
    }
}
