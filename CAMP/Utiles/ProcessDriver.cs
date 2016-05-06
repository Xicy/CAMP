using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CAMP.Utiles
{
    public class ProcessDriver
    {
        private Process _driver;
        private ProcessStartInfo psi;
        public bool IsRuning = false;

        public enum OutputType
        {
            Stared, Closed, Error, Info
        }

        public delegate void OutputEventHandler(OutputType ot, object dt);

        public event OutputEventHandler OutputTrigger;

        public ProcessDriver(string path, string file, string argument)
        {
            psi = new ProcessStartInfo
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                StandardErrorEncoding = Encoding.UTF8,
                StandardOutputEncoding = Encoding.UTF8,
                WorkingDirectory = path,
                FileName = Path.Combine(path, file),
                Arguments = argument
            };
        }

        public void WaitForExit()
        {
            while (!_driver.HasExited)
            {
                Thread.Sleep(500);
            }
        }

        public void Start()
        {
            _driver = new Process {StartInfo = psi};
            _driver.Exited += (sender, args) => OutputTrigger?.Invoke(OutputType.Closed, _driver.ExitTime.ToLongTimeString());
            _driver.OutputDataReceived += (sender, args) => OutputTrigger?.Invoke(OutputType.Info, args.Data);
            _driver.ErrorDataReceived += (sender, args) => OutputTrigger?.Invoke(OutputType.Error, args.Data);

            _driver.Start();

            IsRuning = true;
            OutputTrigger?.Invoke(OutputType.Stared, _driver.StartTime.ToLongTimeString());

            _driver.BeginOutputReadLine();
            _driver.BeginErrorReadLine();

            Task.Factory.StartNew(() => { _driver.WaitForExit(); IsRuning = false; });
        }

        public void Send(string command) => _driver.StandardInput.Write(command + Environment.NewLine);

        public void Stop()
        {
            if (!IsRuning) return;
            var a = Process.GetProcessById(_driver.Id);
            _driver.Kill();
            IsRuning = false;
            a.WaitForExit();
            a.Close();
        }

        public void Restart()
        {
            Stop();
            Start();
        }

    }
}