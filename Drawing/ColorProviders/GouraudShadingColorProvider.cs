using ComputerGraphics3D.Drawing.Algorithms;
using ComputerGraphics3D.Drawing.BarycentricInterpolation;
using ComputerGraphics3D.Extensions;
using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.ColorProviders
{
    public class GouraudShadingColorProvider : BaseShadingColorProvider
    {
        protected BarycentricTriangleInterpolator<ColorEvaluationChain, Color> ColorInterpolator;

        public GouraudShadingColorProvider(
            Color objectColor,
            Polygon polygon,
            List<Point> verticesPixels,
            LightSource lightSource,
            LightSource spotLightSource,
            PhongLightModelParameters parameters,
            Vector4 cameraPosition)
            : base(objectColor, polygon, lightSource, parameters)
        {
            ColorInterpolator = new(
                verticesPixels[0],
                PhongLightModel.GetColor(
                    objectColor,
                    polygon.Vertices[0].Position.ToVector3(),
                    polygon.Vertices[0].Normal.ToVector3(),
                    lightSource.Color,
                    lightSource.Position.ToVector3(),
                    spotLightSource.Position.ToVector3(),
                    spotLightSource.Normal.ToVector3(),
                    cameraPosition.ToVector3(),
                    parameters.ambientCoefficient,
                    parameters.diffusedCoefficient,
                    parameters.specularCoefficient,
                    parameters.specularPower),
                verticesPixels[1],
                PhongLightModel.GetColor(
                    objectColor,
                    polygon.Vertices[1].Position.ToVector3(),
                    polygon.Vertices[1].Normal.ToVector3(),
                    lightSource.Color,
                    lightSource.Position.ToVector3(),
                    spotLightSource.Position.ToVector3(),
                    spotLightSource.Normal.ToVector3(),
                    cameraPosition.ToVector3(),
                    parameters.ambientCoefficient,
                    parameters.diffusedCoefficient,
                    parameters.specularCoefficient,
                    parameters.specularPower),
                verticesPixels[2],
                PhongLightModel.GetColor(
                    objectColor,
                    polygon.Vertices[2].Position.ToVector3(),
                    polygon.Vertices[2].Normal.ToVector3(),
                    lightSource.Color,
                    lightSource.Position.ToVector3(),
                    spotLightSource.Position.ToVector3(),
                    spotLightSource.Normal.ToVector3(),
                    cameraPosition.ToVector3(),
                    parameters.ambientCoefficient,
                    parameters.diffusedCoefficient,
                    parameters.specularCoefficient,
                    parameters.specularPower)
            );
        }

        public override Color GetColor(float x, float y)
        {
            return ColorInterpolator.GetWeightInPoint(new PointF(x, y));
        }
    }
}
