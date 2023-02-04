using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Model;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public class EdgesOnlyFigureDrawer2D : BaseFigureDrawer2D
    {
        private readonly Pen pen = new(Brushes.Black);

        public EdgesOnlyFigureDrawer2D(Rasterizer rasterizer) : base(rasterizer)
        {
        }

        public override void DrawPolygon(Polygon polygon)
        {
            using var graphics = Graphics.FromImage(Rasterizer.Canvas.Bitmap);

            graphics.DrawPolygon(
                pen,
                polygon
                    .Vertices
                    .Select(v => Rasterizer.Rasterize(new PointF(v.Position.X, v.Position.Y)))
                    .ToArray()
            );
        }
    }
}
