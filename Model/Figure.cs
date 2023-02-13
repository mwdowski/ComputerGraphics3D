using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ComputerGraphics3D.Canvases;
using ComputerGraphics3D.Drawing.FigureDrawers;
using ComputerGraphics3D.Drawing.SceneTransformers;

namespace ComputerGraphics3D.Model
{
    public abstract class Figure
    {
        public abstract void Draw(IFigureDrawer drawer);
        public abstract Figure GetTransformed(ISceneTransformer sceneTransformer);
        public abstract Vector3 AveragePosition();
    }
}
