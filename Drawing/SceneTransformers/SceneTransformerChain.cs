using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public class SceneTransformerChain : ISceneTransformer
    {
        private SceneTransformerChain()
        {
        }

        public static ISceneTransformer Start()
        {
            return new SceneTransformerChain();
        }

        public ISceneTransformer Then(ISceneTransformer other)
        {
            return other;
        }

        public Vector4 Transform(Vector4 vector)
        {
            return vector;
        }
    }
}
