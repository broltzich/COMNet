using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Ports;
using System.IO;

namespace Core.Workstation
{
    
    class PC : IDisposable
    {
        SerialPort COM_in;
        SerialPort COM_out;
        string WorkName;
        List<byte[]> intetnalBuffer;
        enum TransferingState { pass, send, receive }
        
        public PC(string PCName, string inPort, string outPort)
        {
            COM_in = PortFactory.CreatePort(inPort);
            COM_out = PortFactory.CreatePort(outPort);
            WorkName = PCName;
        }
        public void Login()
        {
            try
            {
                COM_in.Open();
                COM_in.DataReceived += COM_in_DataReceived;
                COM_out.Open();
                Console.WriteLine("[{0}] successfully logged in", WorkName);
            }
            catch (Exception e) { Console.WriteLine("ERROR: cannot open the ports ({0}", e); return; }

        }

        private void COM_in_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            var bytes = ReadBuff();
            try
            {
                // File.WriteAllBytes("D:/Projects/COMNet/received_file.txt", bytes);
                CheckBuffers();
                Console.WriteLine("File received!");
            }
            catch (Exception ee) { Console.WriteLine("ERROR: {0}", ee.ToString()); return; }
        }

        public byte[] ReadBuff()
        {
            var buff = new byte[COM_in.BytesToRead];
            COM_in.Read(buff, 0, buff.Length);
            return buff;
        }

        public void WriteBuff(byte[] input)
        {
            int pos = 0;
            
            if (COM_out.BytesToWrite == 0)
            {
                while (pos < input.Length - 1)
                {
                    var dif = input.Length - pos;
                    dif = dif < 1024 ? dif : 1024;
                    COM_out.Write(input, pos, dif);
                    pos += 1024;
                    COM_out.DiscardOutBuffer();
                }
            }
            
        }

        // Переда
        void PassData()
        {

        }

        public void Dispose()
        {
            if (COM_in.IsOpen)
            {
                COM_in.Close();
                COM_in.Dispose();
            }
        }
        public void CheckBuffers()
        {
            Console.WriteLine("BytesToRead: {0}", COM_in.BytesToRead);
            Console.WriteLine("BytesToWrite: {0}", COM_out.BytesToWrite);
        }
    }
}
