using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public class ScaleTransformer : BaseSceneTransformer
    {
        public ScaleTransformer(float scale) : base(Matrix4x4.CreateScale(scale))
        {
        }
    }
}
