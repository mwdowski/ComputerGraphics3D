using ComputerGraphics3D.Drawing.FigureDrawers;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Drawing.Algorithms;
using ComputerGraphics3D.Drawing.BarycentricInterpolation;
using ComputerGraphics3D.Drawing.SceneTransformers;

namespace ComputerGraphics3D.Model
{
    public class Polygon : Figure
    {
        public List<Vertex> Vertices { get; private set; }

        public Polygon() : base()
        {
            Vertices = new();
        }

        public IEnumerable<(Point Pixel, float Z)> GetPixelsWithInterpolatedZ(IRasterizer rasterizer, ISceneTransformer sceneTransformer)
        {
            var transformedVertices = Vertices
                .Select(v => sceneTransformer.Transform(v.Position))
                .ToList();

            var verticesPixels = transformedVertices
                .Select(p => rasterizer.GetPositionOnCanvas(p))
                .ToList();

            var zInterpolator = new BarycentricTriangleInterpolator<FloatEvaluationChain, float>(
                verticesPixels[0], transformedVertices[0].Z,
                verticesPixels[1], transformedVertices[1].Z,
                verticesPixels[2], transformedVertices[2].Z
            );

            return PolygonFilling
                .GetInsidePixels(verticesPixels)
                .Select(p => (p, zInterpolator.GetWeightInPoint(p)));
        }

        public override void Draw(IFigureDrawer drawer)
        {
            drawer.DrawPolygon(this);
        }
    }
}
