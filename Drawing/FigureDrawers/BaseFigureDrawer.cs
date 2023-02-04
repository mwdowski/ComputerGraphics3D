using ComputerGraphics3D.Canvases;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public abstract class BaseFigureDrawer : IFigureDrawer
    {
        protected Rasterizer Rasterizer { get; set; }

        public BaseFigureDrawer(Rasterizer rasterizer)
        {
            Rasterizer = rasterizer;
        }

        abstract public void DrawPolygon(Polygon polygon);

        abstract public void DrawPolygonSet(PolygonSet polygonSet);

        public void DrawVertex(Vertex vertex)
        {
            // do nothing
        }
    }
}
