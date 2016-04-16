using System;
using System.Data;
using graph.DataStructure;
using QuickGraph.Algorithms;
using QuickGraph.Data;

namespace graph {
    class Program {
        static void Main(string[] args) {
            Graph<string> web = new Graph<string>();
            web.AddNode("Privacy.htm");
            web.AddNode("People.aspx");
            web.AddNode("About.htm");
            web.AddNode("Index.htm");
            web.AddNode("Products.aspx");
            web.AddNode("Contact.aspx");

            web.AddUndirectedEdge("People.aspx", "Privacy.htm");  // People <-> Privacy

            web.AddDirectedEdge("People.aspx", "Privacy.htm");  // People -> Privacy

            web.AddDirectedEdge("Privacy.htm", "Index.htm");    // Privacy -> Index
            web.AddDirectedEdge("Privacy.htm", "About.htm");    // Privacy -> About

            web.AddDirectedEdge("About.htm", "Privacy.htm");    // About -> Privacy
            web.AddDirectedEdge("About.htm", "People.aspx");    // About -> People
            web.AddDirectedEdge("About.htm", "Contact.aspx");   // About -> Contact

            web.AddDirectedEdge("Index.htm", "About.htm");      // Index -> About
            web.AddDirectedEdge("Index.htm", "Contact.aspx");   // Index -> Contacts
            web.AddDirectedEdge("Index.htm", "Products.aspx");  // Index -> Products

            web.AddDirectedEdge("Products.aspx", "Index.htm");  // Products -> Index
            web.AddDirectedEdge("Products.aspx", "People.aspx");// Products -> People

            DataSet ds = web; // your dataset
            var graph = ds.ToGraph();  // wraps the dataset into a DataSetGraph
            foreach (DataTable table in graph.TopologicalSort()) // applies a topological sort to the dataset graph
                Console.WriteLine(table.TableName); // in which order should we delete the tables?
        }
    }
}
