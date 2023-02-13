using System.Numerics;
using static ComputerGraphics3D.Drawing.Algorithms.PhongLightModel;

namespace ComputerGraphics3D.Drawing.ColorProviders
{
    public class FogColorProvider : IColorProvider
    {
        private readonly IColorProvider inner;
        private readonly Vector3 cameraPosition;
        private readonly Vector3 objectPosition;
        private readonly float k;

        public FogColorProvider(IColorProvider inner, Vector3 cameraPosition, Vector3 objectPosition, float k)
        {
            this.inner = inner;
            this.cameraPosition = cameraPosition;
            this.objectPosition = objectPosition;
            this.k = k;
        }

        public Color GetColor(float x, float y)
        {
            var color = inner.GetColor(x, y);
            var d = (float)Vector3.Distance(cameraPosition, objectPosition);
            return Color.FromArgb(
                ScaleFloatToByte(ScaleByteToFloat(color.R) + d * k * 0.1f),
                ScaleFloatToByte(ScaleByteToFloat(color.G) + d * k * 0.1f),
                ScaleFloatToByte(ScaleByteToFloat(color.B) + d * k * 0.1f)
            );
        }
    }
}
