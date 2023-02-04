using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Drawing.SceneTransformers;
using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public class EdgesOnlyFigureDrawer3D : BaseFigureDrawer3D
    {
        private readonly Pen pen = new(Brushes.Black);

        public EdgesOnlyFigureDrawer3D(Rasterizer rasterizer, ISceneTransformer sceneTransformer) : base(rasterizer, sceneTransformer)
        {
        }

        public override void DrawPolygon(Polygon polygon)
        {
            using var graphics = Graphics.FromImage(Rasterizer.Canvas.Bitmap);

            graphics.DrawPolygon(
                pen,
                polygon
                    .Vertices
                    .Select(v => sceneTransformer.Transform(v.Position))
                    .Select(p => Rasterizer.Rasterize(new PointF(p.X / p.W, p.Y / p.W)))
                    .ToArray()
            );

        }
    }
}
