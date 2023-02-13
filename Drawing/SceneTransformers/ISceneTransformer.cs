using ComputerGraphics3D.Model;
using System.Numerics;

namespace ComputerGraphics3D.Drawing.SceneTransformers
{
    public interface ISceneTransformer
    {
        ISceneTransformer Then(ISceneTransformer other);
        Vector4 Transform(Vector4 vector);
        Vector4 TransformNormal(Vector4 vector);
    }

    public static class SceneTranformerExtensions
    {
        public static Vertex Transform(this ISceneTransformer sceneTranformer, Vertex vertex)
        {
            return new Vertex(
                sceneTranformer.Transform(vertex.Position),
                sceneTranformer.TransformNormal(vertex.Normal)
            );
        }
    }
}
