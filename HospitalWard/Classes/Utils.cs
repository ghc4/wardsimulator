using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HospitalWard {
    public class Utils {
        public static Random rnd = new Random();
        public static string textLog = "";
        public static TextBox textBox = null;

        public static string minutesToTimeBr(int tempo) {
            TimeSpan result = TimeSpan.FromSeconds(tempo);
            return result.ToString("hh':'mm':'ss");
        }

        public void loga(TextBox log, string s) {
            log.AppendText("\r\n" + s);
            Application.DoEvents();
        }

        public void loga(string s) {
            if (textBox != null) {
                loga(textBox, s);
            } else {
                textLog += "\r\n" + s;
                //log.AppendText("\r\n" + s);
                Debug.WriteLine(s);
                Application.DoEvents();
            }
        }
    }
}
