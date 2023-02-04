using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Model;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public class EdgesOnlyFigureDrawer : BaseFigureDrawer
    {
        private Pen pen = new(Brushes.Black);

        public EdgesOnlyFigureDrawer(Rasterizer rasterizer) : base(rasterizer)
        {
        }

        public override void DrawPolygon(Polygon polygon)
        {
            using var graphics = Graphics.FromImage(Rasterizer.Canvas.Bitmap);

            graphics.DrawLines(
                pen,
                polygon
                    .Vertices
                    .Select(v => Rasterizer.Rasterize(new PointF(v.Position.X, v.Position.Y)))
                    .ToArray()
            );
        }

        public override void DrawPolygonSet(PolygonSet polygonSet)
        {
            foreach (var polygon in polygonSet.Polygons) {
                polygon.Draw(this);
            }
        }
    }
}
