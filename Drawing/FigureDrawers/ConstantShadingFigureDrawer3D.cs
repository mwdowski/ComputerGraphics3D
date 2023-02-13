using ComputerGraphics3D.Drawing.Algorithms;
using ComputerGraphics3D.Drawing.ColorProviders;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Drawing.SceneTransformers;
using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public class ConstantShadingFigureDrawer3D : BaseFigureDrawer3D
    {
        private readonly LightSource lightSource;
        private readonly LightSource spotLightSource;
        private readonly PhongLightModelParameters parameters;
        private readonly Vector3 cameraPosition;

        public ConstantShadingFigureDrawer3D(
            ZBufferedRasterizer rasterizer,
            ISceneTransformer sceneTransformer,
            LightSource lightSource,
            LightSource spotLightSource,
            PhongLightModelParameters parameters,
            Vector3 cameraPosition
            )
            : base(rasterizer, sceneTransformer)
        {
            this.lightSource = lightSource;
            this.spotLightSource = spotLightSource;
            this.parameters = parameters;
            this.cameraPosition = cameraPosition;
        }

        public override void DrawPolygon(Polygon polygon)
        {
            IColorProvider colorProvider = new ConstantShadingColorProvider(Color.OrangeRed, polygon, lightSource, spotLightSource, parameters);
            colorProvider = new FogColorProvider(colorProvider, cameraPosition, polygon.AveragePosition(), parameters.fogCoefficient);
            foreach (var pixel in polygon.GetPixelsWithInterpolatedZ(Rasterizer, sceneTransformer).Where(p => Rasterizer.CanDraw(p.Pixel, p.Z)))
            {
                Rasterizer.DrawPixel(pixel.Pixel, pixel.Z, colorProvider.GetColor(pixel.Pixel.X, pixel.Pixel.Y));
            }
        }
    }
}
