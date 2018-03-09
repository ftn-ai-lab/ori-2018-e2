using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PretrageOsnovno
{
    class AStarSearch
    {
        // TODO 7: implementirati algoritam za pretragu A*
        public State Search(string startNodeName, string endNodeName)
        {
            Node startNode = Program.instance.graph[startNodeName];
            Node endNode = Program.instance.graph[endNodeName];

            List<State> stanjaZaObradu = new List<State>();

            stanjaZaObradu.Add(new State(startNode));

            while (stanjaZaObradu.Count > 0)
            {
                State naObradi = findBest(stanjaZaObradu);//stanjaZaObradu[0];
                stanjaZaObradu.Remove(naObradi);
                
                if (naObradi.Node.Name == endNode.Name)
                {
                    return naObradi;
                }
                else
                {
                    List<State> mogucaSledecaStanja = naObradi.children();
                    stanjaZaObradu.AddRange(mogucaSledecaStanja); //BFS
                }
            }
            return null;
        }

        private State findBest(List<State> stanjaZaObradu)
        {
            State best = stanjaZaObradu[0];
            // minimum naObradi.Cost + naObradi.Node.Heuristic
            foreach (State stanje in stanjaZaObradu)
            {
                if (stanje.Cost + stanje.Node.Heuristic < best.Cost + best.Node.Heuristic)
                    best = stanje;
            }
            return best;
        }

    }
}
