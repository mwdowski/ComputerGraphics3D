using ComputerGraphics3D.Drawing.SceneTransformers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Model
{
    public class LightSource : Vertex
    {
        public readonly Color Color;

        public LightSource(Vector3 position, Vector3 normal, Color color) : base(position, normal)
        {
            Color = color;
        }

        public LightSource(Vector4 position, Vector4 normal, Color color) : base(position, normal)
        {
            Color = color;
        }

        public override LightSource GetTransformed(ISceneTransformer sceneTransformer)
        {
            return new LightSource(sceneTransformer.Transform(Position), sceneTransformer.Transform(Normal), Color);
        }
    }
}
