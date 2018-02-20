using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalWard {
    public class Simulation {
        public Utils utils = new Utils();
        public Agents agents = new Agents();
        public FormWard formWard;
        public int pacientes, enfermeiros, tecnicos;

        public int tempo = 0;
        public int tempoMax = 60 * 60 * 6;
        public int tempoUnidade = 10;

        public bool running;
        public bool pause;
        public bool redraw;

        public Simulation(int pPacientes, int pEnfermeiros, int pTecnicos) {
            pacientes = pPacientes;
            enfermeiros = pEnfermeiros;
            tecnicos = pTecnicos;

            agentsCreate();
            agentsReset();
            agents.pacientesShuffleLevel();
        }

        private void agentsCreate() {
            for (int i = 1; i <= pacientes; i += 1) {
                agents.create("paciente");
            }
            for (int i = 1; i <= enfermeiros; i += 1) {
                agents.create("enfermeiro");
            }
            for (int i = 1; i <= tecnicos; i += 1) {
                agents.create("tecnico");
            }
        }

        public void stop() {
            running = false;
            utils.loga("Simulation finished.");
            utils.loga(agents.relatorio());
        }

        public void togglePause() {
            pause = !pause;
        }

        public void start() {
            running = true;
            pause = false;
            utils.loga("Simulation started.");
        }

        private void agentsReset() {
            //formWard.reset();
        }

        public int timerNatural() {
            tempo = (tempo / 60) * 60;
            tempoUnidade = 1;
            return 1000;
        }

        public int timerRapido() {
            tempo = (tempo / 60) * 60;
            tempoUnidade = 60;
            return 300;
        }

        public int getTempoPercentual() {
            return (int)(((float)tempo / (float)tempoMax) * 100f);
        }

        public void reset() {
            tempo = 0;
            agents.reset();
        }

        public int pacientesAguardandoAtendimento() {
            return agents.pacientesAguardandoAtendimento();
        }

        public int tempoMedioPorAtendimento() {
            return agents.tempoMedioPorAtendimento();
        }

        public int atentimentosPorHora() {
            int tempoHora = (tempo / (60 * 60));
            if (tempoHora == 0) return 0;
            return (int)(agents.atentimentosTotal() / tempoHora);
        }

        public string getAction() {
            if (tempo >= tempoMax) {
                return "final";
            }

            if (tempo == 60 * 60 * 1) {
                return "atendimento";
            }

            if (tempo == 30 * 60 * 1) {
                return "classificacao";
            }
            return "";

        }

        public string getTempoBr() {
            return Utils.minutesToTimeBr(tempo);
        }
        
        public void mainLoop() {
            if (pause) return;

            tempo += tempoUnidade;
            agents.tick(tempo, tempoUnidade);

            if (tempo % 25 == 0) {
                int cnt = agents.count("paciente");
                Agent a = agents.getByType("paciente", Utils.rnd.Next(1, cnt));
                a.intencao(tempo);
                // executar intenção dos agentes
            }

            // returns true to need redraw; 
            // false no need redraw;
            redraw = agents.doRedraw();
        }

    }
}


