using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemInformation
{
    public static class Logger
    {
        private static readonly string logFilePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Logs", "log_" + DateTime.Now.ToString("dd-MM-yyyy") + ".txt");

        static Logger()
        {
            string logDir = Path.GetDirectoryName(logFilePath);
            if (!Directory.Exists(logDir))
                Directory.CreateDirectory(logDir);
        }

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now:dd-MM-yyyy HH:mm:ss} - {message}");
                }
            }
            catch (Exception)
            {
                // Burada bile log hata verirse sessizce geç.
            }
        }

        public static void LogError(Exception ex)
        {
            Log($"HATA: {ex.Message}\n{ex.StackTrace}");
        }
    }
}
