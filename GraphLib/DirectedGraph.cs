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


    }
}

