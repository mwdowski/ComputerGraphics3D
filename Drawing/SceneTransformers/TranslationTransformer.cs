using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public class TranslationTransformer : BaseSceneTransformer
    {
        public TranslationTransformer(Vector3 translation) : base(Matrix4x4.CreateTranslation(translation))
        {
        }
    }
}
