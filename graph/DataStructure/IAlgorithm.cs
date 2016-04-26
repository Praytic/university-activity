namespace graph.DataStructure
{
    public interface IAlgorithm<out TGraph>
    {
        TGraph Graph { get; }

        void Run();
    }
}