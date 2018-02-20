using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalWard {
    public class Agents {
        public List<Agent> agentList = new List<Agent>();
        public TextBox log;
        AgentsMessageBus agentsMessageBus;

        public Agents() {
            agentsMessageBus = new AgentsMessageBus(this);
        }

        public void create(string a) {
            Debug.WriteLine("Agents.Create " + a);
            if (a == "paciente") {
                agentList.Add(new AgentPaciente(count(a) + 1, agentsMessageBus));
            }
            if (a == "enfermeiro") {
                agentList.Add(new AgentEnfermeiro(count(a) + 1, agentsMessageBus));
            }
            if (a == "tecnico") {
                agentList.Add(new AgentTecnico(count(a) + 1, agentsMessageBus));
            }
            if (a == "medico") {
                agentList.Add(new AgentMedico(count(a) + 1, agentsMessageBus));
            }
        }

        public int count(string tipo) {
            int cnt = 0;
            foreach (Agent a in agentList) {
                if (a.tipo == tipo) {
                    cnt += 1;
                }
            }
            return cnt;
        }

        public int pacientesAguardandoAtendimento() {
            int cnt = 0;
            foreach (Agent a in agentList) {
                if (a.tipo == "paciente" && a.state == "requisita atendimento") {
                    if (((AgentPaciente)a).tempoAguardandoAtendimento > 10) {
                        cnt += 1;
                    }
                }
            }
            return cnt;
        }



        public void enable(string tipo, int idx) {
            foreach (Agent a in agentList) {
                if (a.tipo == tipo && a.idx == idx) {
                    a.enable();
                }
            }
        }

        public bool doRedraw() {
            bool r = false;
            foreach (Agent a in agentList) {
                if (a.redraw == true) {
                    a.redraw = false;
                    r = true;
                }
            }
            return r;
        }

        public void disable(string tipo, int idx) {
            foreach (Agent a in agentList) {
                if (a.tipo == tipo && a.idx == idx) {
                    a.disable();
                }
            }
        }

        public List<int> getPacientesNivel() {
            List<int> l = new List<int>();
            foreach (Agent a in agentList) {
                if (a.tipo == "paciente" && a.enabled == true) {
                    int x = ((AgentPaciente)a).nivel;
                    l.Add(x);
                }
            }
            return l;
        }

        public List<Agent> getByType(string tipo) {
            List<Agent> l = new List<Agent>();
            foreach (Agent a in agentList) {
                if (a.tipo == tipo) {
                    l.Add(a);
                }
            }
            return l;
        }

        public Agent getByType(string tipo, int idx) {
            foreach (Agent a in agentList) {
                if (a.tipo == tipo && a.idx == idx) {
                    return a;
                }
            }
            return null;
        }

        public void pacientesShuffleLevel() {
            foreach (Agent a in agentList) {
                if (a.tipo == "paciente") {
                    ((AgentPaciente)a).randomizeLevel();
                }
            }
        }

        public Agent findIdle(string tipo) {
            foreach (Agent a in agentList) {
                if (a.tipo == tipo && a.state == "idle" && a.enabled == true) {
                    a.setTimeoutToIdle();
                    return a;
                }
            }
            return null;
        }

        public void pacientesResetAtendimentos() {
            foreach (Agent a in agentList) {
                if (a.tipo == "paciente") {
                    ((AgentPaciente)a).resetAtendimentos();
                }
            }
        }

        public int tempoMedioPorAtendimento() {
            int tempoTotal = 0;
            int cnt = 0;
            foreach (Agent a in agentList) {
                if (a.tipo == "paciente") {
                    tempoTotal += (int)((AgentPaciente)a).tempoMedioPorAtendimento() / 60;
                    cnt += 1;
                }
            }
            return (int)(tempoTotal / cnt);
        }

        public int atentimentosTotal() {
            int total = 0;
            foreach (Agent a in agentList) {
                if (a.tipo == "paciente") {
                    total += ((AgentPaciente)a).atendimentosTotal();
                }
            }
            return total;
        }


        public void intencoes(int tempo) {
            foreach (Agent a in agentList) {
                a.intencao(tempo);
            }
        }

        public void reset() {
            foreach (Agent a in agentList) {
                a.reset();
            }
        }

        public string relatorio() {
            string s = "";
            foreach (Agent a in agentList) {
                s += a.relatorio();
            }
            return s;
        }

        public void tick(int tempo, int interval) {
            foreach (Agent a in agentList) {
                a.tick(tempo, interval);
            }
        }
    }
    
    public abstract class Agent {
        public Timer t = new Timer();
        public Timer timerTimoutIdle = new Timer();
        public int idx;
        public bool enabled = false;
        public AgentsMessageBus messageBus;
        public Utils utils = new Utils();
        public Dictionary<string, string[]> states = new Dictionary<string, string[]>();
        public Dictionary<string, string[]> statesConnections = new Dictionary<string, string[]>();
        public string tipo = "";
        public string state = "idle";
        public int local = 0;
        public bool redraw = false;
        public structMessage message;
        public string textLog;
        public int timeAtendimento = 0;
        public int timeAtendimentoMax = 0;
        public Agent agentLink = null;

        public void enable() {
            enabled = true;
            //utils.loga("Agente " + tipo + " " + idx.ToString("00") + " ativo");
        }

        public void enable(int i, int timeout) {
            //if (!enabled)
            //    utils.loga("Agente " + tipo + " " + idx.ToString("00") + " timer acionado.");
            enabled = true;
            idx = i;
            t.Interval = timeout * 1000;
            t.Tick += timerDone;
            t.Start();
        }

        public void disable() {
            //if (enabled)
            //    utils.loga("Agente " + tipo + " " + idx.ToString("00") + " inativo");
            enabled = false;
        }

        public void remove() {
            //if (!enabled)
            //    utils.loga("Agente " + tipo + " " + idx.ToString("00") + " removido.");
            enabled = true;
        }

        private void timerDone(object sender, EventArgs e) {
            t.Stop();
            enabled = false;
            utils.loga("Agente " + tipo + " " + idx.ToString("00") + " timer finalizado.");
        }

        public void setTimeoutToIdle() {
            state = "chamado";
            timerTimoutIdle.Interval = 3000;
            timerTimoutIdle.Tick += timerTimeoutIdleDone;
            timerTimoutIdle.Start();
        }

        private void timerTimeoutIdleDone(object sender, EventArgs e) {
            timerTimoutIdle.Stop();
            state = "idle";
            utils.loga("Agente " + tipo + " " + idx.ToString("00") + " foi alocado e não recebeu contato.");
        }



        public abstract structMessage messageBusReceive(structMessage m);
        public abstract void reset();
        public abstract void intencao(int tempo);
        public abstract void tick(int tempo, int interval);
        public abstract string relatorio();

    }

    public class AgentPaciente : Agent {
        public int nivel = 0;
        public string nivelNome = "";
        public int atendimentosMaxTime = 0;
        public int atendimentoInicio = 0;
        public int tempoAguardandoAtendimento = 0;
        Dictionary<string, int> atendimentos = new Dictionary<string, int>();

        List<int> temposNic = new List<int>(new int[] { 15, 30, 45, 60, 120 });

        public AgentPaciente(int pIdx, AgentsMessageBus amb) {
            idx = pIdx;
            tipo = "paciente";
            reset();
            messageBus = amb;

            states["idle"] = new string[] { "requisita atendimento", "evolui", "involui" };
            states["requisita atendimento"] = new string[] { "idle", "recebe atendimento enfermagem" };
            states["recebe atendimento enfermagem"] = new string[] { "idle", "recebe atendimento médico" };
            states["recebe atendimento médico"] = new string[] { "idle" };
            states["involui"] = new string[] { "idle" };
            states["evolui"] = new string[] { "idle" };
            statesConnections["requisita atendimento"] = new string[] { "enfermeiro", "tecnico" };
        }

        public void randomizeLevel() {
            nivel = Utils.rnd.Next(1, 4);
            switch (nivel) {
                case 1:
                    atendimentosMaxTime = (int)(60 * 60 * 3.8);
                    nivelNome = "cuidados mínimos";
                    break;
                case 2:
                    atendimentosMaxTime = (int)(60 * 60 * 5.6);
                    nivelNome = "cuidados intermediários";
                    break;
                case 3:
                    atendimentosMaxTime = (int)(60 * 60 * 9.4);
                    nivelNome = "cuidados semi-intensivos";
                    break;
                case 4:
                    atendimentosMaxTime = (int)(60 * 60 * 17.9);
                    nivelNome = "cuidados intensivos";
                    break;
            }
        }

        public void resetAtendimentos() {
            atendimentos.Clear();
        }


        public override structMessage messageBusReceive(structMessage m) {
            if (m.toAgent == this) {
                if (m.text == "atendido") {
                    utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} recebeu atendimento.", Utils.minutesToTimeBr(m.tempo), tipo, idx));
                    state = "recebe atendimento";
                    atendimentoInicio = m.tempo;
                }

                if (m.text == "fim atendimento") {
                    int tempoAtendimento = m.tempo - atendimentoInicio;
                    if (!atendimentos.ContainsKey(tempoAtendimento.ToString())) {
                        atendimentos.Add(tempoAtendimento.ToString(), tempoAtendimento);
                    }
                    utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} finalizou atendimento por {3,3:000} minutos.", Utils.minutesToTimeBr(m.tempo), tipo, idx, tempoAtendimento / 60));
                    state = "idle";
                    agentLink = null;
                    tempoAguardandoAtendimento = 0;
                }
            }
            return new structMessage();
        }

        public override void reset() {
            tempoAguardandoAtendimento = 0;
            state = "idle";
            agentLink = null;
            atendimentos.Clear();
        }

        public override void intencao(int tempo) {
            if (atendimentos.Sum(x => x.Value) >= atendimentosMaxTime) {
                utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} atingiu o tempo máximo de atendimento.", Utils.minutesToTimeBr(tempo), tipo, idx));
                return;
            }

            if (enabled == true && state == "idle") {
                //state = states["idle"][Utils.rnd.Next(0, 2)];
                state = "requisita atendimento";
                tempoAguardandoAtendimento = 0;

                utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} requisitou atendimento.", Utils.minutesToTimeBr(tempo), tipo, idx));
            }
        }

        public int tempoMedioPorAtendimento() {
            int z;
            if (atendimentos.Count > 0) {
                z = atendimentos.Sum(x => x.Value) / atendimentos.Count;
                //utils.loga(String.Format("{0} {1,2:00} tempo médio por atendimento {2}.", tipo, idx, z));
                return z;
            }

            return 0;
        }


        public int atendimentosTotal() {
            return atendimentos.Count;
        }

        public override void tick(int tempo, int interval) {
            if (state == "requisita atendimento") {
                string toTipo = "enfermeiro";
                tempoAguardandoAtendimento += interval;

                if (Utils.rnd.Next(0, 1000) % 2 == 0) {
                    toTipo = "tecnico";
                }

                agentLink = messageBus.requestAgent(toTipo);
                if (agentLink != null) {
                    structMessage m = new structMessage();
                    m.tempo = tempo;
                    m.fromAgent = this;
                    m.toAgent = agentLink;
                    m.text = state;
                    messageBus.sendMessage(m);
                }
            }
        }

        public override string relatorio() {
            if (!enabled) return "";

            string s = "";
            int atendimentoTotal = atendimentos.Sum(x => x.Value);
            string horas = Utils.minutesToTimeBr(atendimentoTotal);
            s = String.Format("\r\n Relatório: Agente {0} {1,2:00} foi classificado como {2} e recebeu {3} horas de atendimento.",
                tipo, idx, nivelNome, horas);
            return s;
        }
    }
    
    public class AgentEnfermeiro : Agent {
        public AgentEnfermeiro(int idxs, AgentsMessageBus amb) {
            idx = idxs;
            tipo = "enfermeiro";
            reset();
            messageBus = amb;

            states["idle"] = new string[] { "intercorrência", "atividade gerencial", "contato médico", "atividade programada", "atividade prevenção", "atendimento ao familiar" };
            states["intercorrência"] = new string[] { "idle", "encaminha atendimento", "atividade gerencial" };
            states["atividade gerencial"] = new string[] { "intercorrência", "encaminha atendimento", "idle" };
            states["encaminha atendimento"] = new string[] { "idle" };
            states["contato médico"] = new string[] { "idle" };
            states["atividade programada"] = new string[] { "idle", "encaminha atendimento" };
            states["atividade prevenção"] = new string[] { "idle", "encaminha atendimento" };
            states["atendimento ao familiar"] = new string[] { "idle", "encaminha atendimento" };
            statesConnections["encaminha atendimento"] = new string[] { "enfermeiro" };
        }

        public override void intencao(int tempo) {
            // todo
        }

        public override void tick(int tempo, int interval) {
            if (enabled == true && state != "idle") {
                if (local > 0) {
                    timeAtendimento += interval;
                }

                if (timeAtendimento >= timeAtendimentoMax) {
                    local = 0;
                    state = "idle";
                    redraw = true;
                    utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} finalizou atendimento.", Utils.minutesToTimeBr(tempo), tipo, idx));
                    structMessage m = new structMessage();
                    m.fromAgent = this;
                    m.toAgent = agentLink;
                    m.text = "fim atendimento";
                    m.tempo = tempo;
                    messageBus.sendMessage(m);
                    agentLink = null;
                }
            }
        }

        public override structMessage messageBusReceive(structMessage m) {
            if (m.toAgent == this
                && agentLink == null
                && m.text == "requisita atendimento"
                && m.fromAgent != null
                && state == "chamado") {
                agentLink = m.fromAgent;
                timerTimoutIdle.Stop();

                state = "intercorrência";
                local = agentLink.idx;
                timeAtendimento = 0;
                timeAtendimentoMax = Utils.rnd.Next(60, 60 * 60);

                utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} atendendo {3} {4,2:00} por {5,3:000} minutos.",
                    Utils.minutesToTimeBr(m.tempo),
                    tipo,
                    idx,
                    agentLink.tipo,
                    agentLink.idx,
                    timeAtendimentoMax / 60
                    ));
                redraw = true;

                structMessage mr = new structMessage();
                mr.fromAgent = this;
                mr.toAgent = agentLink;
                mr.text = "atendido";
                mr.tempo = m.tempo;
                messageBus.sendMessage(mr);
            }

            return new structMessage();
        }

        public override void reset() {
            state = "idle";
            local = 0;
            agentLink = null;
        }

        public override string relatorio() {
            if (!enabled) return "";
            return "";
        }
    }

    public class AgentTecnico : Agent {
        public AgentTecnico(int idxs, AgentsMessageBus amb) {
            idx = idxs;
            tipo = "tecnico";
            messageBus = amb;

            states["intercorrência"] = new string[] { "idle", "encaminha atendimento", "atividade gerencial" };
            states["atividade gerencial"] = new string[] { "intercorrência", "encaminha atendimento", "idle" };
            states["encaminha atendimento"] = new string[] { "idle" };
            states["idle"] = new string[] { "intercorrência", "atividade gerencial", "contato médico", "atividade programada", "atividade prevenção", "atendimento ao familiar" };
            states["contato médico"] = new string[] { "idle" };
            states["atividade programada"] = new string[] { "idle", "encaminha atendimento" };
            states["atividade prevenção"] = new string[] { "idle", "encaminha atendimento" };
            states["atendimento ao familiar"] = new string[] { "idle", "encaminha atendimento" };
            statesConnections["encaminha atendimento"] = new string[] { "enfermeiro" };
        }

        public override void intencao(int tempo) {
            // todo
        }

        public override void tick(int tempo, int interval) {
            if (enabled == true && state != "idle") {
                if (local > 0) {
                    timeAtendimento += interval;
                }

                if (timeAtendimento >= timeAtendimentoMax) {
                    local = 0;
                    state = "idle";
                    redraw = true;
                    utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} finalizou atendimento.", Utils.minutesToTimeBr(tempo), tipo, idx));
                    structMessage m = new structMessage();
                    m.fromAgent = this;
                    m.toAgent = agentLink;
                    m.text = "fim atendimento";
                    m.tempo = tempo;
                    messageBus.sendMessage(m);
                    agentLink = null;
                }
            }
        }

        public override structMessage messageBusReceive(structMessage m) {
            if (m.toAgent == this
                && agentLink == null
                && m.text == "requisita atendimento"
                && m.fromAgent != null
                && state == "chamado") {
                agentLink = m.fromAgent;
                timerTimoutIdle.Stop();

                state = "intercorrência";
                local = agentLink.idx;
                timeAtendimento = 0;
                timeAtendimentoMax = Utils.rnd.Next(60, 60 * 60);

                utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} atendendo {3} {4,2:00} por {5,3:000} minutos.",
                    Utils.minutesToTimeBr(m.tempo),
                    tipo,
                    idx,
                    agentLink.tipo,
                    agentLink.idx,
                    timeAtendimentoMax / 60
                    ));
                redraw = true;

                structMessage mr = new structMessage();
                mr.fromAgent = this;
                mr.toAgent = agentLink;
                mr.text = "atendido";
                mr.tempo = m.tempo;
                messageBus.sendMessage(mr);
            }

            return new structMessage();
        }

        public override void reset() {
            state = "idle";
            local = 0;
            agentLink = null;
        }

        public override string relatorio() {
            if (!enabled) return "";
            return "";
        }
    }

    public class AgentMedico : Agent {
        public AgentMedico(int idxs, AgentsMessageBus amb) {
            idx = idxs;
            tipo = "medico";
            messageBus = amb;

            states["atendimento"] = new string[] { "idle" };
        }

        public override void intencao(int tempo) {
            // todo
        }

        public override void tick(int tempo, int interval) {
            if (enabled == true && state != "idle") {
                if (local > 0) {
                    timeAtendimento += interval;
                }

                if (timeAtendimento >= timeAtendimentoMax) {
                    local = 0;
                    state = "idle";
                    redraw = true;
                    utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} finalizou atendimento.", Utils.minutesToTimeBr(tempo), tipo, idx));
                    structMessage m = new structMessage();
                    m.fromAgent = this;
                    m.toAgent = message.fromAgent;
                    m.fromIdx = idx;
                    m.fromTipo = tipo;
                    m.toIdx = message.fromIdx;
                    m.toTipo = "paciente";
                    m.text = "fim atendimento";
                    m.tempo = tempo;
                    messageBus.sendMessage(m);
                }
            }
        }

        public override structMessage messageBusReceive(structMessage m) {
            if (m.toTipo == tipo && enabled == true) {
                if (state == "idle") {
                    state = "intercorrência";
                    local = m.fromIdx;
                    timeAtendimento = 0;
                    timeAtendimentoMax = Utils.rnd.Next(60, 60 * 60);
                    m.ret = "atendido";
                    utils.loga(String.Format("{0,6:000000} - {1} {2,2:00} atendendo {3} {4,2:00} por {5,3:000} minutos.",
                        Utils.minutesToTimeBr(m.tempo),
                        tipo,
                        idx,
                        m.fromTipo,
                        m.fromIdx,
                        timeAtendimentoMax / 60
                        ));
                    redraw = true;
                    message = m;
                }
            }
            return m;
        }

        public override void reset() {
            state = "idle";
            local = 0;
            agentLink = null;
        }

        public override string relatorio() {
            if (!enabled) return "";
            return "";
        }
    }

}


