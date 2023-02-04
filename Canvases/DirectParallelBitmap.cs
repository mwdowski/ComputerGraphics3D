using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Canvases
{
    public class DirectParallelBitmap : ICanvas
    {
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        protected GCHandle BitsHandle { get; private set; }
        public Bitmap Bitmap { get; set; }

        private object _lock = new object();
        public DirectParallelBitmap(Bitmap bitmap)
        {
            Width = bitmap.Width;
            Height = bitmap.Height;
            Bits = new int[Width * Height];
            for (int i = 0; i < Bits.Length; i++)
            {
                Bits[i] = Color.White.ToArgb();
            }
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppRgb, BitsHandle.AddrOfPinnedObject());

            using (var g = Graphics.FromImage(Bitmap))
            {
                g.DrawImage(bitmap, 0, 0);
            }
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            int col = colour.ToArgb();

            lock (_lock)
            {
                Bits[index] = col;
            }
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            int col;
            lock (_lock)
            {
                col = Bits[index];
            }
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }

        public void Refresh()
        {
            throw new NotImplementedException();
        }
    }
}
