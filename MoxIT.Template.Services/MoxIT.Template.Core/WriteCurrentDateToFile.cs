using System;
using System.IO;

namespace MoxIT.Template.Core
{
    public class WriteCurrentDateToFile
    {
        public void Write()
        {
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
            try
            {
                // Abrir el archivo en modo de lectura
                using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                using (StreamReader reader = new StreamReader(fs))
                {
                    string content = reader.ReadToEnd();
                    Console.WriteLine("Contenido del archivo con FileAccess.Read:");
                    Console.WriteLine(content);
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer el archivo: {ex.Message}");
            }
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
                Console.WriteLine("Archivo creado y escrito con éxito.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al escribir en el archivo: {ex.Message}");
            }
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
                    Console.WriteLine("Contenido original del archivo:");
                    Console.WriteLine(content);

                    // Escribir algo nuevo al final del archivo
                    writer.WriteLine("Nueva línea escrita en modo FileAccess.ReadWrite.");
                }
                Console.WriteLine("Archivo leído y modificado con éxito.");
            }
            catch (IOException ex)
            {
                Console.WriteLine($"Error al leer o escribir en el archivo: {ex.Message}");
            }
        }
    }
}
