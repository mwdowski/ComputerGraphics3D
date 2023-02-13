using ComputerGraphics3D.Canvases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.Rasterizers
{
    public interface IRasterizer
    {
        ICanvas Canvas { get; }
        bool CanDraw(Vector4 vector);
        bool CanDraw(Point pixel, float z);
        void DrawPoint(Vector4 vector, Color color);
        void DrawPixel(Point pixel, float z, Color color);
        Color GetPixel(Point pixel);
        Point GetPositionOnCanvas(Vector4 vector);
        PointF GetPixelCoordinates(Point pixel);
    }
}
