using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public abstract class BaseSceneTransformer : ISceneTransformer
    {
        protected Matrix4x4 transformMatrix;
        private ISceneTransformer? next;

        public BaseSceneTransformer(Matrix4x4 transformMatrix)
        {
            this.transformMatrix = transformMatrix;
        }

        public ISceneTransformer Then(ISceneTransformer other)
        {
            next = other;
            return this;
        }

        public Vector4 Transform(Vector4 vector)
        {
            var transformed = Vector4.Transform(vector, transformMatrix);

            if (next == null)
            {
                return transformed;
            }
            else
            {
                return next.Transform(transformed);
            }
        }
    }
}
