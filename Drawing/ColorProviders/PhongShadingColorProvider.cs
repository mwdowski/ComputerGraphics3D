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
    public class PhongShadingColorProvider : BaseShadingColorProvider
    {
        protected readonly BarycentricTriangleInterpolator<Vector3EvaluationChain, Vector3> NormalsInterpolator;
        protected readonly BarycentricTriangleInterpolator<Vector3EvaluationChain, Vector3> PositionInterpolator;

        public PhongShadingColorProvider(
            Color objectColor,
            Polygon polygon,
            List<Point> verticesPixels,
            LightSource lightSource,
            LightSource spotLightSource,
            PhongLightModelParameters parameters,
            Vector4 cameraPosition)
            : base(objectColor, polygon, lightSource, parameters)
        {
            NormalsInterpolator = new(
                verticesPixels[0],
                polygon.Vertices[0].Normal.ToVector3(),
                verticesPixels[1],
                polygon.Vertices[1].Normal.ToVector3(),
                verticesPixels[2],
                polygon.Vertices[2].Normal.ToVector3()
            );

            PositionInterpolator = new(
                verticesPixels[0],
                polygon.Vertices[0].Position.ToVector3(),
                verticesPixels[1],
                polygon.Vertices[1].Position.ToVector3(),
                verticesPixels[2],
                polygon.Vertices[2].Position.ToVector3()
            );
            SpotLightSource = spotLightSource;
            CameraPosition = cameraPosition;
        }

        public LightSource SpotLightSource { get; }
        public Vector4 CameraPosition { get; }

        public override Color GetColor(float x, float y)
        {
            return PhongLightModel.GetColor(
                Color.OrangeRed,
                PositionInterpolator.GetWeightInPoint(new PointF(x, y)),
                NormalsInterpolator.GetWeightInPoint(new PointF(x, y)),
                lightSource.Color,
                lightSource.Position.ToVector3(),
                SpotLightSource.Position.ToVector3(),
                SpotLightSource.Normal.ToVector3(),
                CameraPosition.ToVector3(),
                parameters.ambientCoefficient,
                parameters.diffusedCoefficient,
                parameters.specularCoefficient,
                parameters.specularPower
            );
        }
    }
}
