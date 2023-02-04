using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public class ViewSceneTransformer : BaseSceneTransformer
    {
        public ViewSceneTransformer(Vector3 cameraPosition, Vector3 lookAt)
            : base(Matrix4x4.CreateLookAt(cameraPosition, lookAt, Vector3.UnitY))
        {
        }
    }
}
