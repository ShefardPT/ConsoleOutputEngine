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

        public Engine() : this(' ')
        {

        }

        public Engine(char whitePixelValue)
        {
            WhitePixelValue = whitePixelValue;

            //ProcessStartInfo procStartInfo = new ProcessStartInfo("coes.exe")
            //{
            //    RedirectStandardError = true,
            //    RedirectStandardInput = true,
            //    RedirectStandardOutput = true,
            //    UseShellExecute = false,
            //    CreateNoWindow = false
            //};

            ProcessStartInfo procStartInfo = new ProcessStartInfo("coes.exe")
            {
                RedirectStandardError = false,
                RedirectStandardInput = false,
                RedirectStandardOutput = false,
                UseShellExecute = true,
                CreateNoWindow = false
            };

            _process = new Process();
            _process.StartInfo = procStartInfo;

            //Console.SetIn(_process.StandardOutput);
            //Console.SetOut(_process.StandardInput);
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
                    EndLine(ref currentPosY);
                }

                foreach (var pixel in pixelLine)
                {
                    while (currentPosX < pixel.PosX)
                    {
                        RenderPixel(WhitePixelValue, ref currentPosX);
                    }

                    RenderPixel(pixel.Value, ref currentPosX);
                }

                EndLine(ref currentPosY);
                currentPosX = 0;
            }
        }

        public void Clear()
        {
            Console.Clear();
        }

        private void RenderPixel(char pixelValue, ref int currentPosX)
        {
            for (int i = 0; i < _pixelThicc; i++)
            {
                Console.Write(pixelValue);
            }

            currentPosX++;
        }

        private void EndLine(ref int currentPosY)
        {
            Console.WriteLine();
            currentPosY++;
        }

        public void Dispose()
        {
            _process.Dispose();
        }
    }
}
