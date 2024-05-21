namespace GraphLib
{
    public class Edge
    {
        public Vertex Parent { get; set; }
        public Vertex Child { get; set; }
        public int Weight {  get; set; }
    }
}