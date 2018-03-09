using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretrageOsnovno
{
    class Graph
    {
        public Dictionary<string, Node> graph = null;

        public Graph(string[] linesNodes, string[] linesLinks)
        {
            graph = new Dictionary<string, Node>();
            formGraph(linesNodes, linesLinks);
        }

        // TODO 1 : implementirati metodu formiranja grafa
        private void formGraph(string[] linesNodes, string[] linesLinks)
        {
            // formiramo sve cvorove
            foreach (string line in linesNodes)
            {
                string[] splitted = line.Split(':');
                string name = splitted[0];
                string heurStr = splitted[1];
                double heuristic = double.Parse(heurStr);

                Node node = new Node(name, heuristic);

                graph.Add(node.Name, node);
            }
            // dodamo linkove
            foreach (string line in linesLinks)
            {
                string[] splittedLine = line.Split(':');
                string[] splittedLink = splittedLine[1].Split(',');
                string start = splittedLink[0];
                string end = splittedLink[1];
                string cenaStr = splittedLink[2];
                double cena = double.Parse(cenaStr);

                Node startNode = graph[start];
                Node endNode = graph[end];

                Link link = new Link(startNode, endNode, "put", cena);

                startNode.Links.Add(link);
                // splitujete por : pa ,
                // dobijete start, end i cenu
                // Node startNode = graph[start]; 
                // Kreirate link 
                // i dodate ga u start node
            }
        }

        #region ispis
        public void printGraph()
        {
            StringBuilder sb = new StringBuilder();
            foreach (KeyValuePair<string, Node> kvp in graph)
            {
                foreach (Link link in kvp.Value.Links)
                {
                    Console.WriteLine(link.Name + ":" + link.StartNode + "," + link.EndNode + "," + link.Cost);
                }
            }
        }
        #endregion
    }
}
