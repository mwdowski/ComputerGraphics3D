using ComputerGraphics3D.Canvases;
using ComputerGraphics3D.Drawing.FigureDrawers;
using ComputerGraphics3D.Drawing.Rasterizers;
using ComputerGraphics3D.Loaders;
using ComputerGraphics3D.Model;

namespace ComputerGraphics3D
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();

            ICanvas canvas = new DirectBitmapCanvas(pictureBox1);
            Rasterizer rasterizer = new(canvas, 2f);
            ObjFileLoader loader = new();
            Figure? torus = loader.LoadFigureFromFile("Resources\\sphere.obj");
            IFigureDrawer drawer = new EdgesOnlyFigureDrawer(rasterizer);
            torus?.Draw(drawer);
        }
    }
}