using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleOutputEngine.Core.Models
{
    public class Pixel
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public char Value { get; private set; }

        public Pixel(int posX, int posY, char value)
        {
            PosX = posX;
            PosY = posY;
            Value = value;
        }
    }
}
