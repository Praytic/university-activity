using System.Collections.Generic;

namespace graph.DataStructure
{
    public class GraphNode<T> : Node<T> {
        private List<int> _costs;

        public GraphNode()
        { }
        public GraphNode(T value) : base(value) { }
        public GraphNode(T value, NodeList<T> neighbors) : base(value, neighbors) { }

        public new NodeList<T> Neighbors {
            get {
                if (base.Neighbors == null)
                    base.Neighbors = new NodeList<T>();

                return base.Neighbors;
            }
        }

        public List<int> Costs {
            get {
                if (_costs == null)
                    _costs = new List<int>();

                return _costs;
            }
        }
    }
}