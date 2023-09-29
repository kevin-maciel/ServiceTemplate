using MoxIT.Template.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MoxIT.Template.Services
{
    public partial class Service1 : ServiceBase
    {
        private Timer timer;
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        { 
            timer = new Timer(Business, null, 0, 60000);
        }

        private void Business(object state)
        {
            var writer = new WriteCurrentDateToFile();
            writer.Write();
        }

        protected override void OnStop()
        {
            timer?.Dispose();
        }

    }
}
