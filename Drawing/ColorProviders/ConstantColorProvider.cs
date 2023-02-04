using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.ColorProviders
{
    public class ConstantColorProvider : IColorProvider
    {
        protected readonly Color Color;

        public ConstantColorProvider(Color color)
        {
            Color = color;
        }

        public virtual Color GetColor(float x, float y)
        {
            return Color;
        }
    }
}
