using MoxIT.Template.Core;
using NLog;
using System.ServiceProcess;
using System.Threading;


namespace MoxIT.Template.Services
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        private static readonly Logger logger = ConfigNLog.ConfigurationNLog();
        public Service1()
        {
            InitializeComponent();
            logger.Info("Inicializando servicio ...");
        }

        protected override void OnStart(string[] args)
        {
            logger.Info("Iniciando servicio ...");
            timer = new Timer(Business, null, 0, 60000);
        }

        private void Business(object state)
        {
            logger.Info("Ejecutando Business");
            var writer = new WriteCurrentDateToFile();
            writer.Write();
        }

        protected override void OnStop()
        {
            logger.Info("Iniciando paro de servicio ...");
            timer?.Dispose();
        }

    }
}
