using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace curdraw
{
    class Program
    {
        private static SerialPort port;
        private static StreamWriter file;
         
        static void Main(string[] args)
        {
            port = new SerialPort(args[0], Int32.Parse(args[1]));
            port.DataReceived += new SerialDataReceivedEventHandler(onSerialData);
            
            var fileName = "curdraw_" + DateTime.Now.ToString("dd.MM.yyyy_HH.mm") + ".log";

            file = new System.IO.StreamWriter(fileName);
            file.WriteLine("millis,current");

            port.Open();

            Console.Read();
            port.Close();
            file.Close();

            Plot(Path.Combine(Directory.GetCurrentDirectory(), fileName));
        }

        private static void onSerialData(object sender, SerialDataReceivedEventArgs e)
        {
            var line = port.ReadLine();
            var vals = line.Split(',');
            if (vals.Length == 2)
            {
                file.Write(line);
                Console.WriteLine(line);
            }
        }

        private static void Plot(string csvFileName)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            startInfo.FileName = "python";
            startInfo.Arguments = "plot2.py " + csvFileName;
            process.StartInfo = startInfo;
            process.Start();
        }
    }
}
