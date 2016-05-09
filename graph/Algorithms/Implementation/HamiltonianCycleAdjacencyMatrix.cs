using System;
using System.Collections.Generic;
using graph.Storages.Implementation;

namespace graph.Algorithms.Implementation
{
    public class HamiltonianCycleAdjacencyMatrix<TVertex, TWeight> :
        HamiltonianCycle<GraphAdjacencyMatrix<TVertex, TWeight>, TVertex, TWeight> 
        where TWeight : IComparable
    {
        public HamiltonianCycleAdjacencyMatrix(GraphAdjacencyMatrix<TVertex, TWeight> graph, TVertex start) : base(graph, start)
        {
        }

        public override void Run()
        {
            int n = Graph.Count;
            Parents.AddFirst(Start);
            Used.Add(Start);

            while (Parents.Count < n) {
                while (true) {
                    bool any = false;
                    foreach (var element in Graph) {
                        if (!Graph[Parents.First.Value, element].Equals(default(TWeight)) && !Used.Contains(element)) {
                            any = true;
                            Parents.AddFirst(element);
                            Used.Add(element);
                            break;
                        }
                    }
                    if (!any) break;
                }
                while (true) {
                    bool any = false;
                    foreach (var element in Graph) {
                        if (!Graph[Parents.Last.Value, element].Equals(default(TWeight)) && !Used.Contains(element)) {
                            any = true;
                            Parents.AddLast(element);
                            Used.Add(element);
                            break;
                        }
                    }
                    if (!any) break;
                }
            }
            LinkedListNode<TVertex> a1, b1;
            LinkedListNode<TVertex> it1 = Parents.First;
            while (true) {
                a1 = it1;
                it1 = it1.Next;
                b1 = it1;
                if (b1 == null) {
                    return;
                }
                if (!Graph[Parents.First.Value, b1.Value].Equals(default(TWeight)) && 
                    !Graph[a1.Value, Parents.Last.Value].Equals(default(TWeight)))
                    break;
            }
            
            it1 = Parents.First;
            while (it1 != b1) {
                Result.AddLast(it1.Value);
                it1 = it1.Next;
            }
            it1 = Parents.Last;
            while (it1 != a1) {
                Result.AddLast(it1.Value);
                it1 = it1.Previous;
            }
            Result.AddLast(Parents.First.Value);
        }
    }
}