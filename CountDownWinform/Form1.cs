using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CountDownWinform
{
    public partial class Form1 : Form
    {
        private int totalSeconds;
        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < 60; i++)
            {
                this.minuteBox.Items.Add(i.ToString());
                this.secondsBox.Items.Add(i.ToString());
            }
            this.minuteBox.SelectedIndex = 59;
            this.secondsBox.SelectedIndex = 59;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.buttonStart.Enabled = false;
            this.buttonStop.Enabled = true;

            int muinutes = int.Parse(this.minuteBox.SelectedItem.ToString());
            int seconds = int.Parse(this.secondsBox.SelectedItem.ToString());

            totalSeconds = (muinutes * 60) + seconds;

            this.timer1.Enabled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.buttonStop.Enabled = false;
            this.buttonStart.Enabled = true;

            totalSeconds = 0;
            this.timer1.Enabled = false;
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (totalSeconds > 0)
            {
                totalSeconds--;
                int minutes = totalSeconds / 60;
                int seconds = totalSeconds - (minutes * 60);

                this.label3.Text = minutes.ToString() + ":" + seconds.ToString();
                if(seconds < 10)
                {
                    this.label3.Text = minutes.ToString() + ":0" + seconds.ToString();
                }
                if(minutes < 10)
                {
                    this.label3.Text = "0" + minutes.ToString() + ":" + seconds.ToString(); 
                }
                if((minutes < 10) && (seconds < 10))
                {
                    this.label3.Text = "0" + minutes.ToString() + ":0" + seconds.ToString();
                }
            }
            else
            {
                this.timer1.Stop();
                MessageBox.Show("HAPPY NEW YEAR");
            }
        }
    }
}
