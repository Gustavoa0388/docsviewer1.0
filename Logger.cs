using System;
using System.IO;
using System.Windows.Forms;

namespace DocumentosOrtobio
{
    public static class Logger
    {
        private static readonly string logFilePath = @"\\D4MDP574\Doc Viewer$\Banco de dados\activity_log.txt";

        public static void Log(string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(logFilePath, true))
                {
                    writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
                }
            }
            catch (Exception ex)
            {
                // If logging fails, there's not much we can do, but we can try to show a message box
                MessageBox.Show($"Failed to write log: {ex.Message}", "Logging Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}