using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public interface IFigureDrawer
    {
        public void DrawPolygon(Polygon polygon);
        public void DrawPolygonSet(PolygonSet polygonSet);
        public void DrawVertex(Vertex vertex);
    }
}
