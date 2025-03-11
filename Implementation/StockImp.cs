using StockAnalyticDataFetch.Service;
using System.Diagnostics;

namespace StockAnalyticDataFetch.Implementation
{
    public class StockImp : StockService
    {
        public void startStockDataFetch()
        {
            string pythonPath = @"C:\Users\dell\AppData\Local\Microsoft\WindowsApps\python.exe";
            string scriptPath = @"C:\phpFetch\dataFetcher.py";

            ProcessStartInfo processInfo = new ProcessStartInfo();
            processInfo.FileName = pythonPath;
            processInfo.Arguments = $"\"{scriptPath}\"";
            processInfo.RedirectStandardOutput = true;
            processInfo.UseShellExecute = false;
            processInfo.CreateNoWindow = true;

            string output = string.Empty;
            try
            {
                using (Process process = Process.Start(processInfo)!)
                {
                    using (System.IO.StreamReader reader = process!.StandardOutput)
                    {
                        output = reader.ReadToEnd();
                    }
                }
            }
            catch (Exception ex)
            {
                output = $"Error: {ex.Message}";
            }

        }
    }
}
