﻿
namespace GraphLib
{
    public class DirectedGraph
    {
        public int NumVertices { get => Vertices.Count; }
        public List<Vertex> Vertices = new List<Vertex>();
        public Vertex AddVertex(string label)
        {
            Vertex v = new Vertex(label);

            // I want to track all created vertex
            Vertices.Add(v);

            return v;
        }

        public int[,] CreatedAdjMatrix()
        {
            // make a 2d array to represent all vertices
            int[,] AdjMatrix = new int[Vertices.Count, Vertices.Count];

            for(int i = 0; i < Vertices.Count; i++)
            {
                Vertex v1 = Vertices[i];

                for (int j = 0; j < Vertices.Count; j++)
                {
                    Vertex v2 = Vertices[j];

                    Edge edge = v1.Edges.FirstOrDefault(e => e.Child == v2);

                    if (edge != null)
                    {
                        AdjMatrix[i, j] = edge.Weight;
                    }
                }
            }
            return AdjMatrix;
        }

        public void PrintMatrix()
        {
            var matrix = CreatedAdjMatrix();

            for(int i =0; i < Vertices.Count; i++)
            {
                Console.Write($" {Vertices[i].Label} ");
            }
            Console.WriteLine();

            for (int i = 0; i < Vertices.Count; i++)
            {
                Console.Write($"{Vertices[i].Label}\t");

                for (int j = 0;j < Vertices.Count; j++)
                {
                    if (i == 0)
                    {
                        Console.Write($"{Vertices[j].Label}");
                    }
                    if (matrix[i, j] != null)
                    {
                        Console.Write($"[{matrix[i, j].ToString()}]");
                    }
                    else
                    {
                        Console.Write("[.]");
                    }
                    
                }
                Console.WriteLine();
            }
        }

        public void Dijkstra(int src)
        {
            int[,] graph = CreatedAdjMatrix();

            // set up some buckets to store our info
            int[] dist = new int[Vertices.Count];
            bool[] visits = new bool[Vertices.Count];

            // initialize the arrays
            for (int i = 0; i < Vertices.Count; i++)
            {
                dist[i] = int.MaxValue;
                visits[i] = false;
            }
            dist[src] = 0;

            for(int count =  0; count < Vertices.Count; count++)
            {
                // pick the minimum distance vertex from the set of vertices not yet processed
                int u = MinDistance(dist, visits);

                // mark the picked vertex as visited
                visits[u] = true;

                // update dist value of the adjacent vertices of the picked vertex

                for(int v = 0; v < Vertices.Count; v++)
                {
                    /*
                     update dist[v] only if the following conditions are true:
                        it is not visited
                        there exists an edge from u to v
                        the edge is not infinity
                        the total weight of the path from src to v through the picked node (u) is smaller than the current value of dist[v]
                     */

                    if (!visits[v] &&
                        graph[u, v] != int.MaxValue &&
                        dist[u] != int.MaxValue &&
                        dist[u] + graph[u, v] < dist[v]
                        )
                    {
                        dist[v] = dist[u] + graph[u, v];
                    }
                }

            }

            PrintSolution(dist, Vertices.Count);
        }

        private void PrintSolution(int[] dist, int count)
        {
            Console.WriteLine("Vertex\t\tDistance from source");

            for(int i = 0; i < Vertices.Count; i++)
            {
                Console.WriteLine($"{Vertices[i].Label}\t\t{dist[i]}");
            }
        }

        private int MinDistance(int[] dist, bool[] visits)
        {
            int min = int.MaxValue;
            int min_index = -1;

            for(int i = 0; i < Vertices.Count; i++)
            {
                if (visits[i] == false && dist[i] < min)
                {
                    min = dist[i];
                    min_index = i;
                }
            }

            return min_index;
        }
    }
}

