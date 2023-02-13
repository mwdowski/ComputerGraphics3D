using ComputerGraphics3D.Model;
using System.Numerics;

namespace ComputerGraphics3D.Drawing.ColorProviders
{
    public abstract class BaseShadingColorProvider : IColorProvider
    {
        protected readonly Color objectColor;
        protected readonly Polygon polygon;
        protected readonly LightSource lightSource;
        protected readonly PhongLightModelParameters parameters;
        protected readonly Vector4 cameraPosition = new(0f, 0f, 1_000_000f, 1f);

        public BaseShadingColorProvider(
            Color objectColor,
            Polygon polygon,
            LightSource lightSource,
            PhongLightModelParameters parameters)
        {
            this.objectColor = objectColor;
            this.polygon = polygon;
            this.lightSource = lightSource;
            this.parameters = parameters;
        }

        public abstract Color GetColor(float x, float y);
    }

    public record PhongLightModelParameters
    {
        public float ambientCoefficient;
        public float diffusedCoefficient;
        public float specularCoefficient;
        public int specularPower;
        public float fogCoefficient;
    }
}
