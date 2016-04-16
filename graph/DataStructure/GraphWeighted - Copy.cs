using System.Text;

namespace graph.DataStructure
{
    public class Graph<T> {
        private readonly NodeList<T> _nodeSet;

        public Graph() : this(null)
        {
            _nodeSet = new NodeList<T>();
        }
        public Graph(NodeList<T> nodeSet) {
            _nodeSet = nodeSet;
        }

        public void AddNode(GraphNode<T> node) {
            // adds a node to the graph
            _nodeSet.Add(node);
        }

        public void AddNode(T value) {
            // adds a node to the graph
            _nodeSet.Add(new GraphNode<T>(value));
        }

        public void AddDirectedEdge(T from, T to) {
            AddDirectedEdge(from, to, 1);
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to) {
            AddDirectedEdge(from, to, 1);
        }

        public void AddDirectedEdge(T from, T to, int cost) {
            AddDirectedEdge((GraphNode<T>) _nodeSet.FindByValue(from), (GraphNode<T>) _nodeSet.FindByValue(to), cost);
        }

        public void AddDirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost) {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);
        }
        
        public void AddUndirectedEdge(T from, T to) {
            AddUndirectedEdge(from, to, 1);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to) {
            AddUndirectedEdge(from, to, 1);
        }

        public void AddUndirectedEdge(T from, T to, int cost) {
            AddUndirectedEdge((GraphNode<T>)_nodeSet.FindByValue(from), (GraphNode<T>)_nodeSet.FindByValue(to), cost);
        }

        public void AddUndirectedEdge(GraphNode<T> from, GraphNode<T> to, int cost) {
            from.Neighbors.Add(to);
            from.Costs.Add(cost);

            to.Neighbors.Add(from);
            to.Costs.Add(cost);
        }

        public bool Contains(T value) {
            return _nodeSet.FindByValue(value) != null;
        }

        public bool Remove(T value) {
            // first remove the node from the nodeset
            GraphNode<T> nodeToRemove = (GraphNode<T>)_nodeSet.FindByValue(value);
            if (nodeToRemove == null)
                // node wasn't found
                return false;

            // otherwise, the node was found
            _nodeSet.Remove(nodeToRemove);

            // enumerate through each node in the nodeSet, removing edges to this node
            foreach (GraphNode<T> gnode in _nodeSet) {
                int index = gnode.Neighbors.IndexOf(nodeToRemove);
                if (index != -1) {
                    // remove the reference to the node and associated cost
                    gnode.Neighbors.RemoveAt(index);
                    gnode.Costs.RemoveAt(index);
                }
            }

            return true;
        }

        public NodeList<T> Nodes {
            get {
                return _nodeSet;
            }
        }

        public int Count {
            get { return _nodeSet.Count; }
        }

        public override string ToString()
        {
            StringBuilder graphPrint = new StringBuilder();
            foreach (GraphNode<T> gnode in _nodeSet)
            {
                graphPrint.AppendLine(gnode.ToString());
            }
            return graphPrint.ToString();
        }
    }
}