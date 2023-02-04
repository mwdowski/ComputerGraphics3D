using ComputerGraphics3D.Canvases;
using System.Numerics;

namespace ComputerGraphics3D.Drawing.Rasterizers
{
    public class Rasterizer
    {
        public readonly ICanvas Canvas;
        private readonly float xMin;
        private readonly float xMax;
        private readonly float yMin;
        private readonly float yMax;
        private readonly int width;
        private readonly int height;

        private object _lock = new object();

        public Rasterizer(ICanvas canvas)
        {
            Canvas = canvas;
            float scale = 1f;
            xMin = -scale * canvas.Bitmap.Width / canvas.Bitmap.Height;
            xMax = scale * canvas.Bitmap.Width / canvas.Bitmap.Height;
            yMin = -scale;
            yMax = scale;
            width = canvas.Bitmap.Width;
            height = canvas.Bitmap.Height;
        }

        public PointF Derasterize(Point point)
        {
            PointF res;

            res = new PointF(
                point.X * (xMax - xMin) / width,
                point.Y * (yMax - yMin) / height);

            return res;
        }

        public Point Rasterize(PointF point)
        {
            Point res;

            res = new Point(
                (int)Math.Round((point.X - xMin) * (width) / (xMax - xMin)),
                (int)Math.Round((point.Y - yMin) * (height) / (yMax - yMin)));
            if (res.X >= width) res.X = width;
            if (res.Y >= height) res.Y = height;

            if (res.X < 0) res.X = 0;
            if (res.Y < 0) res.Y = 0;

            return res;
        }

        public void SetColor(Color color, PointF point)
        {
            var rasterized = Rasterize(point);
            Canvas.SetPixel(rasterized.X, rasterized.Y, color);
        }

        public Color GetColor(PointF point)
        {
            var derasterized = Rasterize(point);
            return Canvas.GetPixel(derasterized.X, derasterized.Y);
        }
    }
}
