using Opc.Ua;
using Opc.Ua.Configuration;
using Opc.Ua.Server.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using OPCUA_API.Repositoria;

namespace OpcUaServerSample
{
    public static class Program
    {
        public static OPCUARepositories repositories { set; get; } = new OPCUARepositories();

        [STAThread]
        public static async Task Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            ApplicationInstance.MessageDlg = new ApplicationMessageDlg();
            ApplicationInstance application = new ApplicationInstance();
            application.ApplicationType = ApplicationType.Server;
            application.ConfigSectionName = "SharpNodeSettingsServer";

            try
            {
                // load the application configuration.
                await application.LoadApplicationConfiguration(false);

                // check the application certificate.
                bool certOk = await application.CheckApplicationInstanceCertificate(false, 0);
                if (!certOk)
                {
                    throw new Exception("Application instance certificate invalid!");
                }

                repositories.ConverToClass();
                
                // start the server.
                await application.Start(new SharpNodeSettingsServer());
             //   await application.Stop(); 
                // run the application interactively.
                ServerForm serverForm = new ServerForm(application);
                serverForm.StartPosition = FormStartPosition.CenterScreen;
                Application.Run(serverForm);
             //   Application.Restart();
                Console.WriteLine("Сервер запущен");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при запуске сервера: {e.Message}");
                Console.WriteLine(e.StackTrace);
                ExceptionDlg.Show(application.ApplicationName, e);
            }
        }
    }
}
