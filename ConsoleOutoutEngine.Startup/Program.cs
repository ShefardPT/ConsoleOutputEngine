using System;
using System.Collections.Generic;

namespace ConsoleOutoutEngine.Startup
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Debug
            //Console.WriteLine("Hello World!");

            //var image = new List<Pixel>()
            //{
            //    new Pixel(0, 0, 'O'), new Pixel(1, 0, 'O'), new Pixel(2, 0, 'O'), new Pixel(3, 0, 'O'), new Pixel(4, 0, 'O'),
            //    new Pixel(5, 0, 'O'), new Pixel(5, 1, 'O'), new Pixel(5, 2, 'O'), new Pixel(5, 3, 'O'), new Pixel(5, 4, 'O'),
            //    new Pixel(5, 5, 'O'), new Pixel(4, 5, 'O'), new Pixel(3, 5, 'O'), new Pixel(2, 5, 'O'), new Pixel(1, 5, 'O'),
            //    new Pixel(0, 5, 'O'), new Pixel(0, 4, 'O'), new Pixel(0, 3, 'O'), new Pixel(0, 2, 'O'), new Pixel(0, 1, 'O'),
            //    new Pixel(2, 2, 'O'), new Pixel(2, 3, 'O'), new Pixel(3, 3, 'O'), new Pixel(3, 2, 'O')
            //};

            //using (var eng = new Engine(' '))
            //{
            //    eng.Render(image);

            //    //eng.Clear();
            //}
            #endregion

            bool doStopApp = false;

            while (!doStopApp)
            {
                var key = Console.ReadKey(true);

                if ((key.Modifiers & ConsoleModifiers.Control) != 0 &&
                    (key.Key & ConsoleKey.C) != 0)
                {
                    doStopApp = true;
                }
                else
                {
                    Console.WriteLine("Press CTRL+C to stop application.");
                }
            }
        }
    }
}
