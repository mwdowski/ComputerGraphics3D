using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.BarycentricInterpolation
{
    public class Vector3EvaluationChain : IVectorOperationsEvaluationChain<Vector3EvaluationChain, float, Vector3>
    {
        private Vector3 value;

        public Vector3EvaluationChain Add(Vector3EvaluationChain impl)
        {
            value += impl.value;
            return this;
        }

        public Vector3EvaluationChain Add(Vector3 vector)
        {
            value += vector;
            return this;
        }

        public Vector3 GetResult()
        {
            return value;
        }

        public Vector3EvaluationChain Scale(float field)
        {
            value *= field;
            return this;
        }
    }
}
