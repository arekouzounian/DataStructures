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

        public Vertex<T> this[int index]
        {
            get
            {
                return vertices[index];
            }
            set
            {
                vertices[index] = value;
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

        public void AddVertex(Vertex<T> vertex)
        {
            if(!vertices.Contains(vertex) && vertex != null && vertex.Count == 0)
            {
                vertices.Add(vertex);
            }
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if(!vertices.Contains(vertex))
            {
                return false;
            }

            foreach(var neighbor in vertex.NeighboringVertices)
            {
                if(neighbor.EndPoint == vertex)
                {

                }
            }
        }

        public void AddEdge(Vertex<T> vertex1, Vertex<T> vertex2, double distance)
        {

        }

        public void RemoveEdge()
        {

        }
    }
}
