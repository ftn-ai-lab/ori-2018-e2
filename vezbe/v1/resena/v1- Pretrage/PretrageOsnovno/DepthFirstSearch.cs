using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace PretrageOsnovno
{
    class DepthFirstSearch
    {
        public State Search(string startNodeName, string endNodeName)
        {
            // TODO 3: implementirati algoritam prvi u dubinu  

       
            // TODO 4: implementirati algoritam prvi u dubinu širinu
            Node startNode = Program.instance.graph[startNodeName];
            Node endNode = Program.instance.graph[endNodeName];

            List<State> stanjaZaObradu = new List<State>();

            stanjaZaObradu.Add(new State(startNode));

            while (stanjaZaObradu.Count > 0)
            {
                State naObradi = stanjaZaObradu[0];
                stanjaZaObradu.Remove(naObradi);

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
            return null;
        }
    }
}
