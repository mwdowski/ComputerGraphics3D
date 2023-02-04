using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public class PerspectiveSceneTransformer : BaseSceneTransformer
    {
        public PerspectiveSceneTransformer(float fieldOfView, float aspectRatio, float nearPlaneDistance, float farPlaneDistance)
            : base(Matrix4x4.CreatePerspectiveFieldOfView(fieldOfView, aspectRatio, nearPlaneDistance, farPlaneDistance))
        {
        }
    }
}
