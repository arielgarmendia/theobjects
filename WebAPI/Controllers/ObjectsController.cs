using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using theObjects.Database;
using theObjects.Database.Model.Commands;
using theObjects.Database.Model.Data;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ObjectsController : ControllerBase
    {
        private readonly SqlDbContext _context;

        public ObjectsController(SqlDbContext context)
        {
            _context = new SqlDbContext();
        }

        #region Points
        [HttpPost]
        [Route(nameof(GetPoints))]
        public IActionResult GetPoints()
        {
            var points = new List<Point>();

            try
            {
                var circles = _context.Circle.Include("Position");
                var squares = _context.Square.Include("Position");
                var rectangles = _context.Rectangle.Include("Position");
                var lines = _context.Line.Include("StartPosition").Include("EndPosition");

                foreach (var point in _context.Point)
                {
                    var singlePoint = circles.Where(c => c.Position.ID == point.ID).FirstOrDefault() == null &&
                                      squares.Where(c => c.Position.ID == point.ID).FirstOrDefault() == null &&
                                      rectangles.Where(c => c.Position.ID == point.ID).FirstOrDefault() == null &&
                                      lines.Where(l => l.StartPosition.ID == point.ID).FirstOrDefault() == null &&
                                      lines.Where(l => l.EndPosition.ID == point.ID).FirstOrDefault() == null;

                    if (singlePoint)
                        points.Add(point);
                }

                return Ok(points);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(GetPoint))]
        public IActionResult GetPoint([FromBody] Guid id)
        {
            try
            {
                return Ok(_context.Point.Where(s => s.ID == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(MovePoint))]
        public IActionResult MovePoint([FromBody] MoveCommand command)
        {
            try
            {
                var point = _context.Point.Where(s => s.ID == command.id).FirstOrDefault();

                if (point != null)
                {
                    point.X = command.StartX;
                    point.Y = command.StartY;

                    _context.SaveChanges();
                }

                return Ok(point);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(DrawPoint))]
        public IActionResult DrawPoint([FromBody] DrawPointCommand command)
        {
            try
            {
                var point = new Point()
                {
                    ID = Guid.NewGuid(),
                    X = command.X,
                    Y = command.Y
                };

                _context.Point.Add(point);

                _context.SaveChanges();

                return Ok(point);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }
        #endregion

        #region Circles
        [HttpPost]
        [Route(nameof(GetCircles))]
        public IActionResult GetCircles()
        {
            try
            {
                return Ok(_context.Circle.Include("Position").ToList());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(GetCircle))]
        public IActionResult GetCircle([FromBody] Guid id)
        {
            try
            {
                return Ok(_context.Circle.Include("Position").Where(s => s.ID == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(MoveCircle))]
        public IActionResult MoveCircle([FromBody] MoveCommand command)
        {
            try
            {
                var circle = _context.Circle.Include("Position").Where(s => s.ID == command.id).FirstOrDefault();

                if (circle != null)
                {
                    circle.Position.X = command.StartX;
                    circle.Position.Y = command.StartY;

                    _context.SaveChanges();
                }

                return Ok(circle);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(DrawCircle))]
        public IActionResult DrawCircle([FromBody] DrawCircleCommand command)
        {
            try
            {
                var circle = new Circle()
                {
                    ID = Guid.NewGuid(),
                    Position = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = command.X,
                        Y = command.Y
                    },
                    Diameter = command.Diameter
                };

                _context.Circle.Add(circle);

                _context.SaveChanges();

                return Ok(circle);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }
        #endregion

        #region Rectangles
        [HttpPost]
        [Route(nameof(GetRectangles))]
        public IActionResult GetRectangles()
        {
            try
            {
                return Ok(_context.Rectangle.Include("Position").ToList());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(GetRectangle))]
        public IActionResult GetRectangle([FromBody] Guid id)
        {
            try
            {
                return Ok(_context.Rectangle.Include("Position").Where(s => s.ID == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(MoveRectangle))]
        public IActionResult MoveRectangle([FromBody] MoveCommand command)
        {
            try
            {
                var rectangle = _context.Rectangle.Include("Position").Where(s => s.ID == command.id).FirstOrDefault();

                if (rectangle != null)
                {
                    rectangle.Position.X = command.StartX;
                    rectangle.Position.Y = command.StartY;

                    _context.SaveChanges();
                }

                return Ok(rectangle);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(DrawRectangle))]
        public IActionResult DrawRectangle([FromBody] DrawRectangleCommand command)
        {
            try
            {
                var rectangle = new Rectangle()
                {
                    ID = Guid.NewGuid(),
                    Position = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = command.X,
                        Y = command.Y
                    },
                    Lenght = command.Lenght,
                    Width = command.Width
                };

                _context.Rectangle.Add(rectangle);

                _context.SaveChanges();

                return Ok(rectangle);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }
        #endregion

        #region Squares
        [HttpPost]
        [Route(nameof(GetSquares))]
        public IActionResult GetSquares()
        {
            try
            {
                return Ok(_context.Square.Include("Position").ToList());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(GetSquare))]
        public IActionResult GetSquare([FromBody] Guid id)
        {
            try
            {
                return Ok(_context.Square.Include("Position").Where(s => s.ID == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(MoveSquare))]
        public IActionResult MoveSquare([FromBody] MoveCommand command)
        {
            try
            {
                var square = _context.Square.Include("Position").Where(s => s.ID == command.id).FirstOrDefault();

                if (square != null)
                {
                    square.Position.X = command.StartX;
                    square.Position.Y = command.StartY;

                    _context.SaveChanges();
                }

                return Ok(square);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(DrawSquare))]
        public IActionResult DrawSquare([FromBody] DrawSquareCommand command)
        {
            try
            {
                var square = new Square()
                {
                    ID = Guid.NewGuid(),
                    Position = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = command.X,
                        Y = command.Y
                    },
                    Side = command.Side
                };

                _context.Square.Add(square);

                _context.SaveChanges();

                return Ok(square);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }
        #endregion

        #region Lines
        [HttpPost]
        [Route(nameof(GetLines))]
        public IActionResult GetLines()
        {
            try
            {
                return Ok(_context.Line.Include("StartPosition").Include("EndPosition").ToList());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(GetLine))]
        public IActionResult GetLine([FromBody] Guid id)
        {
            try
            {
                return Ok(_context.Line.Include("StartPosition").Include("EndPosition").Where(s => s.ID == id).FirstOrDefault());
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(MoveLine))]
        public IActionResult MoveLine([FromBody] MoveCommand command)
        {
            try
            {
                var line = _context.Line.Include("StartPosition").Include("EndPosition").Where(s => s.ID == command.id).FirstOrDefault();

                if (line != null)
                {
                    line.StartPosition.X = command.StartX;
                    line.StartPosition.Y = command.StartY;
                    line.EndPosition.X = command.EndX;
                    line.EndPosition.Y = command.EndY;

                    _context.SaveChanges();
                }

                return Ok(line);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }

        [HttpPost]
        [Route(nameof(DrawLine))]
        public IActionResult DrawLine([FromBody] DrawLineCommand command)
        {
            try
            {
                var line = new Line()
                {
                    ID = Guid.NewGuid(),
                    StartPosition = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = command.StartX,
                        Y = command.StartY
                    },
                    EndPosition = new Point()
                    {
                        ID = Guid.NewGuid(),
                        X = command.EndX,
                        Y = command.EndY
                    }
                };

                _context.Line.Add(line);

                _context.SaveChanges();

                return Ok(line);
            }
            catch (Exception e)
            {
                return Ok(new { success = false, errorMessage = e.Message });
            }
        }
        #endregion
    }
}
