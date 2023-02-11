using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.BarycentricInterpolation
{
    public class FloatEvaluationChain : IVectorOperationsEvaluationChain<FloatEvaluationChain, float, float>
    {
        private float value;

        public FloatEvaluationChain Add(FloatEvaluationChain impl)
        {
            value += impl.value;
            return this;
        }

        public FloatEvaluationChain Add(float vector)
        {
            value += vector;
            return this;
        }

        public float GetResult()
        {
            return value;
        }

        public FloatEvaluationChain Scale(float field)
        {
            value *= field;
            return this;
        }
    }
}
