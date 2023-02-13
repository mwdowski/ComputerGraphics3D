using ComputerGraphics3D.Drawing.ColorProviders;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Drawing.SceneTransformers;
using ComputerGraphics3D.Extensions;
using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public class PhongShading3DFigureDrawer : BaseFigureDrawer3D
    {
        private readonly LightSource lightSource;
        private readonly LightSource spotLightSource;
        private readonly PhongLightModelParameters parameters;
        private readonly Vector4 cameraPosition;

        public PhongShading3DFigureDrawer(
            ZBufferedRasterizer rasterizer,
            ISceneTransformer sceneTransformer,
            LightSource lightSource,
            LightSource spotLightSource,
            PhongLightModelParameters parameters,
            Vector4 cameraPosition
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
            IColorProvider colorProvider = new PhongShadingColorProvider(
                Color.OrangeRed,
                polygon,
                polygon
                    .GetTransformed(sceneTransformer)
                    .Vertices
                    .Select(v => Rasterizer.GetPositionOnCanvas(v.Position))
                    .ToList(),
                lightSource,
                spotLightSource,
                parameters,
                cameraPosition
            );

            colorProvider = new FogColorProvider(colorProvider, cameraPosition.ToVector3(), polygon.AveragePosition(), parameters.fogCoefficient);

            foreach (var (Pixel, Z) in polygon.GetPixelsWithInterpolatedZ(Rasterizer, sceneTransformer))
            {
                Rasterizer.DrawPixel(Pixel, Z, colorProvider.GetColor(Pixel));
            }
        }
    }
}
