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
        public Vector4 Position { get; set; }
        public Vector4 Normal { get; set; }

        public Vertex(Vector3 position, Vector3 normal)
        {
            Position = new Vector4(position, 1f);
            Normal = new Vector4(normal, 1f);
        }

        public Vertex(Vector4 position, Vector4 normal)
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
