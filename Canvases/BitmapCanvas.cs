using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Canvases
{
    public class BitmapCanvas : ICanvas
    {
        public Bitmap Bitmap { get; private set; }
        public PictureBox PictureBox { get; private set; }

        public BitmapCanvas(PictureBox pictureBox)
        {
            Bitmap = new Bitmap(pictureBox.Width, pictureBox.Height);
            PictureBox = pictureBox;
            pictureBox.Image = Bitmap;
        }

        public Color GetPixel(int x, int y)
        {
            return Bitmap.GetPixel(x, y);
        }

        public void SetPixel(int x, int y, Color color)
        {
            Bitmap.SetPixel(x, y, color);
        }

        public bool Disposed { get; private set; } = false;
        public void Dispose()
        {
            if (Disposed) return;
            Bitmap.Dispose();
            Disposed = true;
        }

        public void Refresh()
        {
            PictureBox.Refresh();
        }
    }
}
