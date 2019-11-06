using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Graph<T> where T : IComparable
    {
        private List<Vertex<T>> vertices { get; set; }

        public int Count
        {
            get
            {
                return vertices.Count;

            }
        }

        public IReadOnlyList<Vertex<T>> Vertices
        {
            get
            {
                return vertices;
            }
        }
        public IReadOnlyList<Edge<T>> Edges
        {
            get
            {
                var edges = new List<Edge<T>>();
                for(int i = 0; i < Count; i++)
                {
                    for(int j = 0; j < vertices[i].Count; j++)
                    {
                        edges.Add(vertices[i].NeighboringVertices[j]);
                    }
                }

                return edges;
            }
        }

        public void AddVertex()
        {

        }

        public void RemoveVertex()
        {

        }

        public void AddEdge()
        {

        }

        public void RemoveEdge()
        {

        }
    }
}
