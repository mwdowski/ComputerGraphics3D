using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Model;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public abstract class BaseFigureDrawer2D : IFigureDrawer
    {
        protected ZBufferedRasterizer Rasterizer { get; set; }

        public BaseFigureDrawer2D(ZBufferedRasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        abstract public void DrawPolygon(Polygon polygon);

        public void DrawPolygonSet(PolygonSet polygonSet)
        {
            Parallel.ForEach(polygonSet.Polygons, polygon => DrawPolygon(polygon));
            /*
            foreach (var polygon in polygonSet.Polygons)
            {
                polygon.Draw(this);
            }
            */
            
        }

        public void DrawVertex(Vertex vertex)
        {
            // do nothing
        }
    }
}
