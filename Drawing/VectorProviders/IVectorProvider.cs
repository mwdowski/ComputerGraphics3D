using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.Drawing
{
    internal interface IVectorProvider
    {
        Vector3 GetVector(int x, int y);
    }
}
