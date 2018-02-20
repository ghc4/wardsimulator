using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HospitalWard
{
    public partial class Form1 : Form
    {
        private NetworkStream sockStream;
        private BinaryWriter escreve;
        private BinaryReader le;
        Byte[] data = new Byte[256];


        public Form1()
        {
            InitializeComponent();
            this.panel1.MouseWheel += panel1_MouseWheel;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            foreach (Control c in this.Controls)
            {
                Console.WriteLine(c.Name);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            TcpClient client = new TcpClient();
            client.Connect("127.0.0.1", 10828);
            sockStream = client.GetStream();
            escreve = new BinaryWriter(sockStream);
            le = new BinaryReader(sockStream);
            escreve.Write("teste".ToCharArray());

            data = new Byte[256];
            String message = String.Empty;
            Int32 bytes = sockStream.Read(data, 0, data.Length);
            message = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            Console.WriteLine(message);
            client.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Pen pen = new Pen(Color.Black);
            Random rnd = new Random();
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            g.DrawLine(pen, new Point(rnd.Next(10, 150), rnd.Next(10, 150)), new Point(rnd.Next(10, 150), rnd.Next(10, 150)));

            var bmp = new Bitmap(Properties.Resources.ward);
            Rectangle rec = new Rectangle(rnd.Next(0, 500), rnd.Next(0, 500), rnd.Next(0, 500), rnd.Next(0, 500));
            Bitmap bmpImage = new Bitmap(bmp);
            g.DrawImage(bmpImage.Clone(rec, bmpImage.PixelFormat), new Point(rnd.Next(10, 150), rnd.Next(10, 150)));
        }


        private void panel1_MouseWheel(object sender, MouseEventArgs e)
        {
            Random rnd = new Random();
            Graphics g = panel1.CreateGraphics();
            g.Clear(Color.White);
            var bmp = new Bitmap(Properties.Resources.ward);
            Rectangle rec = new Rectangle(rnd.Next(0, 500), rnd.Next(0, 500), rnd.Next(0, 500), rnd.Next(0, 500));
            Bitmap bmpImage = new Bitmap(bmp);
            g.DrawImage(bmpImage.Clone(rec, bmpImage.PixelFormat), new Point(rnd.Next(10, 150), rnd.Next(10, 150)));
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
