using System.Numerics;
using System.Runtime.CompilerServices;

namespace ComputerGraphics3D.Drawing.Algorithms
{
    public static class PhongLightModel
    {
        public static Color GetColor(
            Color objectColor,
            Vector3 objectPosition,
            Vector3 objectNormal,
            Color lightColor,
            Vector3 lightSourcePosition,
            Vector3 spotlightSourcePosition,
            Vector3 spotlightSourceNormal,
            Vector3 cameraPosition,
            float ambientCoefficient,
            float diffusedCoefficient,
            float specularCoefficient,
            int specularPower)
        {
            return Color.FromArgb(
                ScaleFloatToByte(
                    GetPhongOneComponent(
                        ScaleByteToFloat(objectColor.R),
                        objectPosition,
                        objectNormal,
                        ScaleByteToFloat(lightColor.R),
                        lightSourcePosition,
                        spotlightSourcePosition,
                        spotlightSourceNormal,
                        cameraPosition,
                        ambientCoefficient,
                        diffusedCoefficient,
                        specularCoefficient,
                        specularPower)),
                ScaleFloatToByte(
                    GetPhongOneComponent(
                        ScaleByteToFloat(objectColor.G),
                        objectPosition,
                        objectNormal,
                        ScaleByteToFloat(lightColor.G),
                        lightSourcePosition,
                        spotlightSourcePosition,
                        spotlightSourceNormal,
                        cameraPosition,
                        ambientCoefficient,
                        diffusedCoefficient,
                        specularCoefficient,
                        specularPower)),
                ScaleFloatToByte(
                    GetPhongOneComponent(
                        ScaleByteToFloat(objectColor.B),
                        objectPosition,
                        objectNormal,
                        ScaleByteToFloat(lightColor.B),
                        lightSourcePosition,
                        spotlightSourcePosition,
                        spotlightSourceNormal,
                        cameraPosition,
                        ambientCoefficient,
                        diffusedCoefficient,
                        specularCoefficient,
                        specularPower))
            );
        }

        private static float GetPhongOneComponent(
            float objectIntensity,
            Vector3 objectPosition,
            Vector3 objectNormal,
            float lightIntensity,
            Vector3 lightSourcePosition,
            Vector3 spotlightSourcePosition,
            Vector3 spotlightSourceNormal,
            Vector3 cameraPosition,
            float ambientCoefficient,
            float diffusedCoefficient,
            float specularCoefficient,
            int specularPower)
        {
            var lightDirection = lightSourcePosition - objectPosition;
            spotlightSourcePosition = spotlightSourcePosition - objectPosition;
            var cameraDirection = cameraPosition - objectPosition;
            return objectIntensity * (
                GetPhongAmbientComponent(ambientCoefficient)
                + GetPhongDiffusedComponent(lightIntensity, diffusedCoefficient, objectNormal, lightDirection,
                    spotlightSourcePosition,  spotlightSourceNormal)
                + GetPhongSpecularComponent(lightIntensity, specularCoefficient, specularPower, objectNormal, lightDirection, cameraDirection,
                        spotlightSourcePosition, spotlightSourceNormal)
            );
        }

        private static float GetPhongAmbientComponent(float ambietnCoefficient)
        {
            return ambietnCoefficient;
        }

        private static float GetPhongDiffusedComponent(float lightIntensity, float diffuseCoefficient, Vector3 objectNormal, Vector3 lightDirection,
                        Vector3 spotlightSourcePosition, Vector3 spotlightSourceNormal)
        {
            return lightIntensity * (1 + (float)Math.Pow(CosAngle(spotlightSourcePosition, spotlightSourceNormal), 100f) * diffuseCoefficient
                * PositiveOrZero(CosAngle(objectNormal, lightDirection)));
        }
        private static float GetPhongSpecularComponent(float lightIntensity, float specularCoefficient, int specularPower, Vector3 objectNormal,
            Vector3 lightDirection, Vector3 cameraDirection, Vector3 spotlightSourcePosition, Vector3 spotlightSourceNormal)
        {
            var reflectionVector = 2 * Vector3.Dot(objectNormal, lightDirection) * objectNormal - lightDirection;
            return specularCoefficient * lightIntensity * (1 + (float)Math.Pow(CosAngle(spotlightSourcePosition, spotlightSourceNormal), 100f))
                * PositiveOrZero((float)Math.Pow(CosAngle(cameraDirection, reflectionVector), specularPower));
        }

        /*
        public static Color GetLambertColor(Color objectColor, Color lightColor, Vector3 normalVector, Vector3 lightVector, int m, float k_d, float k_s)
        {
            return Color.FromArgb(
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(objectColor.R), ScaleByteToFloat(lightColor.R), normalVector, lightVector, m, k_d, k_s)),
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(objectColor.G), ScaleByteToFloat(lightColor.G), normalVector, lightVector, m, k_d, k_s)),
                ScaleFloatToByte(GetLambertOneComponent(ScaleByteToFloat(objectColor.B), ScaleByteToFloat(lightColor.B), normalVector, lightVector, m, k_d, k_s))
            );
        }

        private static float GetLambertOneComponent(float objectColor, float lightColor, Vector3 normalVector, Vector3 lightVector, int m, float k_d, float k_s)
        {
            return GetLambertLightComponent(objectColor, lightColor, normalVector, k_d, lightVector)
                 + GetLambertReflectionComponent(objectColor, lightColor, normalVector, k_s, m, lightVector);
        }
        */

        public static float ScaleByteToFloat(byte b)
        {
            return b / 255f;
        }

        public static byte ScaleFloatToByte(float f)
        {
            return (byte)(PositiveOrZero(f > 1 ? 1 : f) * 255);
        }

        /*
        private static float GetLambertLightComponent(float objectColor, float lightColor, Vector3 normalVector, float k_d, Vector3 lightVector)
        {
            return k_d * objectColor * lightColor * PositiveOrZero(CosAngle(normalVector, lightVector));
        }

        private static float GetLambertReflectionComponent(float objectColor, float lightColor, Vector3 normalVector, float k_s, int m, Vector3 lightVector)
        {
            var reflectionVector = 2 * Vector3.Dot(normalVector, lightVector) * normalVector - lightVector;
            return k_s * objectColor * lightColor * PositiveOrZero((float)Math.Pow(CosAngle(normalVector, reflectionVector), m));
        }

        private static float CosAngle(Vector3 a, Vector3 b)
        {
            return Vector3.Dot(a, b) / a.Length() / b.Length();
        }
        */

        private static float CosAngle(Vector3 a, Vector3 b)
        {
            return Vector3.Dot(a, b) / a.Length() / b.Length();
        }

        private static float PositiveOrZero(float value)
        {
            return value > 0 ? value : 0;
        }
    }
}
