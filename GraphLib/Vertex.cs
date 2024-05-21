namespace GraphLib
{
    public class Vertex
    {
        public string Label {  get; set; }
        public List<Edge> Edges = new List<Edge>();

        public Vertex(string lbl)
        {
            Label = lbl;
        } 

        public void AddEdge(Vertex child, int weight)
        {
            Edge edge = new Edge { Parent = this, Child = child, Weight = weight };
            
            Edges.Add(edge);
            throw new NotImplementedException();
        }
    }
}