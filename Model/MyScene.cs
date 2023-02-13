using ComputerGraphics3D.Drawing.FigureDrawers;
using ComputerGraphics3D.Drawing.SceneTransformers;
using ComputerGraphics3D.Extensions;
using ComputerGraphics3D.Loaders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Model
{
    public class MyScene : Figure
    {
        private Figure sphere;
        private Figure torus;
        private Figure cube;
        private LightSource cubeSpotlight;
        public LightSource CubeSpotlight
        {
            get
            {
                return cubeSpotlight.GetTransformed(
                    SceneTransformerChain.Start()
                        .Then(new TranslationTransformer(cubeSpotlight.Position.ToVector3()))
                        .Then(tr)
                        .Then(new TranslationTransformer(-cubeSpotlight.Position.ToVector3()))
                );
            }
        }
        public Vector3 CubeCenterPosition
        {
            get => cube.AveragePosition();
        }

        ISceneTransformer tr = new BaseSceneTransformer(Matrix4x4.Identity);
        public void SetLightOffset(float radians)
        {
            tr = new BaseSceneTransformer(Matrix4x4.CreateRotationY(radians));
        }

        private bool? vibrated = null;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        private MyScene()
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
        }

        public static MyScene LoadFromFiles()
        {
            var result = new MyScene();
            ObjFileLoader loader = new();

            result.torus = loader
                .LoadFigureFromFile("Resources\\torus.obj")!
                .GetTransformed(new TranslationTransformer(new Vector3(5f, 0f, 0f)));

            result.sphere = loader.LoadFigureFromFile("Resources\\sphere.obj")!;
            result.cube = loader
                .LoadFigureFromFile("Resources\\cube.obj")!
                .GetTransformed(new TranslationTransformer(new Vector3(0f, 0f, 3f)));
            result.cubeSpotlight = new LightSource(new Vector3(0f, 0f, 3f), new Vector3(0f, 0f, -3f), Color.White);

            return result;
        }

        public override void Draw(IFigureDrawer drawer)
        {
            sphere.Draw(drawer);
            torus.Draw(drawer);
            cube.Draw(drawer);
        }

        public override Figure GetTransformed(ISceneTransformer sceneTransformer)
        {
            var result = new MyScene();

            result.torus = torus.GetTransformed(sceneTransformer);
            result.sphere = sphere.GetTransformed(sceneTransformer);
            result.cube = cube.GetTransformed(sceneTransformer);

            return result;
        }

        public void PerformFrameMove()
        {
            ISceneTransformer transformer = SceneTransformerChain.Start()
                .Then(new BaseSceneTransformer(Matrix4x4.CreateRotationY(0.03f)));

            if (vibrated.HasValue)
            {
                if (vibrated.Value)
                {
                    transformer.Then(new TranslationTransformer(new Vector3(0f, 0.1f, 0f)));
                }
                else
                {
                    transformer.Then(new TranslationTransformer(new Vector3(0f, -0.1f, 0f)));
                }

                vibrated = !vibrated;
            }

            cube = cube.GetTransformed(transformer);
            cubeSpotlight = cubeSpotlight.GetTransformed(transformer);
        }

        public void EnableVibrations(bool enable)
        {
            vibrated = enable ? true : null;
        }

        public override Vector3 AveragePosition()
        {
            throw new NotImplementedException();
        }
    }
}
