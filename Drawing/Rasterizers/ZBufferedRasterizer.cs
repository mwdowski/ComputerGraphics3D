using ComputerGraphics3D.Canvases;
using System.Drawing;
using System.Numerics;

namespace ComputerGraphics3D.Drawing.Rasterizers
{
    public class ZBufferedRasterizer : IRasterizer
    {
        public readonly ICanvas canvas;
        public ICanvas Canvas => canvas;

        private readonly float xMin;
        private readonly float xMax;
        private readonly float yMin;
        private readonly float yMax;
        private readonly int width;
        private readonly int height;

        private ZBuffor zBuffor;
        private class ZBuffor
        {
            private float[] data;
            private readonly int width;
            private readonly int height;

            public float this[int x, int y]
            {
                get => data[y * width + x];
                set => data[y * width + x] = value;
            }

            public ZBuffor(int width, int height)
            {
                this.width = width;
                this.height = height;
                data = new float[width * height];
                Refresh();
            }

            public void Refresh()
            {
                Array.Fill(data, float.PositiveInfinity);
            }
        }

        public ZBufferedRasterizer(ICanvas canvas)
        {
            this.canvas = canvas;
            float scale = 0.4f;
            xMin = -scale * canvas.Bitmap.Width / canvas.Bitmap.Height;
            xMax = scale * canvas.Bitmap.Width / canvas.Bitmap.Height;
            yMin = -scale;
            yMax = scale;
            width = canvas.Bitmap.Width;
            height = canvas.Bitmap.Height;
            zBuffor = new ZBuffor(width, height);
        }

        public bool CanDraw(Vector4 vector)
        {
            var pixel = GetPositionOnCanvas(vector);
            return CanDraw(pixel, vector.Z);
        }

        public void DrawPoint(Vector4 vector, Color color)
        {
            if (CanDraw(vector))
            {
                DrawPixel(GetPositionOnCanvas(vector), vector.Z, color);
            }
        }

        private object _lock = new();
        public void DrawPixel(Point pixel, float z, Color color)
        {
            lock (_lock)
            {
                if (CanDraw(pixel, z))
                {
                    Canvas.SetPixel(pixel.X, pixel.Y, color);
                    zBuffor[pixel.X, pixel.Y] = z;
                }
            }
        }

        public Color GetPixel(Point pixel)
        {
            return Canvas.GetPixel(pixel.X, pixel.Y);
        }

        public Point GetPositionOnCanvas(Vector4 vector)
        {
            var res = new Point(
                (int)Math.Round((vector.X / vector.W - xMin) * (width) / (xMax - xMin)),
                (int)Math.Round((vector.Y / vector.W - yMin) * (height) / (yMax - yMin)));

            return res;
        }

        public bool CanDraw(Point pixel, float z)
        {
            return pixel.X >= 0 && pixel.X < width && pixel.Y >= 0 && pixel.Y < height && zBuffor[pixel.X, pixel.Y] > z;
        }

        public void Refresh()
        {
            zBuffor.Refresh();
        }

        public PointF GetPixelCoordinates(Point pixel)
        {
            return new PointF(
                pixel.X * (xMax - xMin) / width,
                pixel.Y * (yMax - yMin) / height
            );
        }
    }
}
