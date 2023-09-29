using MoxIT.Template.Core;
using System;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MoxIT.Template.Desktop
{
    public partial class Form2 : Form
    {
        private Timer timer;
        public Form2()
        {
            InitializeComponent();
            Config();
        }

        private void Config()
        {
            var timerConfig = new Timer();
            timerConfig.Interval = 6000;
            timerConfig.Elapsed += new ElapsedEventHandler((object s, ElapsedEventArgs ea) =>
            {
                Business();
            });
            timer = timerConfig;

            stop.Enabled = false;
        }

        private void start_Click(object sender, EventArgs e)
        {
            timer.Start();
            MessageBox.Show("El servicio inicio correctamente");
            start.Enabled = false;
            stop.Enabled = true;
        }

        private void stop_Click(object sender, EventArgs e)
        {
            timer?.Stop();
            MessageBox.Show("El servicio paro correctamente");
            start.Enabled = true;
            stop.Enabled = false;
        }

        private void Business()
        {
            var writeDate = new WriteCurrentDateToFile();
            writeDate.Write();
        }
    }
}
