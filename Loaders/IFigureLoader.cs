using ComputerGraphics3D.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Loaders
{
    public interface IFileFigureLoader
    {
        Figure? LoadFigureFromFile(string filename);
    }
}
