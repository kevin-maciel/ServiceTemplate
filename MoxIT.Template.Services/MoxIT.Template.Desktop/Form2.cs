using MoxIT.Template.Core;
using NLog;
using System;
using System.Configuration;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace MoxIT.Template.Desktop
{
    public partial class Form2 : Form
    {
        private Timer timer;
        private static readonly Logger logger = ConfigNLog.ConfigurationNLog();
        public Form2()
        {
            InitializeComponent();
            Config();
            logger.Info("Iniciando configuraciones iniciales");
        }

        private void Config()
        {
            int.TryParse(ConfigurationManager.AppSettings.Get("interval"), out int interval);

            var timerConfig = new Timer
            {
                Interval = interval// 1 minuto
            };
            timerConfig.Elapsed += new ElapsedEventHandler((object s, ElapsedEventArgs ea) =>
            {
                Business();
            });
            timer = timerConfig;

            stop.Enabled = false;
        }

        private void start_Click(object sender, EventArgs e)
        {
           logger.Info("Iniciando start");
           timer.Start();
           MessageBox.Show("El servicio inicio correctamente");
           start.Enabled = false;
           stop.Enabled = true;
           
        }

        private void stop_Click(object sender, EventArgs e)
        {
            logger.Info("Parando con stop");
            timer?.Stop();
            MessageBox.Show("El servicio paro correctamente");
            start.Enabled = true;
            stop.Enabled = false;
        }

        private void Business()
        {
            logger.Info("Ejecutando Business"); 
            try
            {
                string path = ConfigurationManager.AppSettings["path"];
                //Llamar a la clase de logica aca
            }
            catch(Exception ex)
            {
                logger.Error("Error en business " + ex);
            }
        }
    }
}
