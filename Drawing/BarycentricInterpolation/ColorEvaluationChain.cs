using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.BarycentricInterpolation
{
    public class ColorEvaluationChain : IVectorOperationsEvaluationChain<ColorEvaluationChain, float, Color>
    {
        float currentR = 0;
        float currentG = 0;
        float currentB = 0;
        float currentA = 0;

        private void SetCurrentValues(float r, float g, float b, float a)
        {
            currentR = r;
            currentG = g;
            currentB = b;
            currentA = a;
        }

        public ColorEvaluationChain() { }

        public ColorEvaluationChain Add(ColorEvaluationChain chain)
        {
            SetCurrentValues(currentR + chain.currentR, currentG + chain.currentG, currentB + chain.currentB, currentA + chain.currentA);
            return this;
        }

        public ColorEvaluationChain Add(Color color)
        {
            SetCurrentValues(currentR + color.R, currentG + color.G, currentB + color.B, currentA + color.A);
            return this;
        }

        public ColorEvaluationChain Scale(float a)
        {
            SetCurrentValues(currentR * a, currentG * a, currentB * a, currentA * a);
            return this;
        }

        public Color GetResult()
        {
            return Color.FromArgb(Cut(currentA), Cut(currentR), Cut(currentG), Cut(currentB));
        }

        private static byte Cut(int value)
        {
            value = value > 255 ? 255 : value;
            value = value < 0 ? 0 : value;

            return (byte)value;
        }

        private static byte Cut(float value)
        {
            return Cut((int)value);
        }
    }
}
