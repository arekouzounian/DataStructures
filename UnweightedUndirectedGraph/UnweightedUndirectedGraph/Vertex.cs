using System;
using System.Collections.Generic;
using System.Text;

namespace UnweightedUndirectedGraph
{
    class Vertex<T> where T : IComparable
    {
        public T Value { get; set; }
        public List<Vertex<T>> NeighboringVertices { get; set; }

        public int getNeighborCount
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
