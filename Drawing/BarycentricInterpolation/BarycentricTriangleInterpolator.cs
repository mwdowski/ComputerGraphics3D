using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComputerGraphics3D.Drawing.BarycentricInterpolation
{
    public class BarycentricTriangleInterpolator<TEvaluationChain, TVector>
        where TEvaluationChain : IVectorOperationsEvaluationChain<TEvaluationChain, float, TVector>, new()
    {
        public BarycentricTriangleInterpolator(
            Point position1, TVector value1,
            Point position2, TVector value2,
            Point position3, TVector value3)
        {
            Position1 = position1;
            Value1 = value1;
            Position2 = position2;
            Value2 = value2;
            Position3 = position3;
            Value3 = value3;
        }

        public Point Position1 { get; }
        public TVector Value1 { get; }
        public Point Position2 { get; }
        public TVector Value2 { get; }
        public Point Position3 { get; }
        public TVector Value3 { get; }

        public TVector GetWeightInPoint(Point position)
        {
            var weight1 =
                ((float)(Position2.Y - Position3.Y) * (position.X - Position3.X) + (Position3.X - Position2.X) * (position.Y - Position3.Y))
                / ((Position2.Y - Position3.Y) * (Position1.X - Position3.X) + (Position3.X - Position2.X) * (Position1.Y - Position3.Y));

            var weight2 =
                ((float)(Position3.Y - Position1.Y) * (position.X - Position3.X) + (Position1.X - Position3.X) * (position.Y - Position3.Y))
                / ((Position2.Y - Position3.Y) * (Position1.X - Position3.X) + (Position3.X - Position2.X) * (Position1.Y - Position3.Y));

            var weight3 = 1 - weight1 - weight2;

            var res = new TEvaluationChain()
                .Add(new TEvaluationChain()
                     .Add(Value1)
                     .Scale(weight1))
                .Add(new TEvaluationChain()
                     .Add(Value2)
                     .Scale(weight2))
                .Add(new TEvaluationChain()
                     .Add(Value3)
                     .Scale(weight3))
                .GetResult();

            return res;
        }
    }
}
