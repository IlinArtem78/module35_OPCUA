using System.Diagnostics;

namespace OPCUA_API.WorkWithServer
{
    public class RunOPCUA : IRunOpcUA
    {
        private Process _opcUaServerProcess;

        /// <summary>
        /// Запуск OPC UA Servera на стороне localhost
        /// </summary>
        public async Task StartWindowsFormsApp()
        {
            _opcUaServerProcess = new Process();
            _opcUaServerProcess.StartInfo.FileName = "D:\\WORK\\OPCUaServer\\bin\\Debug\\net8.0-windows\\OpcUaServerSample.exe";
            _opcUaServerProcess.StartInfo.UseShellExecute = false; // Устанавливаем UseShellExecute в false
            _opcUaServerProcess.StartInfo.RedirectStandardOutput = true;

            try
            {
                // Запускаем процесс асинхронно
                _opcUaServerProcess.Start();
                if (_opcUaServerProcess.HasExited)
                {
                    Console.WriteLine("Процесс завершился сразу после запуска.");
                }
                else
                {
                    await _opcUaServerProcess.WaitForExitAsync();
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при запуске приложения: {ex.Message}");
            }
        }

        /// <summary>
        /// Остановка OPC UA сервера
        /// </summary>
        public void StopWindowsFormsApp()
        {
            if (_opcUaServerProcess != null && !_opcUaServerProcess.HasExited)
            {
                _opcUaServerProcess.Kill();
            }
        }
    }
}
