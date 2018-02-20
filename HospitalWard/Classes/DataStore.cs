using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;

namespace HospitalWard {
    public class DataStore {
        public JObject data = new JObject();

        public IList<string> getKeys(JObject jsdata) {
            try {
                IList<string> keys = jsdata.Properties().Select(p => p.Name).ToList();
                return keys;
            } catch {
                return null;
            }
        }

        public void save() {
            string output = JsonConvert.SerializeObject(data);
            //Console.WriteLine(jsdata);
            File.WriteAllText(@"data.json", JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public void read() {
            data = JsonConvert.DeserializeObject<JObject>(File.ReadAllText(@"data.json"));
            Debug.WriteLine(JsonConvert.SerializeObject(data, Formatting.Indented));
        }

        public string getPacienteData(string paciente, string key) {
            if (data["pacientes"][paciente][key] != null) {
                return data["pacientes"][paciente][key].ToString();
            }
            return "";
        }

        public void setPacienteData(string paciente, string key, string value) {
            data["pacientes"][paciente][key] = value;
        }
        
        public string getPacienteEstado(string paciente, string estado, string key) {
            if (data["pacientes"][paciente]["estados"][estado][key] != null) {
                return data["pacientes"][paciente]["estados"][estado][key].ToString();
            }
            return "";
        }

        public void setPacienteEstado(string paciente, string estado, string key, string value) {
            data["pacientes"][paciente]["estados"][estado][key] = value;
        }

    }
}
