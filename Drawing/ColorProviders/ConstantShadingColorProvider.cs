using ComputerGraphics3D.Drawing.Algorithms;
using ComputerGraphics3D.Extensions;
using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.ColorProviders
{
    public class ConstantShadingColorProvider : BaseShadingColorProvider
    {
        private Color color;

        public LightSource SpotLightSource { get; }

        public ConstantShadingColorProvider(
            Color objectColor,
            Polygon polygon,
            LightSource lightSource,
            LightSource spotLightSource,
            PhongLightModelParameters parameters)
            : base(objectColor, polygon, lightSource, parameters)
        {
            SpotLightSource = spotLightSource;
            CalculateInnerColor();
        }

        private void CalculateInnerColor()
        {
            var averagePosition = new Vector4(
                polygon.Vertices.Average(v => v.Position.X),
                polygon.Vertices.Average(v => v.Position.Y),
                polygon.Vertices.Average(v => v.Position.Z),
                polygon.Vertices.Average(v => v.Position.W)
            );

            var averageNormal = new Vector4(
                polygon.Vertices.Average(v => v.Normal.X),
                polygon.Vertices.Average(v => v.Normal.Y),
                polygon.Vertices.Average(v => v.Normal.Z),
                polygon.Vertices.Average(v => v.Normal.W)
            );

            color = PhongLightModel.GetColor(
                objectColor,
                averagePosition.ToVector3(),
                averageNormal.ToVector3(),
                lightSource.Color,
                lightSource.Position.ToVector3(),
                SpotLightSource.Position.ToVector3(),
                SpotLightSource.Normal.ToVector3(),
                cameraPosition.ToVector3(),
                parameters.ambientCoefficient,
                parameters.diffusedCoefficient,
                parameters.specularCoefficient,
                parameters.specularPower
            );
        }

        public override Color GetColor(float x, float y)
        {
            return color;
        }
    }
}
