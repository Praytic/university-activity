namespace graph.DataStructure
{
    public class AdjacencyMatrixSimple<TWeight> : AdjacencyMatrix<int, TWeight> {
        public AdjacencyMatrixSimple(TWeight[,] matrix) {
            for (int i = 0; i < matrix.GetLength(1); i++) {
                Schema[i] = i;
            }
            Matrix = matrix;
        }
    }
}