using System;
using theObjects.Database;
using Microsoft.EntityFrameworkCore;
using theObjects.Database.Model.Data;

namespace theObjects.Production.Creator
{
    class Program
    {
        static void Main(string[] args)
        {
            Objects();
        }

        static async void Objects()
        {
            try
            {
                //Database SETUP

                using (var context = new SqlDbContext())
                {
                    Console.WriteLine("Creating or getting Database context...");
                    // Creates the database if not exists
                    context.Database.EnsureCreated();

                    Console.WriteLine("Creating Points...");

                    var point1 = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = 12,
                        Y = 12
                    };

                    var point2 = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = 22,
                        Y = 22
                    };

                    var point3 = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = 32,
                        Y = 32
                    };

                    context.Point.Add(point1);
                    context.Point.Add(point2);
                    context.Point.Add(point3);

                    Console.WriteLine("Creating Circles...");

                    var circle1 = new Circle()
                    {
                        ID = Guid.NewGuid(),
                        Diameter = 20,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 100,
                            Y = 100
                        }
                    };

                    var circle2 = new Circle()
                    {
                        ID = Guid.NewGuid(),
                        Diameter = 20,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 150,
                            Y = 150
                        }
                    };

                    var circle3 = new Circle()
                    {
                        ID = Guid.NewGuid(),
                        Diameter = 20,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 180,
                            Y = 180
                        }
                    };

                    context.Circle.Add(circle1);
                    context.Circle.Add(circle2);
                    context.Circle.Add(circle3);

                    Console.WriteLine("Creating Rectangles...");

                    var rectangle1 = new Rectangle()
                    {
                        ID = Guid.NewGuid(),
                        Length = 20,
                        Width = 40,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 200,
                            Y = 200
                        }
                    };

                    var rectangle2 = new Rectangle()
                    {
                        ID = Guid.NewGuid(),
                        Length = 20,
                        Width = 40,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 250,
                            Y = 250
                        }
                    };

                    var rectangle3 = new Rectangle()
                    {
                        ID = Guid.NewGuid(),
                        Length = 20,
                        Width = 40,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 280,
                            Y = 280
                        }
                    };

                    context.Rectangle.Add(rectangle1);
                    context.Rectangle.Add(rectangle2);
                    context.Rectangle.Add(rectangle3);

                    Console.WriteLine("Creating Squares...");

                    var square1 = new Square()
                    {
                        ID = Guid.NewGuid(),
                        Side = 20,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 300,
                            Y = 300
                        }
                    };

                    var square2 = new Square()
                    {
                        ID = Guid.NewGuid(),
                        Side = 20,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 350,
                            Y = 350
                        }
                    };

                    var square3 = new Square()
                    {
                        ID = Guid.NewGuid(),
                        Side = 20,
                        Position = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 480,
                            Y = 480
                        }
                    };

                    context.Square.Add(square1);
                    context.Square.Add(square2);
                    context.Square.Add(square3);

                    Console.WriteLine("Creating Lines...");

                    var line1 = new Line()
                    {
                        ID = Guid.NewGuid(),
                        StartPosition = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 300,
                            Y = 300
                        },
                        EndPosition = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 400,
                            Y = 400
                        }
                    };

                    var line2 = new Line()
                    {
                        ID = Guid.NewGuid(),
                        StartPosition = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 350,
                            Y = 350
                        },
                        EndPosition = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 450,
                            Y = 450
                        }
                    };

                    var line3 = new Line()
                    {
                        ID = Guid.NewGuid(),
                        StartPosition = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 580,
                            Y = 580
                        },
                        EndPosition = new Point()
                        {
                            ID = Guid.NewGuid(),
                            X = 680,
                            Y = 680
                        }
                    };

                    context.Line.Add(line1);
                    context.Line.Add(line2);
                    context.Line.Add(line3);

                    Console.WriteLine("Saving data to Database...");
                    // Saves changes
                    context.SaveChanges();
                }

                Console.WriteLine("--------------------------------------------------------------------------");

                using (var context = new SqlDbContext())
                {
                    Console.WriteLine("Getting Database Circles...");

                    var circles = context.Circle.Include("Position");

                    foreach (var circle in circles)
                    {
                        Console.WriteLine(string.Format("Circle with ID: {0} and Diameter {1} and Position: {2}", circle.ID.ToString(), circle.Diameter.ToString(), string.Format("X={0}:Y={1}", circle.Position.X.ToString(), circle.Position.Y.ToString())));
                    }

                    Console.WriteLine("Getting Database Squares...");

                    var squares = context.Square.Include("Position");

                    foreach (var square in squares)
                    {
                        Console.WriteLine(string.Format("Square with ID: {0} and Side {1} and Position: {2}", square.ID.ToString(), square.Side.ToString(), string.Format("X={0}:Y={1}", square.Position.X.ToString(), square.Position.Y.ToString())));
                    }

                    Console.WriteLine("Getting Database Rectangles...");

                    var rectangles = context.Rectangle.Include("Position");

                    foreach (var rectangle in rectangles)
                    {
                        Console.WriteLine(string.Format("Rectangle with ID: {0} and Lenght {1} and Width {2} and Position: {3}", rectangle.ID.ToString(), rectangle.Length.ToString(), rectangle.Width.ToString(), string.Format("X={0}:Y={1}", rectangle.Position.X.ToString(), rectangle.Position.Y.ToString())));
                    }

                    Console.WriteLine("Getting Database Lines...");

                    var lines = context.Line.Include("StartPosition").Include("EndPosition");

                    foreach (var line in lines)
                    {
                        Console.WriteLine(string.Format("Line with ID: {0} and Start Position {1} and End Position {2}", line.ID.ToString(), string.Format("X={0}:Y={1}", line.StartPosition.X.ToString(), line.StartPosition.Y.ToString()), string.Format("X={0}:Y={1}", line.EndPosition.X.ToString(), line.EndPosition.Y.ToString())));
                    }

                    Console.WriteLine("Getting Database Single Points (not position points)...");

                    foreach (var point in context.Point)
                    {
                        var singlePoint = point.Circles == null && point.Squares == null && point.Rectangles == null && point.StartLines == null && point.EndLines == null;

                        if (singlePoint)
                            Console.WriteLine(string.Format("Point with ID: {0} and Position: {1}", point.ID.ToString(), string.Format("X={0}:Y={1}", point.X.ToString(), point.Y.ToString())));
                    }
                }

                Console.WriteLine("Type any key to Exit the app...");
                Console.ReadKey(true);
            }
            catch (Exception e)
            {
                Console.Write(e.Message);

                Console.WriteLine("Type any key to Exit the app...");
                Console.ReadKey(true);
            }
        }
    }
}
