using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Model;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public class EdgesOnlyFigureDrawer2D : BaseFigureDrawer2D
    {
        private readonly Pen pen = new(Brushes.Black);

        public EdgesOnlyFigureDrawer2D(ZBufferedRasterizer rasterizer) : base(rasterizer)
        {
        }

        public override void DrawPolygon(Polygon polygon)
        {
            using var graphics = Graphics.FromImage(Rasterizer.canvas.Bitmap);

            graphics.DrawPolygon(
                pen,
                polygon
                    .Vertices
                    .Select(v => Rasterizer.GetPositionOnCanvas(v.Position))
                    .ToArray()
            );
        }
    }
}
