using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoxIT.Template.Core
{
    public class WriteCurrentDateToFile
    {
        public void Write()
        {
            string fileName = "output.txt";
            string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            using (StreamWriter writer = new StreamWriter(fileName, true))
            {
                writer.WriteLine(currentDate);
            }
            
        }       
    }
}
