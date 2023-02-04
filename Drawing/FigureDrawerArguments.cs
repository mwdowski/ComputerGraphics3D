using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace P2_TrianglesFilling.FigureDrawers
{
    public class FigureDrawerArguments
    {
        /// <summary>
        /// Coefficient 1. Should be between 0 and 1.
        /// </summary>
        public float k_d;

        /// <summary>
        /// Coefficient 2. Should be between 0 and 1.
        /// </summary>
        public float k_s;

        /// <summary>
        /// Light source color.
        /// </summary>
        public Color I_L;

        /// <summary>
        /// Light source position.
        /// </summary>
        public Vector3 L;

        /// <summary>
        /// Vector to viewer.
        /// </summary>
        public readonly Vector3 V = new Vector3(0, 0, 1);

        /// <summary>
        /// Reflection coefficient.
        /// Should be between 1 and 100.
        /// </summary>
        public int m;

        public float cloud_offset = 0;

    }
}
