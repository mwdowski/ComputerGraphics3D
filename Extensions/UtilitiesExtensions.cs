using System.Numerics;

namespace ComputerGraphics3D.Extensions
{
    public static class UtilitiesExtensions
    {
        public static PointF ToPointF(this Vector4 vector)
        {
            return new PointF(vector.X / vector.W, vector.Y / vector.W);
        }

        public static Vector3 ToVector3(this Vector4 vector)
        {
            return new Vector3(vector.X / vector.W, vector.Y / vector.W, vector.Z / vector.W);
        }
        public static PointF Scaled(this PointF vector, float a)
        {
            return new PointF(vector.X * a, vector.Y * a);
        }
    }
}
