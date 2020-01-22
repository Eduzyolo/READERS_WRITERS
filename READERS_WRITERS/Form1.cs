using READERS_WRITERS.CLASSES;
using System.Speech.Synthesis;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace READERS_WRITERS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SpeechSynthesizer synthesizer = new SpeechSynthesizer();
            synthesizer.Volume = 0;  // 0...100
            synthesizer.Rate = 0;

            byte[] bytes = System.IO.File.ReadAllBytes("./BUFFER/START/Lorem_Ipsum_1P.txt");
            string text = System.Text.Encoding.UTF8.GetString(bytes);

            // Synchronous
            synthesizer.Speak(text);
        }
       
    }
}
