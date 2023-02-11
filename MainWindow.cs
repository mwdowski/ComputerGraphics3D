using ComputerGraphics3D.Canvases;
using ComputerGraphics3D.Drawing.FigureDrawers;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Drawing.SceneTransformers;
using ComputerGraphics3D.Loaders;
using ComputerGraphics3D.Model;
using System.Numerics;

namespace ComputerGraphics3D
{
    public partial class MainWindow : Form
    {
        ObjFileLoader loader = new();
        Figure? figure;
        ICanvas canvas;
        ZBufferedRasterizer rasterizer;
        float camX = 5f;
        float camY = 0f;
        float camZ = 3f;

        public MainWindow()
        {
            InitializeComponent();
            figure = loader.LoadFigureFromFile("Resources\\torus.obj");
            canvas = new DirectBitmapCanvas(pictureBox1);
            rasterizer = new(canvas);
            Redraw();
        }

        void Redraw()
        {
            Vector3 staticCameraPosition = new Vector3(camX, camY, camZ);
            Vector3 staticCameraLookAt = new Vector3(0f, 0f, 0f);
            ISceneTransformer sceneTransformer = SceneTransformerChain.Start()
                .Then(new ViewSceneTransformer(staticCameraPosition, staticCameraLookAt))
                .Then(new PerspectiveSceneTransformer(3.14f * 0.3333f, 1f, 1f, 100f));
            using var g = Graphics.FromImage(canvas.Bitmap);
            g.Clear(Color.White);
            rasterizer.Refresh();
            //IFigureDrawer drawer = new ConstantColorFigureDrawer3D(rasterizer, sceneTransformer, Color.Red);
            IFigureDrawer drawer = new RandomColorFigureDrawer3D(rasterizer, sceneTransformer);
            figure?.Draw(drawer);
            pictureBox1.Refresh();
        }

        int oldY = -1;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (oldY < 0)
            {
                oldY = e.Y;
            }

            int delta = e.Y - oldY;
            camY += delta / 10f;
            oldY = e.Y;
            Redraw();
        }
    }
}