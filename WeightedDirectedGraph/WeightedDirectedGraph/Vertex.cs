using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Vertex<T> where T : IComparable
    {
        public T Value { get; set; }
        public List<Edge<T>> NeighboringVertices { get; set; }
        public int Count
        {
            get
            {
                return NeighboringVertices.Count;
            }
        }
        
        public Vertex(T value)
        {
            Value = value;
        }
    }
}
