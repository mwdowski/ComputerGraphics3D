using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.BarycentricInterpolation
{
    public interface IVectorOperationsEvaluationChain<TImpl, TField, TVector>
    {
        TImpl Add(TImpl impl);
        TImpl Add(TVector vector);
        TImpl Scale(TField field);
        TVector GetResult();
    }
}
