using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PretrageOsnovno
{
    class IterativeDepthFirstSearch
    {
        private const int MaxLevel = 10000;

        // TODO 6: implementirati algoritam iterativni prvi u dubinu
        public State Search(string startNodeName, string endNodeName)
        {
            Node startNode = Program.instance.graph[startNodeName];
            Node endNode = Program.instance.graph[endNodeName];

            for (int level = 0; level < MaxLevel; ++level)
            {
                List<State> stanjaZaObradu = new List<State>();
                stanjaZaObradu.Add(new State(startNode));

                while (stanjaZaObradu.Count > 0)
                {
                    State naObradi = stanjaZaObradu[0];
                    stanjaZaObradu.Remove(naObradi);

                    if (naObradi.Level > level)
                        continue; 

                    if (naObradi.Node.Name == endNode.Name)
                    {
                        return naObradi;
                    }
                    else
                    {
                        List<State> mogucaSledecaStanja = naObradi.children();
                        //stanjaZaObradu.AddRange(mogucaSledecaStanja); //BFS
                        stanjaZaObradu.InsertRange(0, mogucaSledecaStanja); //DFS
                    }
                }
            }
            return null;
        }
    }
}
