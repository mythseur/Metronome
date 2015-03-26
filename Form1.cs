using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Metronome
{
    public partial class Form1 : Form
    {
        const int basetime = 0;
        int time = 0;
        Timer atimer = new Timer();
        SoundPlayer simpleSound = new SoundPlayer(Properties.Resources.beep);

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = time.ToString();
            atimer.Tick += new EventHandler(OnTimedEvent);
            atimer.Interval = 1000;
        }

        private void Start()
        {
            atimer.Start();
            button1.Text = "Stop";
        }

        private void Reset()
        {
            atimer.Stop();
            button1.Text = "Start";
            time = basetime;
            textBox1.Text = time.ToString();
        }
        private void OnTimedEvent(object sender, EventArgs e)
        {
            time++;
            textBox1.Text = time.ToString();
            if (time%10 == 0)
            {
                    simpleSound.Play();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (button1.Text == "Start")
            {
                Start();
            }
            else
            {
                Reset();
            }
        }
    }
}
