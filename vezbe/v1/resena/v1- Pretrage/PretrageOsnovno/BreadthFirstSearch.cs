using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PretrageOsnovno
{
    class BreadthFirstSearch
    {
        public State Search(string startNodeName, string endNodeName)
        {
            Node start = Program.instance.graph[startNodeName];
            Node end = Program.instance.graph[endNodeName];

            State pocetnoStanje = new State(start);
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
                    stanjaZaObradu.AddRange(mogucaSledecaStanja); //BFS
                    //stanjaZaObradu.InsertRange(0, mogucaSledecaStanja); DFS
                }
            }
            return null;
        }
    }
}
