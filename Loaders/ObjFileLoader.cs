using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjLoader.Loader.Loaders;
using ComputerGraphics3D.Model;
using System.Numerics;

namespace ComputerGraphics3D.Loaders
{
    public class ObjFileLoader : IFileFigureLoader
    {
        private ObjLoaderFactory _objLoaderFactory;

        public ObjFileLoader()
        {
            _objLoaderFactory = new ObjLoaderFactory();
        }

        public Figure? LoadFigureFromFile(string filename)
        {
            var _loader = _objLoaderFactory.Create();
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.Read))
            {
                var loadResult = _loader.Load(stream);

                if (loadResult == null) return null;
                if (loadResult.Groups.Count < 1) return null;

                var group = loadResult.Groups[0];
                var polygonSet = new PolygonSet();

                foreach (var face in group.Faces)
                {
                    var newPolygon = new Polygon();

                    for (int i = 0; i < face.Count; i++)
                    {
                        var faceVertex = face[i];
                        var vertex = loadResult.Vertices[faceVertex.VertexIndex - 1];
                        var normal = loadResult.Normals[faceVertex.NormalIndex - 1];

                        newPolygon.Vertices.Add(new Vertex(new Vector3(vertex.X, vertex.Y, vertex.Z), new Vector3(normal.X, normal.Y, normal.Z)));
                    }

                    polygonSet.Polygons.Add(newPolygon);
                }

                return polygonSet;
            }
        }
    }
}
