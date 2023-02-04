using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ComputerGraphics3D.Drawing.FigureDrawers;
using P2_TrianglesFilling.FigureDrawers;

namespace ComputerGraphics3D.Model
{
    public class Vertex : Figure
    {
        public Vector3 Position { get; set; }
        public Vector3 Normal { get; set; }

        public Vertex(Vector3 position, Vector3 normal)
        {
            Position = position;
            Normal = normal;
        }

        public override string ToString()
        {
            return Position.ToString();
        }

        public override void Draw(IFigureDrawer drawer)
        {
            drawer.DrawVertex(this);
        }
    }
}
