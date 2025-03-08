using System;
using System.Threading;
using System.Windows.Forms;

namespace DocumentosOrtobio
{
    static class Program
    {
        private static Mutex mutex = null;

        [STAThread]
        static void Main()
        {
            const string mutexName = "DocumentosOrtobioMutex";

            mutex = new Mutex(true, mutexName, out bool createdNew);

            if (createdNew)
            {
                // Defina o caminho personalizado para o arquivo de log
                //string customLogFilePath = @"\\D4MDP574\Doc Viewer$\Banco de dados\activity_log.txt";
               // ActivityLogger.Initialize(customLogFilePath);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new LoginForm());
            }
            else
            {
                MessageBox.Show("O aplicativo já está em execução.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Application.Exit();
            }
        }
    }
}