using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public interface ISceneTransformer
    {
        ISceneTransformer Then(ISceneTransformer other);
        Vector4 Transform(Vector4 vector);
    }
}
