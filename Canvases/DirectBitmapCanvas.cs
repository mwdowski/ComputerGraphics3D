using System.Drawing.Imaging;
using System.Runtime.InteropServices;

namespace ComputerGraphics3D.Canvases
{
    public class DirectBitmapCanvas : ICanvas
    {
        public Bitmap Bitmap { get; private set; }
        public Int32[] Bits { get; private set; }
        public bool Disposed { get; private set; }
        public int Height { get; private set; }
        public int Width { get; private set; }
        public PictureBox PictureBox { get; private set; }

        protected GCHandle BitsHandle { get; private set; }

        private object _lock = new object();
        public DirectBitmapCanvas(PictureBox pictureBox)
        {
            Width = pictureBox.Width;
            Height = pictureBox.Height;
            Bits = new int[Width * Height];
            for (int i = 0; i < Bits.Length; i++)
            {
                Bits[i] = Color.White.ToArgb();
            }
            BitsHandle = GCHandle.Alloc(Bits, GCHandleType.Pinned);
            Bitmap = new Bitmap(Width, Height, Width * 4, PixelFormat.Format32bppRgb, BitsHandle.AddrOfPinnedObject());
            PictureBox = pictureBox;
            pictureBox.Image = Bitmap;
        }

        public void SetPixel(int x, int y, Color colour)
        {
            int index = x + (y * Width);
            if (index >= Bits.Length || index < 0) return;

            int col = colour.ToArgb();

            lock(_lock)
            {
                Bits[index] = col;
            }
        }

        public Color GetPixel(int x, int y)
        {
            int index = x + (y * Width);
            if (index >= Bits.Length || index < 0) return Color.White;

            int col;
            lock (_lock)
            {
                col = Bits[index];
            }
            Color result = Color.FromArgb(col);

            return result;
        }

        public void Refresh()
        {
            PictureBox.Refresh();
        }

        public void Dispose()
        {
            if (Disposed) return;
            Disposed = true;
            Bitmap.Dispose();
            BitsHandle.Free();
        }
    }
}
