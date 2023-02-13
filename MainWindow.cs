using ComputerGraphics3D.Canvases;
using ComputerGraphics3D.Drawing.ColorProviders;
using ComputerGraphics3D.Drawing.FigureDrawers;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Drawing.SceneTransformers;
using ComputerGraphics3D.Extensions;
using ComputerGraphics3D.Loaders;
using ComputerGraphics3D.Model;
using System.Linq;
using System.Numerics;

namespace ComputerGraphics3D
{
    public partial class MainWindow : Form
    {
        MyScene scene;
        ICanvas canvas;
        ZBufferedRasterizer rasterizer;
        float camX = 12f;
        float camY = -3f;
        float camZ = 10f;
        IFigureDrawer figureDrawer;
        ISceneTransformer sceneTransformer;
        Vector3 staticCameraPosition;
        Vector3 staticLookAt = new Vector3(2f, 0f, 0f);
        Vector4 cameraPosition;

        Shading shading = Shading.Constant;
        private enum Shading { Constant, Gourard, Phong }

        CameraType cameraType = CameraType.Static;
        private enum CameraType { Static, NotMovingFollowing, MovingFollowing }

        public MainWindow()
        {
            InitializeComponent();
            staticCameraPosition = new Vector3(camX, camY, camZ);
            cameraPosition = new Vector4(staticCameraPosition, 1f);
            scene = MyScene.LoadFromFiles();
            canvas = new DirectBitmapCanvas(pictureBox1);
            rasterizer = new(canvas);
            sceneTransformer = GetSceneTransformer();
            figureDrawer = GetFigureDrawer();
            timer.Start();
            Redraw();
        }

        private IFigureDrawer GetFigureDrawer()
        {
            sceneTransformer = GetSceneTransformer();
            switch (shading)
            {
                case Shading.Constant:
                    return new ConstantShadingFigureDrawer3D(
                        rasterizer,
                        sceneTransformer,
                        new LightSource(new Vector3(500f, 100f, 300f), Vector3.Zero, Color.Gray),
                        scene.CubeSpotlight,
                        new PhongLightModelParameters
                        {
                            ambientCoefficient = ambientCoefficient,
                            diffusedCoefficient = 0.7f,
                            specularCoefficient = 0.4f,
                            specularPower = 1,
                            fogCoefficient = this.fogCoefficient
                        },
                        cameraPosition.ToVector3()
                    );
                case Shading.Gourard:
                    return new GouraudShading3DFigureDrawer(
                        rasterizer,
                        sceneTransformer,
                        new LightSource(new Vector3(500f, 100f, 300f), Vector3.Zero, Color.Gray),
                        scene.CubeSpotlight,
                        new PhongLightModelParameters
                        {
                            ambientCoefficient = ambientCoefficient,
                            diffusedCoefficient = 0.7f,
                            specularCoefficient = 0.4f,
                            specularPower = 1,
                            fogCoefficient = this.fogCoefficient
                        },
                        cameraPosition
                    );
                case Shading.Phong:
                    return new PhongShading3DFigureDrawer(
                        rasterizer,
                        sceneTransformer,
                        new LightSource(new Vector3(500f, 100f, 300f), Vector3.Zero, Color.Gray),
                        scene.CubeSpotlight,
                        new PhongLightModelParameters
                        {
                            ambientCoefficient = ambientCoefficient,
                            diffusedCoefficient = 0.7f,
                            specularCoefficient = 0.4f,
                            specularPower = 1,
                            fogCoefficient = this.fogCoefficient
                        },
                        cameraPosition
                    );
            }

            return null;
        }

        private ISceneTransformer GetSceneTransformer()
        {
            switch (cameraType)
            {
                case CameraType.Static:
                    cameraPosition = new Vector4(staticCameraPosition, 1f);
                    return SceneTransformerChain.Start()
                        .Then(new ViewSceneTransformer(cameraPosition.ToVector3(), staticLookAt))
                        .Then(new PerspectiveSceneTransformer(3.14f * 0.3333f, 1f, 1f, 100f));
                case CameraType.NotMovingFollowing:
                    cameraPosition = new Vector4(staticCameraPosition, 1f);
                    return SceneTransformerChain.Start()
                        .Then(new ViewSceneTransformer(cameraPosition.ToVector3(), scene.CubeCenterPosition))
                        .Then(new PerspectiveSceneTransformer(3.14f * 0.3333f, 1f, 1f, 100f));
                case CameraType.MovingFollowing:
                    var cubeCenter = scene.CubeCenterPosition;
                    var z = 9f * cubeCenter.X / (float)Math.Sqrt(cubeCenter.X * cubeCenter.X + cubeCenter.Z * cubeCenter.Z);
                    var x = -z * cubeCenter.Z / cubeCenter.X;
                    cameraPosition = new Vector4(x, cubeCenter.Y - 2f, z, 1f);
                    return SceneTransformerChain.Start()
                        .Then(new ViewSceneTransformer(cameraPosition.ToVector3(), cubeCenter))
                        .Then(new PerspectiveSceneTransformer(3.14f * 0.3333f, 1f, 1f, 100f));
            }
            return null;
        }

        void Redraw()
        {
            figureDrawer = GetFigureDrawer();
            using var g = Graphics.FromImage(canvas.Bitmap);
            g.Clear(Color.White);
            rasterizer.Refresh();
            scene?.Draw(figureDrawer);
            pictureBox1.Refresh();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            scene.PerformFrameMove();
            Redraw();
        }

        private void constantShadingModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                shading = Shading.Constant;
                Redraw();
            }
        }

        private void gouraudShadingModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                shading = Shading.Gourard;
                Redraw();
            }
        }

        private void phongShadingModeRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                shading = Shading.Phong;
                Redraw();
            }
        }

        private void movingObjectCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            scene.EnableVibrations(((CheckBox)sender).Checked);
        }

        private void staticCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                cameraType = CameraType.Static;
                Redraw();
            }
        }

        private void notMovingFollowingCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                cameraType = CameraType.NotMovingFollowing;
                Redraw();
            }
        }

        private void movingFollowingCameraRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                cameraType = CameraType.MovingFollowing;
                Redraw();
            }
        }

        private float fogCoefficient = 0.0f;

        private void fogTrackBar_Scroll(object sender, EventArgs e)
        {
            fogCoefficient = fogTrackBar.Value / 100f;
        }

        private float ambientCoefficient = 0.2f;

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            ambientCoefficient = trackBar1.Value / 100f;
        }

        private void movingLightDirectionTrackBar_Scroll(object sender, EventArgs e)
        {
            scene.SetLightOffset((float)Math.PI * 180f / movingLightDirectionTrackBar.Value / 2);
            Redraw();
        }
    }
}