using graph.Storages.Implementation;

namespace graph.Storages
{
    public interface ISchemable<T>
    {
        Scheme<T> Scheme { get; }

        int this[T key] { get; set; }

        T this[int key] { get; }
    }
}