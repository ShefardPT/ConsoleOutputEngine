using ConsoleOutputEngine.Core.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Linq;

namespace ConsoleOutputEngine
{
    public class Engine : IDisposable
    {
        private Process _process;
        private int _pixelThicc = 2;
        
        public char WhitePixelValue { get; }

        public Engine(): this(' ')
        {
            
        }

        public Engine(char whitePixelValue)
        {
            WhitePixelValue = whitePixelValue;

            ProcessStartInfo procStartInfo = new ProcessStartInfo("cmd.exe")
            {
                RedirectStandardError = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                UseShellExecute = false
            };

            _process = Process.Start(procStartInfo);

            Console.SetOut(_process.StandardInput);
        }

        public void Render(IEnumerable<Pixel> pixelMap)
        {
            var pixelMapOrdered = pixelMap
                .OrderBy(x => x.PosX)
                .GroupBy(x => x.PosY)
                .OrderBy(g => g.Key);

            var currentPosX = 0;
            var currentPosY = 0;

            Clear();

            foreach (var pixelLine in pixelMapOrdered)
            {
                while (currentPosY < pixelLine.Key)
                {
                    Console.WriteLine();
                }

                foreach (var pixel in pixelLine)
                {
                    while (currentPosX < pixel.PosX)
                    {
                        RenderPixel(WhitePixelValue);
                    }

                    RenderPixel(pixel.Value);
                }

                Console.WriteLine();
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        private void RenderPixel(char pixelValue)
        {
            for (int i = 0; i < _pixelThicc; i++)
            {
                Console.Write(pixelValue);
            }
        }

        public void Dispose()
        {
            _process.Dispose();
        }
    }
}
