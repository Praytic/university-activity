using graph.DataStructure.Implementation;

namespace graph.DataStructure
{
    public interface ISchemable<T>
    {
        Scheme<T> Scheme { get; }

        int this[T key] { get; set; }

        T this[int key] { get; }
    }
}