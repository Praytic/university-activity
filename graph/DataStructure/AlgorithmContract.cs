namespace graph.DataStructure
{
    public abstract class AlgorithmContract<TGraph> :
        IAlgorithm<TGraph>
    {
        public TGraph Graph { get; protected set; }

        public abstract void Run();
    }
}