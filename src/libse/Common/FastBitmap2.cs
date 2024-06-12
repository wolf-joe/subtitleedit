using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nikse.SubtitleEdit.Core.Common
{
    public class FastBitmap2
    {
        public struct PixelData
        {
            public byte Blue;
            public byte Green;
            public byte Red;
            public byte Alpha;
        }


        private readonly SKBitmap _workingBitmap;
        private int _width;
        //private int _height;
        private IntPtr _pBase;

        public int Width { get; private set; }
        public int Height { get; private set; }

        public FastBitmap2(SKBitmap inputBitmap)
        {
            _workingBitmap = inputBitmap;

            Width = inputBitmap.Width;
            Height = inputBitmap.Height;
        }

        public void LockImage()
        {
            _width = _workingBitmap.Width * 4; // 4 bytes per pixel for 32bpp
            if (_width % 4 != 0)
            {
                _width = 4 * (_width / 4 + 1);
            }

            _pBase = _workingBitmap.GetPixels();
        }

        private unsafe PixelData* _pixelData = null;

        public unsafe SKColor GetPixel(int x, int y)
        {
            _pixelData = (PixelData*)((byte*)_pBase + y * _width + x * sizeof(PixelData));
            return new SKColor(_pixelData->Red, _pixelData->Green, _pixelData->Blue, _pixelData->Alpha);
        }

        public unsafe SKColor GetPixelNext()
        {
            _pixelData++;
            return new SKColor(_pixelData->Red, _pixelData->Green, _pixelData->Blue, _pixelData->Alpha);
        }


        public void UnlockImage()
        {

        }

        public SKBitmap GetBitmap()
        {
            return _workingBitmap;
        }

        public unsafe void SetPixel(int x, int y, SKColor color)
        {
            var data = (PixelData*)((byte*)_pBase + y * _width + x * sizeof(PixelData));
            data->Alpha = color.Alpha;
            data->Red = color.Red;
            data->Green = color.Green;
            data->Blue = color.Blue;
        }
    }
}
