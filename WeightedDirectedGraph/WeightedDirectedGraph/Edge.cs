using System;
using System.Collections.Generic;
using System.Text;

namespace WeightedDirectedGraph
{
    class Edge<T> where T : IComparable
    {
        public Vertex<T> StartingPoint { get; set; }
        public Vertex<T> EndPoint { get; set; }
        public double Distance { get; set; }

        public Edge(Vertex<T> startPoint, Vertex<T> endPoint, double distance)
        {
            StartingPoint = startPoint;
            EndPoint = endPoint;
            Distance = distance;
        }

         
    }
}
