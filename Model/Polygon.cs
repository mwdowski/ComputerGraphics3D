using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComputerGraphics3D.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;

namespace ComputerGraphics3D.Model
{
    public class Polygon : Figure
    {
        public List<Vertex> Vertices { get; private set; }

        public Polygon() : base()
        {
            Vertices = new();
        }

        public override void Draw(IFigureDrawer drawer)
        {
            drawer.DrawPolygon(this);
        }
    }
}
