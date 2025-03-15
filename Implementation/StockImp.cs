using StockAnalyticDataFetch.Service;
using System;
using System.Diagnostics;

namespace StockAnalyticDataFetch.Implementation
{
    public class StockImp : StockService
    {
        private static Process _pythonProcess;
        private static string pythonPath = @"C:\Users\dell\AppData\Local\Microsoft\WindowsApps\python.exe";
        private static string scriptPath = @"C:\phpFetch\dataFetcher.py";
        private static bool isScriptRunning = false;
        public void startStockDataFetch(bool toStart)
        {
            if (toStart)
            {
                if (!isScriptRunning)
                {
                    _pythonProcess = new Process();
                    _pythonProcess.StartInfo.FileName = pythonPath;
                    _pythonProcess.StartInfo.Arguments = $"\"{scriptPath}\"";
                    _pythonProcess.StartInfo.RedirectStandardOutput = true;
                    _pythonProcess.StartInfo.UseShellExecute = false;
                    _pythonProcess.StartInfo.CreateNoWindow = true;

                    try
                    {
                        string output = string.Empty;
                        _pythonProcess.Start();
                        //using (System.IO.StreamReader reader = _pythonProcess!.StandardOutput)
                        //{
                        //    output = reader.ReadToEnd();
                        //}
                        isScriptRunning = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error starting the Python script: {ex.Message}");
                    }
                }
                else
                {
                    Console.WriteLine("Script is already running.");
                }
            }
            else
            {
                if (isScriptRunning && _pythonProcess != null && !_pythonProcess.HasExited)
                {
                    _pythonProcess.Kill(); // Kill the process
                    isScriptRunning = false;
                    Console.WriteLine("Script has been stopped.");
                }
                else
                {
                    Console.WriteLine("No script is running to stop.");
                }
            }
          


            

            //string output = string.Empty;
            //try
            //{
            //    using (Process process = Process.Start(processInfo)!)
            //    {
            //        using (System.IO.StreamReader reader = process!.StandardOutput)
            //        {
            //            output = reader.ReadToEnd();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    output = $"Error: {ex.Message}";
            //}

        }
    }
}
