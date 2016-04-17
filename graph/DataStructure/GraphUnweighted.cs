using System.Collections.Generic;

namespace graph.DataStructure {

    public class GraphUnweighted<TValue> : Graph<TValue, byte> {

        public GraphUnweighted() {
            AdjacencyMatrix = new AdjacencyMatrix<TValue, byte>();
        }

        public GraphUnweighted(AdjacencyMatrix<TValue, byte> adjacencyMatrix) {
            AdjacencyMatrix = adjacencyMatrix;
        }

        public void AddDirectedEdge(TValue from, TValue to) {
            AdjacencyMatrix.AddDirectedEdge(from, to, 1);
        }

        public void AddUndirectedEdge(TValue from, TValue to) {
            AdjacencyMatrix.AddUndirectedEdge(from, to, 1);
        }

        public LinkedList<TValue> Calculate() {
            int n = AdjacencyMatrix.Size;
            var added = new HashSet<TValue>();
            var path = new LinkedList<TValue>();
            path.AddFirst(GetFirstVertex());
            added.Add(GetFirstVertex());

            while (path.Count < n) {
                while (true) {
                    bool any = false;
                    foreach (var element in AdjacencyMatrix.Schema.Keys)
                    {
                        if (AdjacencyMatrix[path.First.Value, element] == 1 && !added.Contains(element)) {
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
                    foreach (var element in AdjacencyMatrix.Schema.Keys) 
                    { 
                        if (AdjacencyMatrix[path.Last.Value, element] == 1 && !added.Contains(element)) {
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
                        if (AdjacencyMatrix[path.First.Value, b.Value] == 1 && AdjacencyMatrix[a.Value, path.Last.Value] == 1) break;
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
                        if (AdjacencyMatrix[c.Value, u] == 1) break;
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
                if (b1 == null)
                {
                    return new LinkedList<TValue>();
                }
                if (AdjacencyMatrix[path.First.Value, b1.Value] == 1 && AdjacencyMatrix[a1.Value, path.Last.Value] == 1)
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