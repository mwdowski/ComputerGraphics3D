using ComputerGraphics3D.Drawing.Algorithms;
using ComputerGraphics3D.Drawing.ColorProviders;
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
    public class RandomColorFigureDrawer3D : BaseFigureDrawer3D
    {
        private Random rand = new Random(2137);

        public RandomColorFigureDrawer3D(ZBufferedRasterizer rasterizer, ISceneTransformer sceneTransformer) : base(rasterizer, sceneTransformer)
        {
        }

        public override void DrawPolygon(Polygon polygon)
        {
            var colorProvider = new ConstantColorProvider(Color.FromArgb(128 + rand.Next(128), 0, 0));
            foreach (var pixel in polygon.GetPixelsWithInterpolatedZ(Rasterizer, sceneTransformer))
            {
                Rasterizer.DrawPixel(pixel.Pixel, pixel.Z, colorProvider.GetColor(pixel.Pixel.X, pixel.Pixel.Y));
            }
            /*
            PolygonFilling.FillPolygon(
                Rasterizer.canvas,
                polygon
                    .Vertices
                    .Select(v => sceneTransformer.Transform(v.Position))
                    .Select(p => Rasterizer.GetPositionOnCanvas(p))
                    .ToList(),
                new ConstantColorProvider(Color.FromArgb(128 + rand.Next(128), 0, 0))
            );
            */
        }
    }
}
