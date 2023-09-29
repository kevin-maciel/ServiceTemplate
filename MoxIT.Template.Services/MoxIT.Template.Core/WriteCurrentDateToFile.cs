using NLog;
using NLog.Fluent;
using System;
using System.IO;

namespace MoxIT.Template.Core
{
    public class WriteCurrentDateToFile
    {
        private static readonly Logger logger = ConfigNLog.ConfigurationNLog();

        public void Write()
        {
            logger.Info("Iniciando Write");
            try
            {
                string fileName = "output.txt";
                string currentDate = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine(currentDate);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }   
        }

        public static void ReadFile(string filePath)
        {
            logger.Info("Ejecutando ReadFile");

            try
            {
                // Abrir el archivo en modo de lectura
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fs))
                {
                    string content = reader.ReadToEnd();
                    logger.Info("Contenido del archivo con FileAccess.Read:");
                    logger.Info(content);
                }
            }
            catch (IOException ex)
            {
                logger.Error($"Error al leer el archivo: {ex.Message}");
                throw ex;
            }
            logger.Info("ReadFile termino con exito");
        }

        public static void WriteFile(string filePath)
        {
            try
            {
                // Abrir el archivo en modo de escritura (creará uno nuevo si no existe)
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.Write))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    writer.WriteLine("Linea de texto creada con modo FileAccess.Write.");
                }
                logger.Info("Archivo creado y escrito con éxito.");
            }
            catch (IOException ex)
            {
                logger.Error($"Error al escribir en el archivo: {ex.Message}");
                throw ex;
            }
            logger.Info("WriteFile termino con exito");
        }

        public static void ReadAndWriteFile(string filePath)
        {
            try
            {
                // Abrir el archivo en modo de lectura y escritura
                using (FileStream fs = new FileStream(filePath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                using (StreamReader reader = new StreamReader(fs))
                using (StreamWriter writer = new StreamWriter(fs))
                {
                    string content = reader.ReadToEnd();
                    logger.Info("Contenido original del archivo:");
                    logger.Info(content);

                    // Escribir algo nuevo al final del archivo
                    writer.WriteLine("Nueva línea escrita en modo FileAccess.ReadWrite.");
                }
                logger.Info("Archivo leído y modificado con éxito.");
                logger.Info("ReadAndWriteFile termino con exito");
            }
            catch (IOException ex)
            {
                logger.Error($"Error al leer o escribir en el archivo: {ex.Message}");
                throw ex;
            }
        }
    }
}
