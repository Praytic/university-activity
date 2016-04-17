using System.Collections.Generic;

namespace graph.DataStructure
{
    public class Graph<TValue, TWeight> {
        public TWeight this[TValue i, TValue j]
        {
            get { return AdjacencyMatrix[i, j]; }
            set { AdjacencyMatrix[i, j] = value; }
        }

        public int Size
        {
            get { return AdjacencyMatrix.Size; }
        }

        public AdjacencyMatrix<TValue, TWeight> AdjacencyMatrix;

        public Graph() {
            AdjacencyMatrix = new AdjacencyMatrix<TValue, TWeight>();
        }

        public Graph(AdjacencyMatrix<TValue, TWeight> adjacencyMatrix) {
            AdjacencyMatrix = adjacencyMatrix;
        }

        public Graph(Graph<TValue, TWeight> graph)
        {
            AdjacencyMatrix = graph.AdjacencyMatrix;
        } 

        public void AddNode(TValue value) {
            AdjacencyMatrix.Add(value);
        }

        public void AddDirectedEdge(TValue from, TValue to, TWeight cost) {
            AdjacencyMatrix.AddDirectedEdge(from, to, cost);
        }

        public void AddUndirectedEdge(TValue from, TValue to, TWeight cost) {
            AdjacencyMatrix.AddUndirectedEdge(from, to, cost);
        }

        public bool Contains(TValue value) {
            return AdjacencyMatrix.Contains(value);
        }

        public void RemoveNode(TValue value) {
            AdjacencyMatrix.Remove(value);
        }

        public override string ToString() {
            return AdjacencyMatrix.ToString();
        }

        public List<TValue> HamiltonCycle()
        {
            var hamiltonCycle = new List<TValue>(new TValue[AdjacencyMatrix.Size + 1]);
            var visitedVertexList = new List<bool>(new bool[AdjacencyMatrix.Size + 1]);
            visitedVertexList[0] = true;
            AdjacencyMatrix.HamiltonCycle(ref hamiltonCycle, ref visitedVertexList);
            return hamiltonCycle;
        }

        public TValue GetFirstVertex()
        {
            return AdjacencyMatrix.GetFirstVertex();
        }

        public TValue GetNextVertex(TValue currentVertex) {
            return AdjacencyMatrix.GetNextVertex(currentVertex);
        }

        public LinkedList<TValue> GetHamiltonianCycle() {
            int n = AdjacencyMatrix.Size;
            var added = new HashSet<TValue>();
            var path = new LinkedList<TValue>();
            path.AddFirst(GetFirstVertex());
            added.Add(GetFirstVertex());

            while (path.Count < n) {
                while (true) {
                    bool any = false;
                    foreach (var element in AdjacencyMatrix.Schema.Keys) {
                        if (!AdjacencyMatrix[path.First.Value, element].Equals(default(TWeight)) && !added.Contains(element)) {
                            any = true;
                            path.AddFirst(element);
                            added.Add(element);
                            break;
                        }
                    }
                    if (!any) break;
                }
                while (true) {
                    bool any = false;
                    foreach (var element in AdjacencyMatrix.Schema.Keys) {
                        if (!AdjacencyMatrix[path.Last.Value, element].Equals(default(TWeight)) && !added.Contains(element)) {
                            any = true;
                            path.AddLast(element);
                            added.Add(element);
                            break;
                        }
                    }
                    if (!any) break;
                }
                if (path.Count < n) {
                    LinkedListNode<TValue> a, b;
                    LinkedListNode<TValue> it = path.First;
                    while (true) {
                        a = it;
                        it = it.Next;
                        b = it;
                        if (!AdjacencyMatrix[path.First.Value, b.Value].Equals(default(TWeight)) && !AdjacencyMatrix[a.Value, path.Last.Value].Equals(default(TWeight))) break;
                    }

                    TValue u = GetFirstVertex();
                    while (true) {
                        if (!added.Contains(u)) {
                            added.Add(u);
                            break;
                        }
                        u = GetNextVertex(u);
                    }

                    bool beforeB = true;
                    LinkedListNode<TValue> c = path.First;
                    while (true) {
                        if (c == b) beforeB = false;
                        if (!AdjacencyMatrix[c.Value, u].Equals(default(TWeight))) break;
                        c = c.Next;
                    }

                    var newPath = new LinkedList<TValue>();
                    newPath.AddFirst(u);
                    it = c;

                    if (beforeB) {
                        while (it != b) {
                            newPath.AddLast(it.Value);
                            it = it.Next;
                        }
                        it = path.Last;
                        while (it != a) {
                            newPath.AddLast(it.Value);
                            it = it.Previous;
                        }
                        it = path.First;
                        while (it != c) {
                            newPath.AddLast(it.Value);
                            it = it.Next;
                        }
                    } else {
                        while (it != a) {
                            newPath.AddLast(it.Value);
                            it = it.Previous;
                        }
                        it = path.First;
                        while (it != b) {
                            newPath.AddLast(it.Value);
                            it = it.Next;
                        }
                        it = path.Last;
                        while (it != c) {
                            newPath.AddLast(it.Value);
                            it = it.Previous;
                        }
                    }
                    path = newPath;
                }
            }
            LinkedListNode<TValue> a1, b1;
            LinkedListNode<TValue> it1 = path.First;
            while (true) {
                a1 = it1;
                it1 = it1.Next;
                b1 = it1;
                if (b1 == null) {
                    return new LinkedList<TValue>();
                }
                if (!AdjacencyMatrix[path.First.Value, b1.Value].Equals(default(TWeight)) && !AdjacencyMatrix[a1.Value, path.Last.Value].Equals(default(TWeight)))
                    break;
            }

            var cycle = new LinkedList<TValue>();
            it1 = path.First;
            while (it1 != b1) {
                cycle.AddLast(it1.Value);
                it1 = it1.Next;
            }
            it1 = path.Last;
            while (it1 != a1) {
                cycle.AddLast(it1.Value);
                it1 = it1.Previous;
            }
            cycle.AddLast(path.First.Value);
            return cycle;
        }
    }
}