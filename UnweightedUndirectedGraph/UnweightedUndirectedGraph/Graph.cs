using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraph
{
    class Graph<T> where T : IComparable
    {
        List<Vertex<T>> Vertices { get; set;  }

        public int Count
        {
            get
            {
                return Vertices.Count;
            }
        }

        public void AddVertex(Vertex<T> vertex)
        {
            if(vertex != null && vertex.NeighboringVertices.Count == 0 && !Vertices.Contains(vertex))
            {
                Vertices.Add(vertex);
            }
        }

        public bool RemoveVertex(Vertex<T> vertex)
        {
            if(Vertices.Contains(vertex))
            {
                vertex.NeighboringVertices = null;
                Vertices.Remove(vertex);
                return true;
            }
            return false;
        }

        public void AddEdge(Vertex<T> firstVertex, Vertex<T> secondVertex) //adding to both Vertices' neighbor lists because the graph is undirected
        {
            if(firstVertex != null && secondVertex != null)
            {
                if(Vertices.Contains(firstVertex) && Vertices.Contains(secondVertex))
                {
                    if (!firstVertex.NeighboringVertices.Contains(secondVertex))
                    {
                        firstVertex.NeighboringVertices.Add(secondVertex);
                    }
                    if (!secondVertex.NeighboringVertices.Contains(firstVertex))
                    {
                        secondVertex.NeighboringVertices.Add(firstVertex);
                    }
                }
            }
        }

        public void RemoveEdge(Vertex<T> firstVertex, Vertex<T> secondVertex)
        {
            if(firstVertex != null && secondVertex != null)
            {
                if(Vertices.Contains(firstVertex) && Vertices.Contains(secondVertex))
                {
                    if(firstVertex.NeighboringVertices.Contains(secondVertex))
                    {
                        firstVertex.NeighboringVertices.Remove(secondVertex);
                    }

                    if(secondVertex.NeighboringVertices.Contains(firstVertex))
                    {
                        secondVertex.NeighboringVertices.Remove(firstVertex);
                    }
                }
            }
        }

        public Vertex<T> Search(T value)
        {
            for(int i = 0; i < Vertices.Count; i++)
            {
                if(Vertices[i].Value.CompareTo(value) == 0)
                {
                    return Vertices[i];
                }
            }
            return null;
        }

        public int IndexOf(Vertex<T> vertex)
        {
            for(int i = 0; i < Vertices.Count; i++)
            {
                if(Vertices[i] == vertex)
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
