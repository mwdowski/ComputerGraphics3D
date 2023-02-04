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
    public abstract class BaseFigureDrawer3D : BaseFigureDrawer2D
    {
        protected ISceneTransformer sceneTransformer;

        protected BaseFigureDrawer3D(Rasterizer rasterizer, ISceneTransformer sceneTransformer) : base(rasterizer)
        {
            this.sceneTransformer = sceneTransformer;
        }

        public override abstract void DrawPolygon(Polygon polygon);
    }
}
