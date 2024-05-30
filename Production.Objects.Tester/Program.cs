using System;
using theObjects.WebAPI.Proxy;
using theObjects.WebAPI.Proxy.ViewModels;

namespace theObjects.Production.Tester
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
                //Screen TEST

                var result1 = await Screen<Point>.GetAll();
                var result2 = await Screen<Circle>.GetAll();
                var result3 = await Screen<Rectangle>.GetAll();
                var result4 = await Screen<Square>.GetAll();
                var result5 = await Screen<Line>.GetAll();

                var result6 = await Screen<Point>.Get(new Guid("5eb9fe04-5581-4e87-a9b0-02be5c68978f"));

                var result7 = await Screen<Point>.Draw(new Point(2000, 2000));
                var result8 = await Screen<Point>.Move(new Guid("5eb9fe04-5581-4e87-a9b0-02be5c68978f"), 2500, 2500);

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
