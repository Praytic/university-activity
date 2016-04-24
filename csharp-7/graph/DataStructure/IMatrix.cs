using System.Collections.Generic;

namespace graph.DataStructure
{
    public interface IMatrix<TValue, TWeight> : ICollection<TValue> 
    {
        TWeight this[TValue i, TValue j] { get; set; }
        
        Dictionary<TValue, int> Schema { get; }

        TWeight[,] Matrix { get; }
    }
}