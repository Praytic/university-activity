using System.Windows;
using QuickGraph;

namespace GraphVisualization {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public IBidirectionalGraph<object, IEdge<object>> GraphToVisualize { get; set; }

        public MainWindow()
        {
            CreateGraphToVisualize();
            InitializeComponent();
        }

        private void CreateGraphToVisualize()
        {
            var g = new BidirectionalGraph<object, IEdge<object>>();
            string[] vertices = new string[5];
            for (int i = 0; i < 5; i++)
            {
                vertices[i] = i.ToString();
                g.AddVertex(vertices[i]);

            }
            g.AddEdge(new Edge<object>(vertices[0], vertices[1]));
            g.AddEdge(new Edge<object>(vertices[1], vertices[2]));
            g.AddEdge(new Edge<object>(vertices[2], vertices[3]));
            g.AddEdge(new Edge<object>(vertices[3], vertices[1]));
            g.AddEdge(new Edge<object>(vertices[1], vertices[4]));

            GraphToVisualize = g;
        }
    }
}
