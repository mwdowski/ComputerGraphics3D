using ComputerGraphics3D.Model;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public interface IFigureDrawer
    {
        public void DrawPolygon(Polygon polygon);
        public void DrawPolygonSet(PolygonSet polygonSet);
        public void DrawVertex(Vertex vertex);
    }
}
