using graph.DataStructure;

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
        }
    }
}
