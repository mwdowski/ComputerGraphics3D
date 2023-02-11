using ComputerGraphics3D.Drawing.Algorithms;
using ComputerGraphics3D.Drawing.ColorProviders;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Drawing.SceneTransformers;
using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.FigureDrawers
{
    public class ConstantColorFigureDrawer3D : BaseFigureDrawer3D
    {
        private readonly Color color;

        public ConstantColorFigureDrawer3D(ZBufferedRasterizer rasterizer, ISceneTransformer sceneTransformer, Color color) : base(rasterizer, sceneTransformer)
        {
            this.color = color;
        }

        public override void DrawPolygon(Polygon polygon)
        {
            // todo
        }
    }
}
