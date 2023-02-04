using ComputerGraphics3D.Canvases;
using ComputerGraphics3D.Drawing.FigureDrawers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Model
{
    public class PolygonSet : Figure
    {
        public List<Polygon> Polygons = new();

        public PolygonSet() : base()
        {
        }

        public override void Draw(IFigureDrawer drawer)
        {
            drawer.DrawPolygonSet(this);
        }
    }
}
