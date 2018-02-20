using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HospitalWard {
    public struct structMessage {
        public int tempo;
        public Agent fromAgent;
        public Agent toAgent;
        public string fromTipo;
        public int fromIdx;
        public string toTipo;
        public int toIdx;
        public string text;
        public string ret;
    }
    
    public class AgentsMessageBus {
        public Agents agents;
        //private List<Agent> agents = new List<Agent>();
        public Utils utils = new Utils();

        public AgentsMessageBus(Agents pAgents) {
            agents = pAgents;
        }


        public Agent requestAgent(string tipo) {
            return agents.findIdle(tipo);
        }


        public void sendMessage(structMessage m) {
            // vai mandando as msgs até alguém atender

            structMessage mr;

            if (m.toAgent != null) {
                m.toAgent.messageBusReceive(m);
                return;
            }




            foreach (Agent a in agents.agentList) {
                //utils.loga("sendMessage: " + a.tipo + " " + a.idx);
                mr = a.messageBusReceive(m);
                if (mr.ret == "atendido") {
                    //utils.loga("sendMessage: Atendido " + a.tipo + " " + a.idx);
                    break;
                }
            }
        }
    }
}
