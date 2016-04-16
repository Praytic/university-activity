namespace graph.DataStructure
{
    public class Node<T> {
        // Private member-variables

        public Node() { }
        public Node(T data) : this(data, null) { }
        public Node(T data, NodeList<T> neighbors) {
            Data = data;
            Neighbors = neighbors;
        }

        public T Data { get; set; }

        protected NodeList<T> Neighbors { get; set; }
    }
}
