namespace ComputerGraphics3D.Drawing.ColorProviders
{
    public interface IColorProvider
    {
        Color GetColor(float x, float y);
    }

    public static class ColorProviderExtensions
    {
        public static Color GetColor(this IColorProvider colorProvider, PointF point)
        {
            return colorProvider.GetColor(point.X, point.Y);
        }
    }
}
