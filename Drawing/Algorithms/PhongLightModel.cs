using System.Numerics;
using System.Runtime.CompilerServices;

namespace ComputerGraphics3D.Drawing.Algorithms
{
    public static class PhongLightModel
    {
        public static Color GetColor(
            Color objectColor,
            Vector4 objectPosition,
            Vector4 objectNormal,
            Color lightColor,
            Vector4 lightSourcePosition,
            Vector4 cameraPosition,
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
                        cameraPosition,
                        ambientCoefficient,
                        diffusedCoefficient,
                        specularCoefficient,
                        specularPower)),
                ScaleFloatToByte(
                    GetPhongOneComponent(
                        ScaleByteToFloat(objectColor.R),
                        objectPosition,
                        objectNormal,
                        ScaleByteToFloat(lightColor.R),
                        lightSourcePosition,
                        cameraPosition,
                        ambientCoefficient,
                        diffusedCoefficient,
                        specularCoefficient,
                        specularPower)),
                ScaleFloatToByte(
                    GetPhongOneComponent(
                        ScaleByteToFloat(objectColor.R),
                        objectPosition,
                        objectNormal,
                        ScaleByteToFloat(lightColor.R),
                        lightSourcePosition,
                        cameraPosition,
                        ambientCoefficient,
                        diffusedCoefficient,
                        specularCoefficient,
                        specularPower))
            );
        }

        private static float GetPhongOneComponent(
            float objectIntensity,
            Vector4 objectPosition,
            Vector4 objectNormal,
            float lightIntensity,
            Vector4 lightSourcePosition,
            Vector4 cameraPosition,
            float ambientCoefficient,
            float diffusedCoefficient,
            float specularCoefficient,
            int specularPower)
        {
            var lightDirection = lightSourcePosition - objectPosition;
            var cameraDirection = cameraPosition - objectPosition;
            return objectIntensity * (
                GetPhongAmbientComponent(ambientCoefficient)
                + GetPhongDiffusedComponent(lightIntensity, diffusedCoefficient, objectNormal, lightDirection)
                + GetPhongSpecularComponent(lightIntensity, specularCoefficient, specularPower, objectNormal, lightDirection, cameraDirection)
            );
        }

        private static float GetPhongAmbientComponent(float ambietnCoefficient)
        {
            return ambietnCoefficient;
        }

        private static float GetPhongDiffusedComponent(float lightIntensity, float diffuseCoefficient, Vector4 objectNormal, Vector4 lightDirection)
        {
            return lightIntensity * diffuseCoefficient * PositiveOrZero(CosAngle(objectNormal, lightDirection));
        }
        private static float GetPhongSpecularComponent(float lightIntensity, float specularCoefficient, int specularPower, Vector4 objectNormal, Vector4 lightDirection, Vector4 cameraDirection)
        {
            var reflectionVector = 2 * Vector4.Dot(objectNormal, lightDirection) * objectNormal - lightDirection;
            return specularCoefficient * lightIntensity * PositiveOrZero((float)Math.Pow(CosAngle(cameraDirection, reflectionVector), specularPower));
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

        private static float ScaleByteToFloat(byte b)
        {
            return b / 255f;
        }

        private static byte ScaleFloatToByte(float f)
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

        private static float CosAngle(Vector4 a, Vector4 b)
        {
            return Vector4.Dot(a, b) / a.Length() / b.Length();
        }

        private static float PositiveOrZero(float value)
        {
            return value > 0 ? value : 0;
        }
    }
}
