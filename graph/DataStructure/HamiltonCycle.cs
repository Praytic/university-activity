using System;
using System.Collections.Generic;
using System.Linq;

namespace graph.DataStructure
{
    public class HamiltonCycle
    {
        private readonly Graph<int, byte> g;

        public HamiltonCycle(Graph<int, byte> graph)
        {
            g = graph;
        }

        public LinkedList<int> Calculate()
        {
            int n = g.Size;
            bool[] added = new bool[n];
            var path = new LinkedList<int>();
            path.AddFirst(0);
            added[0] = true;

            while (path.Count < n)
            {
                while (true) {
                    bool any = false;
                    for (int i = 0; i < n; i++) {
                        if (g[path.First.Value, i] == 1 && !added[i]) {
                            any = true;
                            path.AddFirst(i);
                            added[i] = true;
                            break;
                        }
                    }
                    if (!any) break;
                }
                while (true)
                {
                    bool any = false;
                    for (int i = 0; i < n; i++)
                    {
                        if (g[path.Last.Value, i] == 1 && !added[i])
                        {
                            any = true;
                            path.AddLast(i);
                            added[i] = true;
                            break;
                        }
                    }
                    if (!any) break;
                }
                if (path.Count < n)
                {
                    LinkedListNode<int> a, b;
                    LinkedListNode<int> it = path.First;
                    while (true)
                    {
                        a = it;
                        it = it.Next;
                        b = it;
                        if (g[path.First.Value, b.Value] == 1 && g[a.Value, path.Last.Value] == 1) break;
                    }

                    int u = 0;
                    while (true)
                    {
                        if (!added[u])
                        {
                            added[u] = true;
                            break;
                        }
                        u++;
                    }

                    bool beforeB = true;
                    LinkedListNode<int> c = path.First;
                    while (true)
                    {
                        if (c == b) beforeB = false;
                        if (g[c.Value, u] == 1) break;
                        c = c.Next;
                    }

                    var newPath = new LinkedList<int>();
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
            LinkedListNode<int> a1, b1;
            LinkedListNode<int> it1 = path.First;
            while (true)
            {
                a1 = it1;
                it1 = it1.Next;
                b1 = it1;
                if (g[path.First.Value, b1.Value] == 1 && g[a1.Value, path.Last.Value] == 1)
                    break;
            }

            var cycle = new LinkedList<int>();
            it1 = path.First;
            while (it1 != b1)
            {
                cycle.AddLast(it1.Value);
                it1 = it1.Next;
            }
            it1 = path.Last;
            while (it1 != a1)
            {
                cycle.AddLast(it1.Value);
                it1 = it1.Previous;
            }
            cycle.AddLast(path.First.Value);
            return cycle;
        }
    }
}